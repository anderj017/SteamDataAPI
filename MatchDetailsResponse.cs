using Newtonsoft.Json;

namespace SteamWebAPIWrapper
{
    public class Response<T>
    {
        [JsonProperty(PropertyName = "result")]
        public T Result;
    }
}
