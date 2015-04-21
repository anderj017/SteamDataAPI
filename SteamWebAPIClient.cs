using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SteamWebAPIWrapper.Data;
using SteamWebAPIWrapper.Responses;

namespace SteamWebAPIWrapper
{
    public class SteamWebAPIClient
    {
        private string _key;
        private DateTime _lastRequest;
        private HttpClient _webClient;

        private const string BaseAddress = "https://api.steampowered.com/IDOTA2Match_570/";

        public SteamWebAPIClient(string key)
        {
            _key = key;
            _lastRequest = new DateTime();
            _webClient = new HttpClient { BaseAddress = new Uri(BaseAddress) };
        }

        private Task<GetMatchHistoryResponse> GetMatchHistoryPaged(int? leagueId = null, int? startAtMatch = null)
        {
            const string url = "GetMatchHistory/v001/?key={0}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key);

            if (leagueId != null)
                sb.AppendFormat("&league_id={0}", leagueId);

            if (startAtMatch != null)
                sb.AppendFormat("&start_at_match_id={0}", startAtMatch);

            return GetRequest<GetMatchHistoryResponse>(sb.ToString());
        }
        
        public async Task<List<Match>> GetNewMatches(int leagueId, int lastSeenMatchId = 0)
        {
            var ret = new List<Match>();

            var firstPage = await GetMatchHistoryPaged(leagueId);

            if (firstPage.Matches.Any(x => x.MatchId < lastSeenMatchId))      // don't need to go to next page!
                return firstPage.Matches.Where(x => x.MatchId > lastSeenMatchId).ToList();

            if (firstPage.ResultsRemaining > 0)
            {
                int resultsRemaining = firstPage.ResultsRemaining;
                int lastMatchId = firstPage.Matches.Last().MatchId - 1;       // query one below the last one returned

                while (resultsRemaining > 0)
                {
                    var page = await GetMatchHistoryPaged(leagueId, lastMatchId);

                    ret.AddRange(firstPage.Matches.Where(x => x.MatchId > lastSeenMatchId));
                    lastMatchId = page.Matches.Last().MatchId - 1;           // as above

                    if (page.Matches.Any(x => x.MatchId < lastSeenMatchId)) 
                        break;

                    resultsRemaining = page.ResultsRemaining;
                }
            }

            return ret;
        }

        public async Task<List<Match>> GetAllMatches(int leagueId)
        {
            var ret = new List<Match>();

            var firstPage = await GetMatchHistoryPaged(leagueId);

            ret.AddRange(firstPage.Matches);

            if (firstPage.ResultsRemaining > 0)
            {
                int last = ret.Last().MatchId - 1;          // get one lower than the last as the argument for the next page

                while (true)
                {
                    var page = await GetMatchHistoryPaged(leagueId, last);

                    ret.AddRange(page.Matches);

                    if (page.ResultsRemaining > 0)
                        last = ret.Last().MatchId - 1;      // as above
                    else
                        break;
                }
            }
            return ret;
        }

        public Task<Match> GetMatchDetails(int matchId)
        {
            const string url = "GetMatchDetails/V001/?key={0}&match_id={1}";

            return GetRequest<Match>(string.Format(url, _key, matchId));
        }

        public async Task<List<ScheduledLeagueGame>> GetScheduledLeagueGames()
        {
            const string url = "GetScheduledLeagueGames/V001/?key={0}";

            var games = await GetRequest<ScheduledLeageGames>(string.Format(url, _key));

            return games.Games;
        }

        public async Task<List<League>> GetLeagueListing()
        {
            const string url = "GetLeagueListing/v0001/?key={0}";

            var leagues = await GetRequest<LeagueList>(string.Format(url, _key));

            return leagues.Leagues;
        }

        public async Task<List<LiveLeagueGame>> GetLiveLeagueGames()
        {
            const string url = "GetLiveLeagueGames/v0001/?key={0}";

            var leagues = await GetRequest<LiveLeagueGames>(string.Format(url, _key));

            return leagues.Games;
        }

        private async Task<T> GetRequest<T>(string url)
        {
            var diff = DateTime.Now.Subtract(_lastRequest);

            if (diff.TotalMilliseconds < 1100)
                Thread.Sleep((int) (1100 - diff.TotalMilliseconds));    // wait 1 sec between calls, as per fair use agreement.

            _lastRequest = DateTime.Now;

            string json = "";

            // Ocassionally the request returns 503 because the server thinks we made too many requests
            // this simply tries 3 times, waiting progressively longer // ToDo: Could be improved upon?

            for (int i = 1; i <= 3; i++)
            {
                try
                {
                    json = await _webClient.GetStringAsync(url);
                    break;
                }
                catch (Exception e)
                {
                    
                    if (i == 3)
                        throw;
                    // can't await in catch block (wait for next C# version!)
                }
                await Task.Delay(i * 5000);
            }
            
            var ret = await Task.Factory.StartNew(() => JsonConvert.DeserializeObject<SteamAPIResponse<T>>(json));

            return ret.Result;
        }

        public async Task<List<int>> GetActiveLeagueIds()
        {
            var liveGames = await GetLiveLeagueGames();
            var scheduledGames = await GetScheduledLeagueGames();

            var liveLeagues = liveGames.Select(x => x.LeagueId);
            var scheduledLeagues = scheduledGames.Select(x => x.LeagueId);

            return liveLeagues.Union(scheduledLeagues).Distinct().ToList();
        }
    }
}
