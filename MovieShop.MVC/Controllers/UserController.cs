using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {

        //This attribute used cookies based authication in configruservice
        // it will check the cookie to see user is login or not 

        [Authorize]  // this will check the IsAutheticated in identity hettpcontxt in auto whichi is cookies 
        [HttpGet]
        public async Task<IActionResult> GetUserPurchasedMovies()
        {
            //call user service by id for user to get all movies he/she purchased
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PurchaseMovie()
        {
            return View();
        }

    }
}
