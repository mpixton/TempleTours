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
        /// List of Parties associated with the Tour time.
        /// </summary>
        public List<Party> Parties { get; set; }
    }
}
