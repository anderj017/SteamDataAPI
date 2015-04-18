using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public SteamWebAPIClient(string key)
        {
            _key = key;
            _lastRequest = new DateTime();
        }

        // ToDo: Add heroId, gameMode, skill, minPlayers, accountId, matchesRequested, tournamentOnly
        private GetMatchHistoryResponse GetMatchHistoryPaged(int leagueId = -1, int startAtMatch = -1)
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetMatchHistory/v001/?key={0}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key);

            if (leagueId != -1)
                sb.AppendFormat("&league_id={0}", leagueId);

            if (startAtMatch != -1)
                sb.AppendFormat("&start_at_match_id={0}", startAtMatch);

            return GetRequest<GetMatchHistoryResponse>(sb.ToString());
        }

        public List<Match> GetMatchHistory(int leagueId)
        {
            var ret = new List<Match>();

            var firstPage = GetMatchHistoryPaged(leagueId);

            ret.AddRange(firstPage.Matches);

            if (firstPage.ResultsRemaining > 0)
            {
                int last = ret.Last().MatchId - 1;          // get one lower than the last!

                while (true)
                {
                    var page = GetMatchHistoryPaged(leagueId, last);

                    ret.AddRange(page.Matches);

                    if (page.ResultsRemaining > 0)
                        last = ret.Last().MatchId - 1;
                    else
                        break;
                }
            }
            return ret;
        }

        public List<Match> GetMatchHistory(int leagueId, int startAtMatch)
        {
            var ret = new List<Match>();

            var firstPage = GetMatchHistoryPaged(leagueId, startAtMatch);

            ret.AddRange(firstPage.Matches);

            if (firstPage.ResultsRemaining > 0)
            {
                int last = ret.Last().MatchId;

                while (true)
                {
                    var page = GetMatchHistoryPaged(leagueId, last);

                    ret.AddRange(page.Matches);

                    if (page.ResultsRemaining > 0)
                        last = ret.Last().MatchId;
                    else
                        break;
                }
            }
            return ret;
        }

        public Match GetMatchDetails(int matchId)
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetMatchDetails/V001/?key={0}&match_id={1}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key, matchId);

            return GetRequest<Match>(sb.ToString());
        }

        public List<ScheduledLeagueGame> GetScheduledLeagueGames()
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetScheduledLeagueGames/V001/?key={0}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key);

            var games = GetRequest<ScheduledLeageGames>(sb.ToString());

            return games.Games;
        }

        public List<League> GetLeagueListing()
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetLeagueListing/v0001/?key={0}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key);

            var leagues = GetRequest<LeagueList>(sb.ToString());

            return leagues.Leagues;
        }

        public List<LiveLeagueGame> GetLiveLeagueGames()
        {
            const string url = "https://api.steampowered.com/IDOTA2Match_570/GetLiveLeagueGames/v0001/?key={0}";

            var sb = new StringBuilder();
            sb.AppendFormat(url, _key);

            var leagues = GetRequest<LiveLeagueGames>(sb.ToString());

            return leagues.Games;
        }

        private T GetRequest<T>(string url)
        {
            var diff = DateTime.Now.Subtract(_lastRequest);

            if (diff.TotalMilliseconds < 1100)
                Thread.Sleep((int) (1100 - diff.TotalMilliseconds));    // wait 1 sec between calls, as per fair use agreement.

            _lastRequest = DateTime.Now;

            string json = "";
            bool success = false;

            while (!success)
            {
                try
                {
                    json = new WebClient().DownloadString(url);
                    success = true;
                }
                catch (Exception)
                {
                    Thread.Sleep(5000);
                }
            }

            var ret = Task.Factory.StartNew(() => JsonConvert.DeserializeObject<Response<T>>(json));

            return ret.Result.Result;
        }

        public List<int> GetActiveLeagueIds()
        {
            var liveGames = GetLiveLeagueGames();
            var scheduledGames = GetScheduledLeagueGames();

            var liveLeagues = liveGames.Select(x => x.LeagueId);
            var scheduledLeagues = scheduledGames.Select(x => x.LeagueId);

            return liveLeagues.Union(scheduledLeagues).Distinct().ToList();
        }
    }
}
