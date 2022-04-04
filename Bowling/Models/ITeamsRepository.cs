using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Models
{
    public interface ITeamsRepository
    {
        IQueryable<Team> Teams { get; }

        List<Team> GetTeams();
    }
}
