using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class AbilityUpgrade
    {
        [JsonProperty(PropertyName = "ability")]
        public int Ability;

        [JsonProperty(PropertyName = "time")]
        public int Time;

        [JsonProperty(PropertyName = "level")]
        public int Level;
    }
}
