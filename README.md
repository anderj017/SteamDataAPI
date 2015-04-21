# SteamDataAPI
A C# Steam Web API Wrapper for retrieving e-sports data used by http://www.smartdotabetting.com

This wrapper is focussed on retrieving data from e-sports matches in an efficient way.

The following features are included as part of the library:

* Asyncronously waits 1 second between calls to the API as per the Fair Use Policy.
* GetNewMatches and GetAllMatches flattens the "pages" of data returned from GetMatchHistory for you.
* GetNewMatches returns only the matches in a league after a given match ID, this is very handy if your application needs to poll for new matches.
* GetActiveLeagueIds - This facilitates finding recently finished tournament matches (the GetMatchHistory argument "tournament_games_only" is broken).

<strong>API Key</strong>

To use this library you will need a Steam API Key:
http://steamcommunity.com/dev/apikey

<strong>References:</strong>

These references are available via NuGet.

    Newtonsoft.Json 
	System.Net.Http.Formatting (part of the Microsoft.AspNet.WebApi.Client package)
	
	
<strong>Future updates:</strong>

* Poll for new matches, firing an event when a new match is found
* Add games other than Dota 2.
