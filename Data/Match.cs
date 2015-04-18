using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class Match
    {
        [JsonProperty(PropertyName = "radiant_win")]
        public bool RadiantWon { get; set; }

        [JsonProperty(PropertyName = "duration")]
        public double Duration { get; set; }

        [JsonProperty(PropertyName = "start_time")]
        [JsonConverter(typeof(JavaScriptUnixDateTimeConverter))]
        public DateTime StartTimeUTC { get; set; }

        public int StartTimeUnix
        {
            get
            {
                return (Int32)(StartTimeUTC.Subtract(new DateTime(1970, 1, 1))).TotalSeconds;
            }
        }

        [JsonProperty(PropertyName = "match_id")]
        public int MatchId { get; set; }

        [JsonProperty(PropertyName = "series_id")]
        public int? SeriesId { get; set; }

        [JsonProperty(PropertyName = "series_type")]
        public int? SeriesType { get; set; }

        [JsonProperty(PropertyName = "match_seq_num")]
        public int MatchSequenceNumber { get; set; }

        [JsonProperty(PropertyName = "tower_status_radiant")]
        public UInt16 TowerStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "tower_status_dire")]
        public UInt16 TowerStatusDire { get; set; }

        [JsonProperty(PropertyName = "barracks_status_radiant")]
        public uint BarracksStatusRadiant { get; set; }

        [JsonProperty(PropertyName = "barracks_status_dire")]
        public uint BarracksStatusDire { get; set; }

        [JsonProperty(PropertyName = "first_blood_time")]
        public int FirstBloodTime { get; set; }

        [JsonProperty(PropertyName = "lobby_type")]
        public LobbyType LobbyType { get; set; }

        [JsonProperty(PropertyName = "leagueid")]
        public int LeagueId { get; set; }

        [JsonProperty(PropertyName = "game_mode")]
        public int GameMode { get; set; }

        [JsonProperty(PropertyName = "radiant_team_id")]
        public int RadiantTeamId { get; set; }

        [JsonProperty(PropertyName = "radiant_name")]
        public string RadiantName { get; set; }

        [JsonProperty(PropertyName = "radiant_team_complete")]
        public bool RadiantTeamComplete { get; set; }

        [JsonProperty(PropertyName = "dire_team_id")]
        public int DireTeamId { get; set; }

        [JsonProperty(PropertyName = "dire_name")]
        public string DireName { get; set; }

        [JsonProperty(PropertyName = "dire_team_complete")]
        public bool DireTeamComplete { get; set; }

        [JsonProperty(PropertyName = "players")]
        public List<Player> Players { get; set; }
    }
}
