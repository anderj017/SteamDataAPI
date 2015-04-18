using Newtonsoft.Json;

namespace SteamWebAPIWrapper
{
    public class SteamAPIResponse<T>
    {
        [JsonProperty(PropertyName = "result")]
        public T Result;
    }
}
