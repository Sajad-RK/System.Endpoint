using System;
using System.Collections.Generic;
using System.DataAccessLayer.Models;
using System.Linq;
using System.Threading.Tasks;

namespace System.Web.API.EndpointModels
{
    public class AuthenticateResponse
    {
        public User User { get; set; }
        public string Token { get; set; }
    }
}
