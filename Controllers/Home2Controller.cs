//using System;
//using System.Collections.Generic;
//using System.Diagnostics;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Extensions.Logging;
//using Bowling.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Bowling.Controllers
//{
//    public class Home2Controller : Controller
//    {
//        private BowlersDbContext _context { get; set; }

//        public Home2Controller(BowlersDbContext context)
//        {
//            _context = context;
//        }

//        public IActionResult Index(string bowlingTeam)
//        {

//            List<Bowler> bowlers;
//            if (bowlingTeam == null || bowlingTeam == "")
//            {
//                bowlers = _context.Bowlers
//                   .Include(b => b.Team) //calling nested object not table
//                   .OrderBy(b => b.BowlerLastName)
//                   .ToList();
//            }
//            else
//            {
//                bowlers = _context.Bowlers
//                    .Include(b => b.Team) //calling nested object not table
//                    .Where(b => b.Team.TeamName == bowlingTeam)
//                    .OrderBy(b => b.BowlerLastName)
//                    .ToList();
//            }

//            return View(bowlers);
//        }

//        //CREATE
//        public IActionResult CreateBowlerForm()
//        {
//            ViewBag.Teams = _context.Teams.ToList();
//            return View();
//        }

//        [HttpPost]
//        public IActionResult CreateBowler([FromForm] Bowler bowler)
//        {
//            _context.Add(bowler);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        //UPDATE
//        [Route("UpdateBowlerForm/{id}")]
//        public IActionResult UpdateBowlerForm(int id)
//        {
//            return View(id);
//        }

//        [HttpPost]
//        public IActionResult UpdateBowler([FromForm] Bowler bowler)
//        {
//            //Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == bowler.BowlerID);
//            _context.Update(bowler);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }

//        public IActionResult DeleteBowler(int id)
//        {
//            Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
//            _context.Bowlers.Remove(b);
//            _context.SaveChanges();
//            return RedirectToAction("Index");
//        }

//    }
//}
