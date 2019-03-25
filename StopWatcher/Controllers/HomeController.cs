using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StopWatcher.Models;

namespace StopWatcher.Controllers
{
    public class HomeController : Controller
    {        
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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
