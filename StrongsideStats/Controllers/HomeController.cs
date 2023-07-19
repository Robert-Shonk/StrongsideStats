using Microsoft.AspNetCore.Mvc;
using StrongsideStats.Models;
using StrongsideStats.Models.DTOs;
using StrongsideStats.Services.Interfaces;
using System.Diagnostics;

namespace StrongsideStats.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRiotAPIService _riotAPIService;

        public HomeController(ILogger<HomeController> logger, IRiotAPIService riotAPIService)
        {
            _logger = logger;
            _riotAPIService = riotAPIService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Summoner(string summonerName)
        {
            SummonerDTO? summoner = await _riotAPIService.GetSummonerAsync(summonerName);

            return View(summoner);
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