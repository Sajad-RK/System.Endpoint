using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Services.Repositories;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace System.Endpoint.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly IUserRepositories userRepositories;
        public LoginController(IConfiguration _config, IUserRepositories _userRepositories)
        {
            configuration = _config;
            userRepositories = _userRepositories;
        }
        public IActionResult Index()
        {
            return null;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]User user)
        {
            IActionResult response = Unauthorized();
            var auth_user = AuthenticateUser(user);
            if (auth_user != null)
            {
                var tokenString = GenerateJWT(user);
                response = Ok(new { token = tokenString });
            }
            return response;
        }

        private string GenerateJWT(User user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Issuer"], null,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(User login)
        {
            User user = userRepositories.Find(a => a.Id == login.Id)?.FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }
    }
}
