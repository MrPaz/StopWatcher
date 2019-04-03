using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StopWatcher.Models;

namespace StopWatcher.Controllers
{
    public class HomeController : Controller
    {
        private string _myApiKey;
        private ILogger<HomeController> _logger;

        public HomeController(IConfiguration configuration, ILogger<HomeController> logger)
        {
            _myApiKey = configuration.GetValue<string>("myApiKey");
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Stop Watcher - Protect ya Neck & Lock in Profits!"; 

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

        public IActionResult Bittrex()
        {
            string testSuffix = "/public/getticker?market=USD-BTC";
            string endpoint = "https://api.bittrex.com/api/v1.1" + testSuffix /*_myApiKey*/;
            try
            {
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
                string response = httpClient.GetStringAsync(endpoint).Result;
                GetTickerResponse typedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetTickerResponse>(response);
                return View(typedReponse);
            }
            catch(Exception exception)
            {
                _logger.LogError(exception, exception.Message);
                return Content("We can't access the service right now!");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
