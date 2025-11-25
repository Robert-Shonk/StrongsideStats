namespace StrongsideStats.Data.Models
{
    public class Summoner
    {
        public int Id { get; set; }
        public required string Puuid { get; set; }
        public required string GameName { get; set; }
        public required string TagLine { get; set; }
        public List<League> Leagues { get; set; } = new List<League>();
    }
}
