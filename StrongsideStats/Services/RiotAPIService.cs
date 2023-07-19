using StrongsideStats.Models.DTOs;
using StrongsideStats.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace StrongsideStats.Services
{
    public class RiotAPIService : IRiotAPIService
    {
        private readonly HttpClient _httpClient;

        private const string SUMMONER_URL = "https://na1.api.riotgames.com/lol/summoner/v4/summoners/by-name/";

        public RiotAPIService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SummonerDTO> GetSummonerAsync(string summonerName)
        {
            string url = SUMMONER_URL + summonerName + Secrets.RIOT_API_KEY;
            HttpResponseMessage message = await _httpClient.GetAsync(url);
            if (message.IsSuccessStatusCode)
            {
                string json = await message.Content.ReadAsStringAsync();
                SummonerDTO? summoner = JsonSerializer.Deserialize<SummonerDTO>(json);
                return summoner;
            }
            else
            {
                return null;
            }
        }
    }
}
