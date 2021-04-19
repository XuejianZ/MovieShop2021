using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Serilog;
using Serilog.Events;

namespace MovieShop.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
              .MinimumLevel.Information()
              .WriteTo.Console()
              .WriteTo.File(@"C:\Users\XuejianZhou\Desktop\Logs\MovieShop.txt",
                  rollingInterval: RollingInterval.Minute,
                  rollOnFileSizeLimit: true
                 )
              .CreateLogger();


            Log.Information("Hello, Serilog!");

            try
            {
                CreateHostBuilder(args).Build().Run();
            }

            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");
            }

            finally
            {
                Log.CloseAndFlush();
            }

        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
    }
}
