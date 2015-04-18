using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPIWrapper
{
    public class LeagueList
    {
        [JsonProperty(PropertyName = "leagues")]
        public List<League> Leagues;
    }

    public class League
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "leagueid")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "tournament_url")]
        public string TournamentUrl { get; set; }
    }
}
