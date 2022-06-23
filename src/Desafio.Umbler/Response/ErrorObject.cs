using Newtonsoft.Json;

namespace Desafio.Umbler.Response
{
    public class ErrorObject
    {

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("details")]
        public object Details { get; set; }
    }
}
