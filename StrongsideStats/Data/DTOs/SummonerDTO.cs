using StrongsideStats.Data.Models;

namespace StrongsideStats.Data.DTOs
{
    public class SummonerDTO
    {
        public required string GameName { get; set; }
        public required string TagLine { get; set; }
        public List<LeagueDTO> LeaguesDTO { get; set; } = new List<LeagueDTO>();
    }
}
