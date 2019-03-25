using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StopWatcher.Controllers
{
    public class PlansController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Plans()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details()
        {
            //TODO: I need to add a bunch of other "logic" here to add the item to a cart
            return RedirectToAction("Index", "Cart");
        }
    }
}