using Newtonsoft.Json;

namespace SteamWebAPIWrapper.Data
{
    public class Player
    {
        [JsonProperty(PropertyName = "account_id")]
        public long AccountId { get; set; }

        [JsonProperty(PropertyName = "player_slot")]
        public uint PlayerSlot { get; set; }

        [JsonProperty(PropertyName = "hero_id")]
        public int HeroId { get; set; }

        [JsonProperty(PropertyName = "item_0")]
        public int Item0 { get; set; }

        [JsonProperty(PropertyName = "item_1")]
        public int Item1 { get; set; }

        [JsonProperty(PropertyName = "item_2")]
        public int Item2 { get; set; }

        [JsonProperty(PropertyName = "item_3")]
        public int Item3 { get; set; }

        [JsonProperty(PropertyName = "item_4")]
        public int Item4 { get; set; }

        [JsonProperty(PropertyName = "item_5")]
        public int Item5 { get; set; }

        [JsonProperty(PropertyName = "kills")]
        public int Kills { get; set; }

        [JsonProperty(PropertyName = "deaths")]
        public int Deaths { get; set; }

        [JsonProperty(PropertyName = "leaver_status")]
        public LeaverStatus LeaverStatus { get; set; }

        [JsonProperty(PropertyName = "gold")]       // Gold at the end of the match!
        public int Gold { get; set; }

        [JsonProperty(PropertyName = "last_hits")]
        public int LastHits { get; set; }

        [JsonProperty(PropertyName = "denies")]
        public int Denies { get; set; }

        [JsonProperty(PropertyName = "gold_per_min")]
        public int GoldPerMinute { get; set; }

        [JsonProperty(PropertyName = "xp_per_min")]
        public int XpPerMinute { get; set; }

        [JsonProperty(PropertyName = "gold_spent")]
        public int GoldSpent { get; set; }

        [JsonProperty(PropertyName = "hero_damage")]
        public int HeroDamage { get; set; }

        [JsonProperty(PropertyName = "tower_damage")]
        public int TowerDamage { get; set; }

        [JsonProperty(PropertyName = "hero_healing")]
        public int HeroHealing { get; set; }

        [JsonProperty(PropertyName = "level")]
        public int Level { get; set; }

        //[JsonProperty(PropertyName = "ability_upgrades")]
        //public List<AbilityUpgrade> AbilityUpgrades { get; set; }

        //[JsonProperty(PropertyName = "additional_units")]
        //public List<AditionalUnit> AditionalUnits { get; set; }


        // Live League Games!
        [JsonProperty(PropertyName = "team")]
        public TeamId TeamId { get; set; }
    }
}
