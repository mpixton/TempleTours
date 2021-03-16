using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TempleTours.Models.ViewModels
{
    public class SignUpViewModel
    {
        /// <summary>
        /// Tour object that the party is trying to sign up for.
        /// </summary>
        public Tour Tour { get; set; }

        /// <summary>
        /// Party's details to input to sign up for the Tour instance.
        /// </summary>
        public TourParty Party { get; set; }
    }
}
