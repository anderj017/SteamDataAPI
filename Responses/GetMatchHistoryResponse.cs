using System.Collections.Generic;
using Newtonsoft.Json;
using SteamWebAPIWrapper.Data;

namespace SteamWebAPIWrapper.Responses
{
    public class GetMatchHistoryResponse
    {
        [JsonProperty(PropertyName = "num_results")]
        public int NumResults;

        [JsonProperty(PropertyName = "total_results")]
        public int TotalResults;

        [JsonProperty(PropertyName = "results_remaining")] 
        public int ResultsRemaining;

        [JsonProperty(PropertyName = "matches")] 
        public List<Match> Matches;
    }
}
