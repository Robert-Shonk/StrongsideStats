using StrongsideStats.Models.DTOs;

namespace StrongsideStats.Services.Interfaces
{
    public interface IRiotAPIService
    {
        Task<SummonerDTO> GetSummonerAsync(string summonerName);
    }
}
