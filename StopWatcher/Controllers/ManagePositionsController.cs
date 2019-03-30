using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StopWatcher.Data;

namespace StopWatcher.Controllers
{
    public class ManagePositionsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        

        public ManagePositionsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        }
        [Authorize]
        public IActionResult Index()
        {
            //If my database's positions table is empty, add mock data here:
            if (!_context.Positions.Any())
            {
                _context.Positions.AddRange(MockPositionData.positions);
                //_context.Exchanges.AddRange(MockPositionData.Exchanges);
                _context.Securities.AddRange(MockSecurityData.security);
                _context.SaveChanges();
            }

            Data.User user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewData["securities"] = _context.Securities.Include(s => s.ExchangeSecurities).ThenInclude(es => es.Exchange).ToArray();

            //Instead of returning mock category data, return the DbContext's Categories property
            return View(_context.Positions.Include(p => p.Security).Where(p => p.UserID == user.Id));
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}