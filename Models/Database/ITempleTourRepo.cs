using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.Database
{
    /// <summary>
    /// Decouples the database from the implementation of the database. Essentially abstracts away the DB layer.
    /// </summary>
    public interface ITempleTourRepo
    { 
        IQueryable<Tour> Tours { get; }

        IQueryable<Party> Parties { get; }
    }
}
