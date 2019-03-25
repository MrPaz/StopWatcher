using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StopWatcher.Controllers
{
    public class CheckoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string email)
        {
            Console.WriteLine("Processing an order from " + email);
            //TODO: Get a lot more info here, validate credit card + address, save it to a database

            return RedirectToAction("index", "receipt");
        }
    }
}