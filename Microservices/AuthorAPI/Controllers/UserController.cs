using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthorAPI.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using AuthorAPI.Services;
using Microsoft.AspNetCore.Cors;

namespace AuthorAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        IUserService userService;
        public UserController(IUserService _userService)
        {
            userService = _userService;
        }

        [HttpGet]
        public IEnumerable<User> get()
        {
            return userService.GetAll();
        }

        [HttpPost]
        [Route("login-user")]
        
        public IActionResult Login(User login)
        {
            IActionResult response = Unauthorized();
            var loguser = userService.AuthenticateUser(login, false);
            if (loguser != null)
            {
                var tokenString = userService.GenerateToken(loguser);
                response = Ok(new { token = tokenString, userid = loguser.Id ,type= loguser.Type});
            }
            return response;

        }
       

       

        [HttpPost]
        [Route("register-user")]
        public IActionResult Register(User login)
        {
            IActionResult response = Unauthorized();
            var user = userService.AuthenticateUser(login, true);
            if (user != null)
            {
                var tokenString = userService.GenerateToken(user);
                response = Ok(new { token = tokenString, userid = user.Id, type = user.Type });
            }
            return response;

        }
    }
}
