using Microsoft.AspNetCore.Mvc;
using StrongsideStats.Data.Models;
using StrongsideStats.Services.Interfaces;

namespace StrongsideStats.Controllers
{
    [Route("/")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IRiotApiService _riot;
        private readonly IMappingService _mapper;
        private readonly IDbService _db;

        public HomeController(IRiotApiService riot, IMappingService mapper, IDbService db)
        {
            _riot = riot;
            _mapper = mapper;
            _db = db;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Home page");
        }

        [HttpGet("/summoner")]
        public async Task<IActionResult> GetSummoner(string gameName, string tagLine)
        {
            var summonerDto = await _db.GetSummonerByNameAndTagAsync(gameName, tagLine);

            if (summonerDto == null)
            {
                var account = await _riot.GetAccountAsync(gameName, tagLine);

                if (account == null)
                {
                    return BadRequest();
                }

                // check if puuid exists because if it does then the player changed names and Summoner needs to be updated.
                bool checkPuuid = await _db.PuuidExists(account.Puuid);
                if (checkPuuid)
                {
                    // update gameName, tagLine and return w/e is in db.
                    var updateSum = await _db.UpdateSummonerNameAsync(gameName, tagLine);
                    summonerDto = await _db.GetSummonerByNameAndTagAsync(gameName, tagLine);
                }
                else 
                {
                    // should only be reached if puuid, i.e. the player, does not exist at all in db and needs to be added for the first time.
                    var leagues = await _riot.GetLeaguesAsync(account.Puuid);
                    List<League> leaguesList = new List<League>();
                    foreach (var league in leagues)
                    {
                        leaguesList.Add(_mapper.MapLeague(league));
                    }
                    Summoner summoner = _mapper.MapSummoner(account);
                    summoner.Leagues = leaguesList;

                    var addSummoner = await _db.AddSummonerAsync(summoner);

                    summonerDto = await _db.GetSummonerByNameAndTagAsync(gameName, tagLine);
                }
            }

            return Ok(summonerDto);
        }

        // this will only be for testing purposes.
        [HttpGet("/allsummoners")]
        public async Task<IActionResult> GetAllSummoners()
        {
            var summoners = await _db.GetAllSummonersAsync();

            return Ok(summoners);
        }
    }
}
