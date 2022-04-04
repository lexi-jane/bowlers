using System;
using System.Linq;

namespace Bowling.Models
{
    //an interface is a temeplate for a class
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }

        Bowler CreateBowler(Bowler bowler);
        Bowler UpdateBowler(Bowler bowler);
        void DeleteBowler(int id);
    }
}
