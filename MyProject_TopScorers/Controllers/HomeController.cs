using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using MyProject_TopScorers.Domain.Enums;
using MyProject_TopScorers.Domain.ViewModel;
using MyProject_TopScorers.Models;
using MyProject_TopScorers.Service.Interfaces;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject_TopScorers.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ITopScorers _topScorers;

        public HomeController(ILogger<HomeController> logger, ITopScorers topScorers)
        {
            _logger = logger;
            _topScorers = topScorers;
        }

        [Route("SA")]
        public async Task<IActionResult> ScorersSeriaA()
        {
            //if (HttpContext.Session.Keys.Contains("Loaded"))
            //    return View("Scorers", _topScorers.Players);
            _topScorers.Players = await _topScorers.GetTopScorers(WC.URL_SA, Leagues.SeriaA,WC.CURRENT_SEASON_SA);
            ViewBag.League = Leagues.SeriaA;
            //HttpContext.Session.SetString("Loaded", "True");
            return View("Scorers", _topScorers.Players);


        }

        [Route("EPL")]
        public async Task<IActionResult> ScorersEPL()
        {
            var response = await _topScorers.GetTopScorers(WC.URL_EPL, Leagues.EPL,WC.CURRENT_SEASON_EPL);
            ViewBag.League = Leagues.EPL;
            return View("Scorers", response);
        }

        //[HttpGet("Player/{name}")]
        [Route("Player/{name}/{league}")]
        public async Task<IActionResult> GetPlayer(string name, Leagues league)
        {
            var season_id = league == Leagues.EPL ? WC.SEASON_20_21_EPL : WC.SEASON_20_21_SA;
            var url = league == Leagues.EPL ? WC.URL_EPL_19_20 : WC.URL_SA_19_20;
            var playerStat2122 = await _topScorers.GetPlayerByName(name); // доп инфа про прошлые сезоны
            await _topScorers.GetTopScorers(url, league,season_id);
            var playerStat2021 = await _topScorers.GetPlayerByName(name,getOldStat: true);
            var viewModel = new PlayerViewModel()
            {
                infoPlayerSeason2021 = playerStat2021,
                infoPlayerSeason2122 = playerStat2122
            };
            return View("Player", viewModel);
        }

        //[HttpGet("Player/{id}")]
        //public async Task<IActionResult> GetPlayer(int id)
        //{
        //    var response = await _topScorers.GetPlayerById(id);
        //    return View("Player", response);
        //}
        public IActionResult Index()
        {
            return View();
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
