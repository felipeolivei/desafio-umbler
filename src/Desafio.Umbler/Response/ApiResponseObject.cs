using Newtonsoft.Json;

namespace Desafio.Umbler.Response
{
    public class ApiResponseObject
    {
        [JsonProperty("result")]
        public object Result { get; set; }

        [JsonProperty("success")]
        public bool Success { get; set; }

        public ErrorObject Error { get; set; }
    }
}
