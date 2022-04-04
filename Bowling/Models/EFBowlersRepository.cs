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

        public Bowler CreateBowler(Bowler bowler)
        {
            _context.Add(bowler);
            _context.SaveChanges();
            return bowler;
        }

        public Bowler UpdateBowler(Bowler bowler)
        {
            Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == bowler.BowlerID);
            _context.Update(b);
            _context.SaveChanges();
            return bowler;
        }

        public void DeleteBowler(int id)
        {
            Bowler b = _context.Bowlers.FirstOrDefault(b => b.BowlerID == id);
            _context.Remove(b);
            _context.SaveChanges();
        }
    }
}
