using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models
{
    /// <summary>
    /// Model for a group of people attending a Tour at the temple.
    /// </summary>
    public class TourParty
    {
        /// <summary>
        /// Read-only database field. PK of the instance.
        /// </summary>
        [Key]
        public int TourPartyId { get; set; }

        /// <summary>
        /// First name of the person whose party it is.
        /// </summary>
        [Required]
        public string FirstName { get; set; }

        /// <summary>
        /// Last name of the person whose party it is.
        /// </summary>
        [Required]
        public string LastName { get; set; }

        /// <summary>
        /// Total number of people in the Party.
        /// </summary>
        [Required]
        [Display(Description = "How many people are in your party (including yourself)?")]
        public int PartySize { get; set; }
    }
}
