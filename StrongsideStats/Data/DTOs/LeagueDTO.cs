using System.Text.Json.Serialization;

namespace StrongsideStats.Data.DTOs
{
    public class LeagueDTO
    {
        [JsonPropertyName("leagueId")]
        public string? LeagueId { get; set; }

        [JsonPropertyName("puuid")]
        public string? Puuid { get; set; }

        [JsonPropertyName("queueType")]
        public required string QueueType { get; set; }

        [JsonPropertyName("tier")]
        public required string Tier { get; set; }

        [JsonPropertyName("rank")]
        public required string Rank { get; set; }

        [JsonPropertyName("leaguePoints")]
        public int LeaguePoints { get; set; }

        [JsonPropertyName("wins")]
        public int Wins { get; set; }

        [JsonPropertyName("losses")]
        public int Losses { get; set; }

        [JsonPropertyName("hotStreak")]
        public bool HotStreak { get; set; }

        [JsonPropertyName("veteran")]
        public bool Veteran { get; set; }

        [JsonPropertyName("freshBlood")]
        public bool FreshBlood { get; set; }

        [JsonPropertyName("inactive")]
        public bool Inactive { get; set; }
    }
}
