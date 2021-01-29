using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CodingEvents.ViewModels
{
    public class AddEventViewModel
    {
        [Required (ErrorMessage = "Name is required.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 50 characters.")]
        public string Name { get; set; }

        [Required (ErrorMessage = "Please enter a description of your event.")]
        [StringLength(500, ErrorMessage = "Description is too long.")]
        public string Description { get; set; }

        [EmailAddress]
        public string ContactEmail { get; set; }

        [Required (ErrorMessage = "Location is required.")]
        public string Location { get; set; }

        [Range (0, 100000, ErrorMessage = "Cannot exceed 100,000.")]
        public int NumAttendees { get; set; }

        [Compare("IsTrue")]
        public bool Registration { get; set; }

        public bool IsTrue { get { return true; } }

        //This constructor is automatically part of this class
        //public AddEventViewModel() {}
    }
}
