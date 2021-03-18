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
    public class Party
    {
        /// <summary>
        /// Read-only database field. PK of the instance.
        /// </summary>
        [Key]
        public int TourPartyId { get; set; }

        /// <summary>
        /// Foreign Key of the Tour object associated with the Party. 
        /// Explicitly sets the FK relationship to Tour.
        /// </summary>
        [Required]
        public int TourId { get; set; }

        /// <summary>
        /// Tour object the TourParty is associated with.
        /// </summary>
        [Required]
        public Tour Tour { get; set; }

        /// <summary>
        /// Name of the party.
        /// </summary>
        [Required]
        public string PartyName { get; set; }

        /// <summary>
        /// Total number of people in the Party.
        /// </summary>
        [Required]
        [Display(Description = "How many people are in your party (including yourself)?")]
        public int PartySize { get; set; }

        /// <summary>
        /// Email address to reach the party leader at.
        /// </summary>
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        /// <summary>
        /// Optional. Phone number to reach the party leader.
        /// </summary>
        [Phone]
        public string PhoneNumber { get; set; }
    }
}
