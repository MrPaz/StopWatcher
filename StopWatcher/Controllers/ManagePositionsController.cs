using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using StopWatcher.Data;
using StopWatcher.Models;

namespace StopWatcher.Controllers
{
    public class ManagePositionsController : Controller
    {
        private ApplicationDbContext _context;
        private UserManager<User> _userManager;
        private readonly string _myApiKey;
        private ILogger<ManagePositionsController> _logger;

        public ManagePositionsController(ApplicationDbContext context, UserManager<User> userManager, 
            IConfiguration configuration, ILogger<ManagePositionsController> logger)
        {
            this._context = context;
            this._userManager = userManager;
            _myApiKey = configuration.GetValue<string>("myApiKey");
            _logger = logger;
        }

        [HttpPost]
        public async Task<IActionResult> Index(int positionid, int exchangeid, 
            string tickerid, decimal stoploss, decimal unitsid)
        {
            User user = await _userManager.GetUserAsync(User);
            Position position = _context.Positions.First(x => x.ID == positionid);

            StopOrder stopOrder = position.StopOrders.FirstOrDefault();

            if(stopOrder == null)
            {
                Position existingPosition = _context.Positions
                    .Include(x => x.Security)
                    .Include(x => x.StopOrders)
                    .FirstOrDefault(x => x.UserID == user.Id && x.ID == position.ID);
                if (existingPosition == null)
                {
                    throw new ApplicationException(string.Format("User {0} doesn't have position {1}",
                        user.Id, position.ID));
                }
                existingPosition.IsStop = true;
                stopOrder = new StopOrder
                {
                    //UserID = user.Id,
                    //PositionID = positionid,
                    Units = unitsid
                };
                position.StopOrders.Add(stopOrder);
            }

            stopOrder.StopPriceBTC = position.Security.Ticker == "BTC" ? 
                (decimal)1.00 : position.Security.PxBTC * (1 - stoploss / (decimal)100);
            stopOrder.StopPriceUSD = position.Security.PxUSD * (1 - (stoploss / 100));

            stopOrder.StopPercent = stoploss;
            await _context.SaveChangesAsync();
            //Security security = _context
            //    .Exchanges
            //    .Include(x => x.ExchangeSecurities)
            //    .ThenInclude(x => x.Security)
            //    .First(x => x.ID == exchangeid)
            //    .ExchangeSecurities.First(x => x.Security.Ticker == tickerid)
 
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult Index()
        {
            //If my database's positions table is empty, add mock data here:
            if (!_context.Positions.Any())
            {
                //_context.Exchanges.AddRange(MockExchangeData.exchanges);
                //_context.Securities.AddRange(MockSecurityData.securities);
                _context.Positions.AddRange(MockPositionData.positions);
                _context.SaveChanges();
            }

            Data.User user = _userManager.FindByNameAsync(User.Identity.Name).Result;
            ViewData["securities"] = _context.Securities
                .Include(s => s.ExchangeSecurities)
                .ThenInclude(es => es.Exchange).ToArray();

            //Instead of returning mock category data, return the DbContext's Categories property
            return View(_context
                .Positions
                //.Include(p => p.Security)
                //.ThenInclude(x => x.ExchangeSecurities)
                .Include(x => x.Exchange)
                .Where(p => p.UserID == user.Id));
        }
    }
}