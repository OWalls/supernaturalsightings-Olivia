using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewViewModel
    {


        [Required(ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 15 characters long")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Tell us your weird experience!")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Review Comment must be longer than that")]
        public string ReviewComment { get; set; }

        [Required(ErrorMessage = "")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Pick a category")]
        [Display(Name = "ReviewTitle")]
        public string ReviewTitle { get; set; }


        public AddReviewViewModel()
        {
        }
   
        }
        
    }

