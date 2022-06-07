using Newtonsoft.Json;


namespace jwt_authentication_boilerplate.Data.DTO
{
    public class AdminDTO
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }
        [JsonProperty(PropertyName = "mail")]
        public string Mail { get; set; }

        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }


    }
}
