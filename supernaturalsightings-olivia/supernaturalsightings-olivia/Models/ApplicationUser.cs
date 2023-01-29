using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace supernaturalsightings_olivia.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string DisplayName { get; set; } = "";

        public string Bio { get; set; } = "";

        public string Emoji { get; set; } = "";
        
    }
}
