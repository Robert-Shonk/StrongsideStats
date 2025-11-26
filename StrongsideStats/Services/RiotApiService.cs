using StrongsideStats.Data.DTOs;
using StrongsideStats.Services.Interfaces;
using System.Text.Json;

namespace StrongsideStats.Services
{
    public class RiotApiService : IRiotApiService
    {
        private readonly HttpClient _client;
        private readonly IConfiguration _config;

        public RiotApiService(HttpClient client, IConfiguration config)
        {
            _client = client;
            _config = config;
        }

        public async Task<AccountDTO> GetAccountAsync(string gameName, string tagLine)
        {
            string url = $"{RiotApiUrls.ACCOUNT_URL}{gameName}/{tagLine}?api_key={_config["API_KEY"]}";

            var request = await _client.GetAsync(url);

            if (!request.IsSuccessStatusCode)
            {
                return null;
            }

            string content = await request.Content.ReadAsStringAsync();
            AccountDTO? accountDto = JsonSerializer.Deserialize<AccountDTO>(content);

            return accountDto;
        }

        public async Task<List<LeagueDTO>> GetLeaguesAsync(string puuid)
        {
            string url = $"{RiotApiUrls.LEAGUE_URL}{puuid}?api_key={_config["API_KEY"]}";

            var request = await _client.GetAsync(url);

            string content = await request.Content.ReadAsStringAsync();
            List<LeagueDTO>? leaguesDto = JsonSerializer.Deserialize<List<LeagueDTO>>(content);

            return leaguesDto;
        }
    }
}
