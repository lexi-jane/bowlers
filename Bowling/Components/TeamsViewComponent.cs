using System;
using System.Linq;
using Bowling.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bowling.Components
{
    public class TeamsViewComponent : ViewComponent
    {
        private IBowlersRepository repo { get; set; }

        public TeamsViewComponent(IBowlersRepository temp)
        {
            repo = temp;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedTeams = RouteData?.Values["bowlingTeam"];

            var teams = repo.Bowlers
                .Include(b => b.Team)
                .Select(b => b.Team.TeamName)
                .Distinct()
                .OrderBy(b => b);
            return View(teams);

        }
    }
}
