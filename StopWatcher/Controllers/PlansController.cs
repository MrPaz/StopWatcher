using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StopWatcher.Data;


namespace StopWatcher.Controllers
{
    public class PlansController : Controller
    {
        private ApplicationDbContext _context;

        //private UserManager<User> _userManager;

        public PlansController(ApplicationDbContext context)
        {
            this._context = context;
            //this._userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Plans()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Details(string button)
        {
            //if (button == "monthly")
            //{
            //    Cart cart = new Cart();
            //    cart.PlansID = 1;
            //    cart.UserID =   
            //}

            return RedirectToAction("Index", "Cart");
        }
    }
}