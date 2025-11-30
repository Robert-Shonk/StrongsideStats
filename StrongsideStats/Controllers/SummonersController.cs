using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StrongsideStats.Data;
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
    }
}
