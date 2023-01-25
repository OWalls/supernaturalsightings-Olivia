using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace supernaturalsightings_olivia.Models
{
    public class ApplicationUser : IdentityUser
    {
        //[Column("DisplayName")]
        public string DisplayName { get; set; } = "";
        
    }
}
