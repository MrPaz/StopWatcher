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
            ////If my database's positions table is empty, add mock data here:
            //if (!_context.Positions.Any())
            //{
            //    //_context.Exchanges.AddRange(MockExchangeData.exchanges);
            //    _context.Positions.AddRange(MockPositionData.positions);
            //    //_context.Securities.AddRange(MockSecurityData.securities);
            //    _context.SaveChanges();
            //}

            Data.User user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewData["securities"] = _context.Securities.Include(s => s.ExchangeSecurities).ThenInclude(es => es.Exchange).ToArray();

            //Instead of returning mock category data, return the DbContext's Categories property
            return View(_context
                .Positions
                .Include(p => p.Security)
                .ThenInclude(x => x.ExchangeSecurities)
                .ThenInclude(x => x.Exchange)
                .Where(p => p.UserID == user.Id));
        }



        [HttpPost]
        public async Task<IActionResult> Index(int exchangeid, string tickerid, double stopLoss, double unitsid)
        {
            User user = await _userManager.GetUserAsync(User);
            Security security = _context.Securities.First(x => x.Ticker == tickerid);

            StopOrder stopOrder = _context.StopOrders.FirstOrDefault(x => x.UserID == user.Id && x.SecurityID == security.ID && x.ExchangeID == exchangeid);

            if(stopOrder == null)
            {
                Position existingPosition = _context.Positions.FirstOrDefault(x => x.UserID == user.Id &&
                x.SecurityID == security.ID && x.ExchangeID == exchangeid);
                if (existingPosition == null)
                {
                    throw new ApplicationException(string.Format("User {0} doesn't have security {1}", user.Id, security.ID));
                }
                existingPosition.IsStop = true;

                stopOrder = new StopOrder();
                stopOrder.UserID = user.Id;
                stopOrder.IsStop = true;
                stopOrder.ExchangeID = exchangeid;
                stopOrder.SecurityID = security.ID;
                stopOrder.Units = unitsid;
                stopOrder.TradingPair = security.TradingPair;
                _context.StopOrders.Add(stopOrder);
            }

            stopOrder.StopPriceBTC = security.Ticker == "BTC" ? 1.0 : security.PxBTC * (1 - stopLoss / 100);
            stopOrder.StopPriceUSD = security.PxUSD * (1 - stopLoss / 100);
            stopOrder.StopPercent = stopLoss;
            await _context.SaveChangesAsync();
            //Security security = _context
            //    .Exchanges
            //    .Include(x => x.ExchangeSecurities)
            //    .ThenInclude(x => x.Security)
            //    .First(x => x.ID == exchangeid)
            //    .ExchangeSecurities.First(x => x.Security.Ticker == tickerid)
 
            return RedirectToAction("Index");
        }
    }
}