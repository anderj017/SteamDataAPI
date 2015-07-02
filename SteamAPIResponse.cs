using Newtonsoft.Json;

namespace SteamWebAPIWrapper
{
    public class SteamAPIResponse<T>
    {
        [JsonProperty(PropertyName = "result")]
        public T Result;

        [JsonProperty(PropertyName = "response")]       // different for account API, Todo: will need to look into JsonConverter in the future.
        public T Response;
    }
}
