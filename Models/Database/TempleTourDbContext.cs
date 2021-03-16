using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.Database
{
    public class TempleTourDbContext : DbContext
    {
        public TempleTourDbContext(DbContextOptions<TempleTourDbContext> options) : base(options)
        { }

        /// <summary>
        /// All Tours that exist in the DB.
        /// </summary>
        public DbSet<Tour> Tours { get; set; }

        /// <summary>
        /// All Tour Parties that exist in the DB.
        /// </summary>
        public DbSet<TourParty> Parties {get; set;}
    }
}
