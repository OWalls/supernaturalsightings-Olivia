using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System;
using supernaturalsightings_olivia.Models;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddSightingViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        public string City { get; set; }

        public string State { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }


        public AddSightingViewModel()
        {
            
        }

    }
}
