using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.VisualBasic;
using Serilog;

namespace Infrastructure.Filters
{
    public class MovieShopHeaderFilter : IActionFilter
    {

        private readonly ICurrentUserService _currentUserService;

       
        public MovieShopHeaderFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }

        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.Headers.Add("job", "antra.com/jobs");
            //log each and every user's ip address , his name if authenticated, autheicatoin status , data time 

            try
            {

                Log.Information("The user Email is {Email}", _currentUserService.Email);
                Log.Information("The user DateTime is {Date}", DateTime.UtcNow);
                Log.Information("If the user is authentcaited  {IfAuthenticated}", _currentUserService.IsAuthenticated);
                Log.Information("The user fullname is {Name}", _currentUserService.FullName);

            }
            catch (Exception ex)
            {
                Log.Error(ex, "Something went wrong");

            }
         
            //log this infro to text files
            // use System.IO
            // ****Serilog, Nlog, Log4net

        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            
        }
    }
}
