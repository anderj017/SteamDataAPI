using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class PlayerSummaries
    {
        [JsonProperty(PropertyName = "players")]
        public List<PlayerProfile> Players  { get; set; }
    }
}
