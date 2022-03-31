using System;
using System.Linq;

namespace Bowling.Models
{
    public class EFBowlersRepository : IBowlersRepository
    {
        private BowlersDbContext _context { get; set; }

        public EFBowlersRepository (BowlersDbContext temp)
        {
            _context = temp;
        }
        public IQueryable<Bowler> Bowlers => _context.Bowlers;
    }
}
