using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StopWatcher.Controllers
{
    public class StopWatcherController : Controller
    {
        //private XmlDataContext _xmlDataContext;

        //public StopWatcherController(ILogger<StopWatcherController> logger, XmlDataContext xmlDataContext)
        //{
        //    _xmlDataContext = xmlDataContext;
        //    logger.Log(LogLevel.Information, "Shopping List Controller Constructed");
        //}

        public IActionResult Index()
        {
            return View();
        }
    }
}