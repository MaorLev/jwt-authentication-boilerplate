

using Newtonsoft.Json;

namespace jwt_authentication_boilerplate.Data.DTO
{
    public class ResponseDTO
    {
        [JsonProperty(PropertyName = "status")]
        public StatusCode Status { get; set; }
        [JsonProperty(PropertyName = "statustext")]
        public string StatusText { get; set; }
        [JsonProperty(PropertyName = "user")]
        public int userId { get; set; }

    }
    public enum StatusCode
    {
        Success = 1000,
        Faild,
        Error,
        Warning
    }
}
