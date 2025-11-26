using StrongsideStats.Data.DTOs;

namespace StrongsideStats.Services.Interfaces
{
    public interface IRiotApiService
    {
        Task<AccountDTO> GetAccountAsync(string gameName, string tagLine);
        Task<List<LeagueDTO>> GetLeaguesAsync(string puuid);
    }
}
