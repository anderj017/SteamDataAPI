using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class Team
    {
        [JsonProperty(PropertyName = "team_name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "team_id")]
        public int TeamId { get; set; }

        [JsonProperty(PropertyName = "complete")]
        public bool Complete { get; set; }
    }
}
