using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Services.Repositories;
using System.Text;
using System.Threading.Tasks;
using System.Web.API.EndpointModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace System.Web.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LoginController : ControllerBase
    {
        private IConfiguration configuration;
        private readonly IUserRepositories userRepositories;
        public LoginController(IConfiguration _config, IUserRepositories _userRepositories)
        {
            configuration = _config;
            userRepositories = _userRepositories;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost/*("Login")*/]
        public IActionResult Login([FromBody] LoginRequest login)
        {
            IActionResult response = Unauthorized();
            var auth_user = AuthenticateUser(login);
            if (auth_user != null)
            {
                var tokenString = GenerateJWT(login);
                response = Ok(new { Token = tokenString });
            }
            return response;
        }

        //[Authorize]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var t = Request.Headers["Authorization"];
            return Ok();
        }
        
        
        
        private string GenerateJWT(LoginRequest login)
        {
            //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            //var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Issuer"], null,
            //    expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(login.Id, login.NationId, null,
                expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private User AuthenticateUser(LoginRequest login)
        {
            User user = userRepositories.Find(a => a.Id == new Guid(login.Id))?.FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            else
                return null;
        }
    }
}
