using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StopWatcher.Controllers
{
    public class ManagePositionsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}