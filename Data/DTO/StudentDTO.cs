using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace jwt_authentication_boilerplate.Data.DTO
{
    public class StudentDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }
        [JsonProperty(PropertyName = "firstname")]

        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]

        public string LastName { get; set; }
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        [JsonProperty(PropertyName = "studystartyear")]
        public string StudyStartYear { get; set; }
    }
}
