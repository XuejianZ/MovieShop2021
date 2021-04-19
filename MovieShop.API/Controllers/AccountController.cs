using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtService _jwtService;

        public AccountController(IUserService userService, IJwtService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }



        [HttpPost]
        [Route("Register")]                                                  //model binding
        public async Task<IActionResult> RegisterUser(UserRegisterRequestModel requestModel)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest("please check data ");
            }

            var resgisterdUser = await _userService.RegisterUser(requestModel);
            return Ok(resgisterdUser);

        }



        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(LoginRequestModel model)

        {
            var user = await _userService.ValidateUser(model.Email, model.Password);
            if (user == null)
            {
                return Unauthorized();
            }
            var jwtToken = _jwtService.GenerateToken(user);

            //genreate a jwt token and send it to Client
            return Ok(new { token = jwtToken });

        }

        //[HttpGet]
        //[Route("Login/{")]






    }
}
