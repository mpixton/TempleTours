using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

/// TODO: talk with team about adding a max number of people in appt.
namespace TempleTours.Models
{
    /// <summary>
    /// Model for a Tour instance of the temple. Contains the Date and Time of the Tour 
    /// as well as the list of Tourists for the Tour.
    /// </summary>
    public class Tour
    {
        /// <summary>
        /// Read only database field. PK of the Tour.
        /// </summary>
        [Key]
        public int TourId { get; set; }

        /// <summary>
        /// Date and Time of the Tour.
        /// </summary>
        [Required]
        public DateTime TourTime { get; set; }

        /// <summary>
        /// List of Tourists attending the Tour. Creates a one to many relationship between the entities. 
        /// TourParty will have a FK field with the PK of the Tour instance they are attending.
        /// </summary>
        public List<TourParty> Parties { get; set; }

        /// TODO: add a property that returns the size of all parties for this slot.

        /// <summary>
        /// Adds a party to the Tour Time.
        /// </summary>
        /// <param name="party">TourParty instance to add to the list of attending Tour Parties.</param>
        /// 
        public void AddTourist (TourParty party)
        {
            Parties.Add(party);
        }
    }
}
