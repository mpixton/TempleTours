using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.Database
{
    /// <summary>
    /// Makes the abstract version of the DB concrete.
    /// </summary>
    public class EFTempleTourRepo : ITempleTourRepo
    {
        private TempleTourDbContext _context;

        public EFTempleTourRepo(TempleTourDbContext context)
        {
            _context = context;
        }

        // Allows querying the DbSet in LINQ.
        public IQueryable<Tour> Tours => _context.Tours;

        public IQueryable<Party> Parties => _context.Parties;
    }
}
