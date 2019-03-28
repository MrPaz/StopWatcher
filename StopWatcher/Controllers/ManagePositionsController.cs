using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StopWatcher.Data;

namespace StopWatcher.Controllers
{
    public class ManagePositionsController : Controller
    {
        private ApplicationDbContext _context;

        public ManagePositionsController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            //If my database's categories table is empty, add mock data here:
            if (!_context.Positions.Any())
            {
                _context.Positions.AddRange(MockPositionData.positions);
                _context.SaveChanges();
            }

            //Instead of returning mock category data, return the DbContext's Categories property
            return View(_context.Positions);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}