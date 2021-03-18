using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.ViewModels
{
    /// <summary>
    /// Allows us to get information from the user without breaking validation.
    /// </summary>
    public class SignUpViewModel
    {
        /// <summary>
        /// Foreign Key of the Tour object associated with the Party. 
        /// Explicitly sets the FK relationship to Tour.
        /// </summary>
        [Required]
        public int TourId { get; set; }

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
