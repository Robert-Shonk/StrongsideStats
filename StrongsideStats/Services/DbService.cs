using Microsoft.EntityFrameworkCore;
using StrongsideStats.Data;
using StrongsideStats.Data.DTOs;
using StrongsideStats.Data.Models;
using StrongsideStats.Services.Interfaces;
using System.Diagnostics;

namespace StrongsideStats.Services
{
    public class DbService : IDbService
    {
        private readonly StrongsideDbContext _context;

        public DbService(StrongsideDbContext context)
        {
            _context = context;
        }

        // this will only be for testing purposes.
        public async Task<List<Summoner>> GetAllSummonersAsync()
        {
            var summoners = await _context.Summoners.Include(s => s.Leagues).ToListAsync();

            return summoners;
        }

        public async Task<SummonerDTO> GetSummonerByNameAndTagAsync(string gameName, string tagLine)
        {
            var summoner = await _context.Summoners.Where(s => s.GameName == gameName && s.TagLine == tagLine).FirstOrDefaultAsync();
            if (summoner == null)
            {
                return null;
            }

            var leagues = await _context.Leagues.Where(l => l.SummonerId == summoner.Id).Select(l => new LeagueDTO
            {
                QueueType = l.QueueType,
                Tier = l.Tier,
                Rank = l.Rank,
                LeaguePoints = l.LeaguePoints,
                Wins = l.Wins,
                Losses = l.Losses,
                HotStreak = l.HotStreak,
                Veteran = l.Veteran,
                FreshBlood = l.FreshBlood,
                Inactive = l.Inactive
            }).ToListAsync();

            SummonerDTO summonerDto = new SummonerDTO
            {
                GameName = summoner.GameName,
                TagLine = summoner.TagLine,
                LeaguesDTO = leagues,
            };

            return summonerDto;
        }

        public async Task<int> AddSummonerAsync(Summoner summoner)
        {
            _context.Summoners.Add(summoner);
            await _context.SaveChangesAsync();

            return 201;
        }

        // 
        public async Task<bool> PuuidExists(string puuid)
        {
            var checkSummoner = await _context.Summoners.Where(s => s.Puuid == puuid).FirstOrDefaultAsync();

            if (checkSummoner == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public async Task<int> UpdateSummonerNameAsync(string gameName, string tagLine)
        {
            var summoner = await _context.Summoners.Where(s => s.GameName == gameName && s.TagLine == tagLine).FirstOrDefaultAsync();
            summoner.GameName = gameName;
            summoner.TagLine = tagLine;
            await _context.SaveChangesAsync();

            return 202;
        }
    }
}
