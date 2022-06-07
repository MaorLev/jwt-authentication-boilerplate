using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Data.DTO
{
    public class AuthUserDTO
    {
        [JsonProperty(PropertyName = "email")]
        public string Mail { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }
    }
}
