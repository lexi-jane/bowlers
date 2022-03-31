using System;
using System.Linq;

namespace Bowling.Models
{
    public interface IBowlersRepository
    {
        IQueryable<Bowler> Bowlers { get; }
    }
}
