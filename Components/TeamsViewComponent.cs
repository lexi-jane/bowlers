using System;
using System.Linq;
using Bowling.Models;
using Microsoft.AspNetCore.Mvc;

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
            var types = repo.Bowlers
                .Select(x => x.TeamID)
                .Distinct()
                .OrderBy(x => x);
            return View();
        }
    }
}
