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
            string testSuffix = "/public/getmarketsummaries";
            string endpoint = "https://api.bittrex.com/api/v1.1" + testSuffix /*_myApiKey*/;
            //https://api.bittrex.com/api/v1.1/account/getbalances?apikey=API_KEY
            //https://api.bittrex.com/api/v1.1/market/getopenorders?apikey=API_KEY&market=BTC-LTC
            try
            {
                System.Net.Http.HttpClient httpClient = new System.Net.Http.HttpClient();
                string response = await httpClient.GetStringAsync(endpoint);
                //GetMarketSummary typedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<GetMarketSummary>(response);
                var typedReponse = Newtonsoft.Json.JsonConvert.DeserializeObject<Newtonsoft.Json.Linq.JObject>(response);
                var marketSummaries = typedReponse.GetValue("result").ToArray();
                var markets = marketSummaries.Select(market => new GetMarketSummaryResult
                {
                    MarketName = market["MarketName"].ToString(),
                    High = float.Parse(market["High"].ToString()),
                    Low = float.Parse(market["Low"].ToString()),
                    Volume = float.Parse(market["Volume"].ToString()),
                    Last = float.Parse(market["Last"].ToString()),
                    BaseVolume = float.Parse(market["BaseVolume"].ToString()),
                    TimeStamp = DateTime.Parse(market["TimeStamp"].ToString()),
                    Bid = float.Parse(market["Bid"].ToString()),
                    Ask = float.Parse(market["Ask"].ToString()),
                    OpenBuyOrders = int.Parse(market["OpenBuyOrders"].ToString()),
                    OpenSellOrders = int.Parse(market["OpenSellOrders"].ToString()),
                    PrevDay = float.Parse(market["PrevDay"].ToString()),
                    Created = DateTime.Parse(market["Created"].ToString())
                }).ToArray();
                //now need to get this data into db !!!
                return Json(markets);
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
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
