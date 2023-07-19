using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StrongsideStats.Data;
using StrongsideStats.Models;
using StrongsideStats.Models.DTOs;
using StrongsideStats.Models.Entities;
using StrongsideStats.Services.Interfaces;
using System.Diagnostics;

namespace StrongsideStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRiotAPIService _riotAPIService;
        private readonly StrongsideStatsContext _context;

        public HomeController(ILogger<HomeController> logger, IRiotAPIService riotAPIService, StrongsideStatsContext context)
        {
            _logger = logger;
            _riotAPIService = riotAPIService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Summoner(string summonerName)
        {
            SummonerDTO? summonerDto = await _riotAPIService.GetSummonerAsync(summonerName);
            if (summonerDto == null)
            {
                return View(null);
            }
            else
            {
                var summonerEntity = await _context.SummonerEntity.FirstOrDefaultAsync(s => s.Name == summonerName);

                if (summonerEntity == null)
                {
                    _context.Add(new SummonerEntity
                    {
                        SummonerId = summonerDto.id,
                        AccountId = summonerDto.accountId,
                        ProfileIconId = summonerDto.profileIconId,
                        RevisionDate = summonerDto.revisionDate,
                        Name = summonerDto.name,
                        Puuid = summonerDto.puuid,
                        SummonerLevel = summonerDto.summonerLevel
                    });

                    _context.SaveChanges();
                }
            }


            return View(summonerDto);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}