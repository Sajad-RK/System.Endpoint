using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
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
                //var tokenString = GenerateJWT(login);
                response = Ok(new { auth_user.Token });
                return response;
            }
            return BadRequest(new { Message = "Username or password is incorrect." });
        }

        //[Authorize]
        [HttpGet("Get")]
        public IActionResult Get()
        {
            var users = userRepositories.GetAll();
            if (users == null)
                return BadRequest();
            return Ok(users);
        }
        
        
        
        //private string GenerateJWT(LoginRequest login)
        //{
        //    //var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        //    //var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    //var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Issuer"], null,
        //    //    expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);


        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        //    var token = new JwtSecurityToken(login.Id, login.NationId, null,
        //        expires: DateTime.Now.AddMinutes(120), signingCredentials: credentials);
        //    return new JwtSecurityTokenHandler().WriteToken(token);

        //}

        private AuthenticateResponse AuthenticateUser(LoginRequest login)
        {
            User user = userRepositories.Find(a => a.Username == login.Username && a.Password == login.Password)?.FirstOrDefault();
            if (user != null)
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(configuration.GetSection("Secret").Value);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new Security.Claims.ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddHours(2),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                return new AuthenticateResponse() { User = user, Token = tokenHandler.WriteToken(token) };
            }
            else
                return null;
        }
    }
}
