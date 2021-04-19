using ApplicationCore.ServiceInterfaces;
using Infrastructure.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using ApplicationCore.RepositoryInterfaces;
using Infrastructure.Repositories;
using ApplicationCore.Entities;
using AutoMapper;
using Infrastructure.Filters;
using Microsoft.AspNetCore.Authentication.Cookies;
using MovieShop.MVC.Middlewares;

namespace MovieShop.MVC
{
    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //DI is responsible for registration
            //resgistration concrete type 


            //register it globally 
            services.AddControllersWithViews(
                options => options.Filters.Add(typeof(MovieShopHeaderFilter))
                );



            //services.AddTransient<IMovieService, MovieService>();
            services.AddDbContext<MovieShopDbContext>(options =>
               options.UseSqlServer(Configuration.GetConnectionString("MovieShopDbConnection")));

            services.AddTransient<IMovieService, MovieService>();
            services.AddScoped<IGenreService, GenreService>();
            services.AddScoped<ICastService, CastService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICastRepository, CastRepository>();

            services.AddScoped<IMovieRepository, MovieRepository>();
            services.AddScoped<IAsyncRepository<Genre>, EfRepository<Genre>>();
            services.AddScoped<ICurrentUserService, CurrentUserService>();

            //customize the cookie 
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
               .AddCookie(options =>
               {
                   options.Cookie.Name = "MovieShopAuthCookie";
                   options.ExpireTimeSpan = TimeSpan.FromHours(2);
                   options.LoginPath = "/Account/login";  //if cookie is invalid , go to the login page
               }
               );

            services.AddHttpContextAccessor();
            services.AddMemoryCache(); //cahce is provided by icaching interface

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                // this is for development environment 

               app.UseMovieShopExceptionMiddleware();
             //   app.UseDeveloperExceptionPage();
            }
            else
            {   // this is for non development environment 
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
