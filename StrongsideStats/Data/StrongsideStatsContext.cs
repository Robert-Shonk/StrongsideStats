using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StrongsideStats.Models.Entities;

namespace StrongsideStats.Data
{
    public class StrongsideStatsContext : DbContext
    {
        public StrongsideStatsContext (DbContextOptions<StrongsideStatsContext> options)
            : base(options)
        {
        }

        public DbSet<StrongsideStats.Models.Entities.SummonerEntity> SummonerEntity { get; set; } = default!;
    }
}
