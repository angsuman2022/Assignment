using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookAPI.Models;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using System.IdentityModel.Tokens.Jwt;

namespace BookAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        BookAppDBContext db = new BookAppDBContext();

        private IConfiguration _config;

        public UserController(IConfiguration config)
        {

            _config = config;

        }

        [HttpPost]
        [Route("login-user")]
        public IActionResult Login(User login)
        {
            IActionResult response = Unauthorized();
            var loguser = AuthenticateUser(login, false);
            if (loguser != null)
            {
                var tokenString = GenerateToken(loguser);
                response = Ok(new { token = tokenString });
            }
            return response;

        }
        private User AuthenticateUser(User login, bool IsRegister)
        {
            if (IsRegister)
            {
                db.Users.Add(login);
                db.SaveChanges();
                return login;
            }
            if (db.Users.Any(x => x.Email == login.Email && x.Password == login.Password))
            {
                return db.Users.Where(x => x.Email == login.Email && x.Password == login.Password).FirstOrDefault();
            }
            else
            {
                return null;
            }
        }

        private string GenerateToken(User login)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["jwt:Key"]));
            var cradentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["jwt:Issuer"],
                _config["jwt:Audience"], null, expires: DateTime.Now.AddMinutes(120), signingCredentials: cradentials);
            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        [HttpPost]
        [Route("register-user")]
        public IActionResult Register(User login)
        {
            IActionResult response = Unauthorized();
            var user = AuthenticateUser(login, true);
            if (user != null)
            {
                var tokenString = GenerateToken(user);
                response = Ok(new { token = tokenString });
            }
            return response;

        }
    }
}
