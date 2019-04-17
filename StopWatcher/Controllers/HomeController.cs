using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StopWatcher.Data;
using StopWatcher.Models;
using StopWatcher.Services;

namespace StopWatcher.Controllers
{
    public class HomeController : Controller
    {
        private string _myApiKey;
        private ILogger<HomeController> _logger;
        private BittrexService _bittrexService;
        private ApplicationDbContext _context;
        private IConfiguration _configuration;
        private UserManager<User> _userManager;

        public HomeController(ApplicationDbContext context, IConfiguration configuration,
            ILogger<HomeController> logger, BittrexService bittrexService, UserManager<User> userManager)
        {
            _context = context;
            _configuration = configuration;
            _myApiKey = configuration.GetValue<string>("myApiKey");
            _logger = logger;
            _bittrexService = bittrexService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            ViewBag.Homepage = true;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Protect ya Neck & Lock in Profits!"; 

            return View();
        }

        public IActionResult Contact()
        {
            //ViewData["Message"] = "Contact: support@stopwatcher.io";

            return View();
        }

        public IActionResult Plans()
        {
            return View();
        }

        public async Task<IActionResult> Bittrex()
        {
            try
            {
                if (this.User.Identity.IsAuthenticated)
                {
                    string username = this.User.Identity.Name;
                    //GetCurrenciesResult[] currencies = await _bittrexService.GetCurrencies();
                    //return Json(currencies);
                }
                else
                {
                    return Forbid();
                }

                GetMarketSummaryResult[] markets = await _bittrexService.GetMarketSummaries();
                return Json(markets);
                //GetBalancesResult[] balances = await _bittrexService.GetBalances("matt@matt.com");
                //return Json(balances);
                //GetOpenOrdersResult[] openOrders = await _bittrexService.GetOpenOrders("matt@matt.com");
                //return Json(openOrders);
            }
            catch (Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return Content("We can't access the service right now!");
            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [Authorize]
        public async  Task<IActionResult> UserBalance()
        {
            var balanceResult = await _bittrexService.GetBalances(User.Identity.Name, _configuration.GetValue<string>("Bittrex:Key"), _configuration.GetValue<string>("Bittrex:Secret"));
            return Json(balanceResult);
            
        }
    }
}
