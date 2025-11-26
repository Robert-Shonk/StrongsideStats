using StrongsideStats.Data.DTOs;
using StrongsideStats.Data.Models;
using StrongsideStats.Services.Interfaces;

namespace StrongsideStats.Services
{
    public class MappingService : IMappingService
    {
        public Summoner MapSummoner(AccountDTO accountDto)
        {
            Summoner summoner = new Summoner
            {
                Puuid = accountDto.Puuid,
                GameName = accountDto.GameName,
                TagLine = accountDto.TagLine
            };

            return summoner;
        }

        public League MapLeague(LeagueDTO leagueDto)
        {
            League league = new League
            {
                LeagueId = leagueDto.LeagueId,
                Puuid = leagueDto.Puuid,
                QueueType = leagueDto.QueueType,
                Tier = leagueDto.Tier,
                Rank = leagueDto.Rank,
                LeaguePoints = leagueDto.LeaguePoints,
                Wins = leagueDto.Wins,
                Losses = leagueDto.Losses,
                HotStreak = leagueDto.HotStreak,
                Veteran = leagueDto.Veteran,
                FreshBlood = leagueDto.FreshBlood,
                Inactive = leagueDto.Inactive,
            };

            return league;
        }
    }
}
