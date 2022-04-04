using System;
using System.Collections.Generic;
using System.Linq;

namespace Bowling.Models
{
    public class EFTeamsRepository : ITeamsRepository
    {
        private readonly BowlersDbContext _context;
        public EFTeamsRepository(BowlersDbContext context)
        {
            _context = context;
        }

        public IQueryable<Team> Teams => _context.Teams;

        public List<Team> GetTeams()
        {
            return Teams.ToList();
        }
    }
}
