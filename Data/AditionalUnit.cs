using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class AditionalUnit
    {
        [JsonProperty(PropertyName = "unitname")]
        public string Name;

        [JsonProperty(PropertyName = "item_0")]
        public int Item0;

        [JsonProperty(PropertyName = "item_1")]
        public int Item1;

        [JsonProperty(PropertyName = "item_2")]
        public int Item2;

        [JsonProperty(PropertyName = "item_3")]
        public int Item3;

        [JsonProperty(PropertyName = "item_4")]
        public int Item4;

        [JsonProperty(PropertyName = "item_5")]
        public int Item5;
    }
}
