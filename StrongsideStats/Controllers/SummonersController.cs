using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrongsideStats.Data;
using StrongsideStats.Data.DTOs;
using StrongsideStats.Services.Interfaces;

namespace StrongsideStats.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonersController : ControllerBase
    {
        private readonly IDbService _db;

        public SummonersController(IDbService db)
        {
            _db = db;
        }

        [HttpGet("by-riot-id")]
        public async Task<IActionResult> Get(string gameName, string tagLine)
        {
            var summoner = await _db.GetSummonerByNameAndTagAsync(gameName, tagLine);

            if (summoner == null)
            {
                return NotFound();
            }

            return Ok(summoner);
        }

        [HttpPost("update-summoner")]
        public async Task<IActionResult> UpdateSummoner([FromBody] SummonerDTO summonerDto)
        {
            Console.WriteLine(summonerDto.GameName);
            return Ok("20000");
        }
    }
}
