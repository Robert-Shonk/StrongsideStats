using System.Text.Json.Serialization;

namespace StrongsideStats.Data.DTOs
{
    public class AccountDTO
    {
        [JsonPropertyName("puuid")]
        public required string Puuid { get; set; }

        [JsonPropertyName("gameName")]
        public required string GameName {  get; set; }

        [JsonPropertyName("tagLine")]
        public required string TagLine { get; set; }
    }
}
