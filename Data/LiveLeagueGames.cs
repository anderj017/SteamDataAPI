using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class LiveLeagueGames
    {
        [JsonProperty(PropertyName = "games")]
        public List<LiveLeagueGame> Games; 
    }

    public class LiveLeagueGame
    {
        [JsonProperty(PropertyName = "players")]
        public List<Player> Players { get; set; }

        [JsonProperty(PropertyName = "radiant_team")]
        public Team Radiant { get; set; }

        [JsonProperty(PropertyName = "dire_team")]
        public Team Dire { get; set; }

        [JsonProperty(PropertyName = "lobby_id")]
        public long LobbyId { get; set; }

        [JsonProperty(PropertyName = "spectators")]
        public int Spectators { get; set; }

        [JsonProperty(PropertyName = "tower_state")]
        public uint TowerState { get; set; }

        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }
    }
}
