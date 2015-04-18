using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPIWrapper
{
    public class ScheduledLeageGames
    {
        [JsonProperty(PropertyName = "games")]
        public List<ScheduledLeagueGame> Games { get; set; }
    }

    public class ScheduledLeagueGame
    {
        [JsonProperty(PropertyName = "league_id")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "game_id")]
        public int GameId { get; set; }

        [JsonProperty(PropertyName = "teams")]
        public List<ScheduledLeagueGameTeam> Teams { get; set; }
    }

    public class ScheduledLeagueGameTeam
    {
        [JsonProperty(PropertyName = "team_id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "team_name")]
        public string Name { get; set; }
    }
}
