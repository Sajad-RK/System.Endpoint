using Newtonsoft.Json;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace System.Web.API.EndpointModels
{
    //[SwaggerSchema(Required = new[] { "Login method body parameters" })]
    public class LoginRequest
    {
        [SwaggerSchema("Username, get it from company", Required = new[] { "false" })]
        //[JsonProperty("Username")]
        //[Required]
        public string Username { get; set; }

        [SwaggerSchema("Password, get it from company", Required = new[] { "false" })]
        //[Required]
        //[JsonProperty("Password")]
        public string Password { get; set; }
    }
}
