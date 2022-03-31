using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Bowling.Models;
using Microsoft.EntityFrameworkCore;

namespace Bowling.Controllers
{
    public class HomeController : Controller
    {
        private BowlersDbContext _context { get; set; }


        public HomeController(BowlersDbContext temp)
        {
            _context = temp;
        }

        public IActionResult Index()
        {
            var blah = _context.Bowlers
                .ToList();

            return View(blah);
        }

    }
}
