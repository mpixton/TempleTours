using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.Database
{
    public class EFTempleTourRepo : ITempleTourRepo
    {
        private TempleTourDbContext _context;

        public EFTempleTourRepo(TempleTourDbContext context)
        {
            _context = context;
        }

        public IQueryable<Tour> Tours => _context.Tours;
    }
}
