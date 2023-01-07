using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
namespace supernaturalsightings_olivia.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // Remember me feature
        [Display(Name = "Remember Me")]
        public bool RememberMe { get; set; }
    }
}
