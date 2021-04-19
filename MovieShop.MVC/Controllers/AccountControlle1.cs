using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.Models.Request;
using ApplicationCore.RepositoryInterfaces;
using ApplicationCore.ServiceInterfaces;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

namespace MovieShop.MVC.Controllers
{
    public class AccountController : Controller
    {

        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterRequestModel model, string returnUrl = null)
        {
            var user = await _userService.RegisterUser(model);
            if (user != null)
            {
                returnUrl = Url.Content("/Account/login");
            }
            return LocalRedirect(returnUrl);
         //   return View();
        }



        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {

            //this one will delete the cookie for u auto
            await HttpContext.SignOutAsync();
            return RedirectToAction("Login");// it will redirect to action method 
        }

        //after login, u will be reirect to home page 
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestModel model, string returnUrl = null)

        {
            if (string.IsNullOrEmpty((returnUrl)))
            {
                returnUrl = Url.Content("~/");
            }

            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null)
            {
                //key ,value is for format, the reason return invlid login
                //attempt  is because not sure the reason of failuer is nonexist
                //user or incorrect password
                ModelState.AddModelError("", "Invalid Login attempt");
                return View();
            }


            // continue for actual user
            // Cookie based Authentication
            // once your service tells you that u entered correct un/pw, application needs to create a authentication cookie that has some data and also expiration time
            // FirstName, LastName, Dob
            // Encrypt information that you wanna store inside your cookie
            // Create Claims object with necessary information
            //claim is the info you provide inside the cookie

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.GivenName, user.FirstName),
                new Claim(ClaimTypes.Surname, user.LastName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Email, user.Email)
            };


            // Identity, built in .dot
            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);



            // creating the Cookie
            //this method also entrcy the claims for us automatically 
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));

            //after login, u will be reirect to home page 
            return LocalRedirect(returnUrl);//return to the main page ,this returnUr means main page
        }
    }
}
