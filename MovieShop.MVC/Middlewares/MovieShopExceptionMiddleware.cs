using ApplicationCore.Exceptions;
using ApplicationCore.Helpers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.MVC.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project



    // this is global handler 
    public class MovieShopExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<MovieShopExceptionMiddleware> _logger;
        public MovieShopExceptionMiddleware(RequestDelegate next, ILogger<MovieShopExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {

                // here is important, pass every request to the next pipeline 
                await _next(httpContext);

            }
            catch (Exception ex)
            {

                _logger.LogError("Middleware is cathcing exception");
                await HandleExceptionAsync(httpContext, ex);
            }


        }
        //return _next(httpContext);  //going to next middleware 

        private async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            // get all the inforamtion you wonna log and use Seriilog or Nlog to log exceptions to text/json files

            _logger.LogError("Starting Logging for exception");


            //string UserId = ex.Data["Id"].ToString();
            //string Email = ex.Data["Email"].ToString();
            //string FullName = ex.Data["FullName"].ToString();

            //ClaimsPrincipal claimsPrincipal = httpContext.User;

            //var claimItems = new List<string>();

            //foreach(Claim claim in claimsPrincipal.Claims)
            //{
            //    claimItems.Add(claim.Value);
            //}

            var errorModel = new ErrorResponseModel
            {
                ExceptionMessage = ex.Message,
                ExceptionStackTrace = ex.StackTrace,
                InnerExceptionMessage = ex.InnerException?.Message,
                IsAuthorized = httpContext.User.Identity.IsAuthenticated,
                //FullName = claimItems[0] + " " + claimItems[1],
                //UserId = claimItems[2],
                //Email = claimItems[3],
                ExceptopnDateTime = DateTime.UtcNow
                //UserId = UserId,
                //Email = Email,
                //FullName =FullName



                //Email by using iuser or errorModel
            };


            switch (ex)
            {
                case ConflictException confilictException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Conflict;
                    break;
                case NotFoundException notFoundException:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.NotFound;
                    break;
                case UnauthorizedAccessException unauthorized:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                    break;
                case Exception exception:
                    httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    break;
            }



            //seri log to log errorModel along with 
            //Log.Information(errorModel.ExceptionMessage);
            //Log.Information(errorModel.ExceptionStackTrace);
            //Log.Information(errorModel.InnerExceptionMessage);
            //Log.Information("If the user is authentcaited  {IfAuthenticated}", errorModel.IsAuthorized.ToString());
            //Log.Information("The user DateTime is {Date}", DateTime.UtcNow);
            //Log.Information("The userID is {Name}", errorModel.UserId);
            //Log.Information("The user fullname is {Name}", errorModel.FullName);
            //Log.Information("The user Email is {Email}", errorModel.Email);

            ////send email also
            //var log = new LoggerConfiguration()
            //     .WriteTo.Email(
            //     fromEmail: "xuejianzhou2012@gmail.com",
            //     toEmail: "xuejianzhou2021@gmail.com",
            //     mailServer: "smtp.example.com")
            //        .CreateLogger();





            //reditect to error page 
            httpContext.Response.Redirect("/Home/Error");
            await Task.CompletedTask;

        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MovieShopExceptionMiddlewareExtensions
    {
        //any class implment IApplicationBuilder can call this method 
        //thie is actually how u register 
        public static IApplicationBuilder UseMovieShopExceptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<MovieShopExceptionMiddleware>();
        }
    }

}
