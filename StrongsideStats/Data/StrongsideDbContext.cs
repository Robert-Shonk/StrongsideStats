using Microsoft.EntityFrameworkCore;
using StrongsideStats.Data.Models;

namespace StrongsideStats.Data
{
    public class StrongsideDbContext : DbContext
    {
        public DbSet<Summoner> Summoners { get; set; }
        public DbSet<League> Leagues { get; set; }

        public StrongsideDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
