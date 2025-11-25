namespace StrongsideStats.Data.Models
{
    public class League
    {
        public int Id { get; set; }
        public required string LeagueId { get; set; }
        public required string Puuid { get; set; }
        public required string QueueType { get; set; }
        public required string Tier { get; set; }
        public required string Rank { get; set; }
        public int LeaguePoints { get; set; }
        public int Wins { get; set; }
        public int Losses { get; set; }
        public bool HotStreak { get; set; }
        public bool Veteran { get; set; }
        public bool FreshBlood { get; set; }
        public bool Inactive { get;set; }

        public int SummonerId { get; set; }
        public Summoner Summoner { get; set; } = null!;
    }
}
