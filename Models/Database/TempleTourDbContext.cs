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

        public DbSet<Tour> Tours { get; set; }
    }
}
