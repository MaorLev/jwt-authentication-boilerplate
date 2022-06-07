using Newtonsoft.Json;

namespace jwt_authentication_boilerplate.Data.DTO
{
    public class JwtResultDTO
    {
        [JsonProperty(PropertyName = "access_token")]
        public string AccessToken { get; set; }
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }
        [JsonProperty(PropertyName = "expired")]
        public long Expired { get; set; }
    }
}
