using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace supernaturalsightings_olivia.Models
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string DisplayName { get; set; } = "";

        [PersonalData]
        public string Bio { get; set; } = "";
        
    }
}
