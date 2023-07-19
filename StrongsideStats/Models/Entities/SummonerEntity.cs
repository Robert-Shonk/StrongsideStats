namespace StrongsideStats.Models.Entities
{
    public class SummonerEntity
    {
        public int Id { get; set; }
        public string? AccountId { get; set; }
        public int ProfileIconId { get; set; }
        public long RevisionDate { get; set; }
        public string? Name { get; set; }
        public string? SummonerId { get; set; }
        public string? Puuid { get; set; }
        public long SummonerLevel { get; set; }
    }
}
