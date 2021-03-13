using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.Database
{
    public interface ITempleTourRepo
    {
        IQueryable<Tour> Tours { get; }
    }
}
