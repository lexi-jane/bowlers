using System;
using Microsoft.EntityFrameworkCore;

namespace Bowling.Models
{
    public class BowlersDbContext : DbContext
    {
        public BowlersDbContext(DbContextOptions<BowlersDbContext> options)
            : base(options)
        {

        }

        public DbSet<Bowler> Bowlers { get; set; }
        //public virtual DbSet<Bowler> Bowlers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseMySql("Data Source = ")
        //    }
        //}

    }
}
