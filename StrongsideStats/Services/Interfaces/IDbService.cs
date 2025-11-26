using StrongsideStats.Data.Models;
using StrongsideStats.Data.DTOs;

namespace StrongsideStats.Services.Interfaces
{
    public interface IDbService
    {
        Task<List<Summoner>> GetAllSummonersAsync();
        Task<SummonerDTO> GetSummonerByNameAndTagAsync(string gameName, string tagLine);
        Task<int> AddSummonerAsync(Summoner summoner);
        Task<bool> PuuidExists(string puuid);
        Task<int> UpdateSummonerNameAsync(string gameName, string tagLine);
    }
}
