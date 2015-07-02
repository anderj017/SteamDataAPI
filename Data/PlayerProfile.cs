using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class PlayerProfile
    {
        [JsonProperty(PropertyName = "steamid")]
        public long SteamId { get; set; }
                
        [JsonProperty(PropertyName = "communityvisibilitystate")]
        public int Communityvisibilitystate { get; set; }

        [JsonProperty(PropertyName = "profilestate")]
        public int Profilestate { get; set; }

        [JsonProperty(PropertyName = "personaname")]
        public string Personaname { get; set; }

        [JsonProperty(PropertyName = "lastlogoff")]
        public int LastLogoff { get; set; }

        [JsonProperty(PropertyName = "profileurl")]
        public string ProfileUrl { get; set; }

        // Todo: Add support for avatars

        [JsonProperty(PropertyName = "personastate")]
        public int PersonaState { get; set; }
    }
}
