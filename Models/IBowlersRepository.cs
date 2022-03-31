using System;
using System.Linq;

namespace Bowling.Models
{
    //an interface is a temeplate for a class
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
