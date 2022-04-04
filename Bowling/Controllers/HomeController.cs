//----------------- HOME CONTROLLER WITHOUT REPOSITORIES -----------------//

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

        public HomeController(BowlersDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(string bowlingTeam)
        {

            List<Bowler> bowlers;
            if (bowlingTeam == null || bowlingTeam == "")
            {
                bowlers = _context.Bowlers
                   .Include(b => b.Team) //calling nested object not table
                   .OrderBy(b => b.BowlerLastName)
                   .ToList();
            }
            else
            {
                bowlers = _context.Bowlers
                    .Include(b => b.Team) //calling nested object not table
                    .Where(b => b.Team.TeamName == bowlingTeam)
                    .OrderBy(b => b.BowlerLastName)
                    .ToList();
            }

            return View(bowlers);
        }

        //CREATE
        public IActionResult CreateBowlerForm()
        {
            ViewBag.Teams = _context.Teams.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult CreateBowler([FromForm] Bowler bowler)
        {
            _context.Add(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        //UPDATE
        [Route("/Home/UpdateBowlerForm/{id}")]
        public IActionResult UpdateBowlerForm(int id)
        {
            ViewBag.Teams = _context.Teams.ToList();
            Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            return View(b);
        }

        [HttpPost]
        public IActionResult UpdateBowler([FromForm] Bowler bowler)
        {
            //Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == bowler.BowlerID);
            _context.Update(bowler);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        //DELETE
        [Route("/Home/DeleteBowler/{id}")]
        public IActionResult DeleteBowler(int id)
        {
            Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            _context.Bowlers.Remove(b);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}


//----------------- HOME CONTROLLER USING REPOSITORIES -----------------//

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
//    public class HomeController : Controller
//    {
//        private IBowlersRepository _repo { get; set; }
//        private ITeamsRepository _teamsRepo { get; set; }

//        public HomeController(IBowlersRepository temp, ITeamsRepository teamsRepo)
//        {
//            _repo = temp;
//            _teamsRepo = teamsRepo;
//        }

//        public IActionResult Index(string bowlingTeam)
//        {

//            // do i need this?
//            //var x = new BowlersViewModel
//            //{
//            //    Bowlers = _repo.Bowlers
//            //    .OrderBy(b => b.BowlerLastName)
//            //};
//            List<Bowler> bowlers;
//            if (bowlingTeam == null || bowlingTeam == "")
//            {
//                bowlers = _repo.Bowlers
//                   .Include(b => b.Team) //calling nested object not table
//                   .OrderBy(b => b.BowlerLastName)
//                   .ToList();
//            }
//            else
//            {
//                bowlers = _repo.Bowlers
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
//            ViewBag.Teams = _teamsRepo.GetTeams();
//            return View();
//        }

//        [HttpPost]
//        public IActionResult CreateBowler([FromForm] Bowler bowler)
//        {
//            _repo.CreateBowler(bowler);
//            return RedirectToAction("Index");
//        }

//        //UPDATE
//        public IActionResult UpdateBowlerForm(Bowler bowler)
//        {
//            return View(bowler);
//        }

//        [HttpPost]
//        public IActionResult UpdateBowler([FromForm] Bowler bowler)
//        {
//            _repo.UpdateBowler(bowler);
//            return RedirectToAction("Index");
//        }

//        public IActionResult DeleteBowler(int id)
//        {
//            _repo.DeleteBowler(id);
//            return RedirectToAction("Index");
//        }

//    }
//}
