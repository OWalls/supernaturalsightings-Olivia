using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewCategoryViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 15 characters long")]
        [Display(Name = "Username")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Tell us your weird experience!")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Description must be longer than that")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Pick a category")]
        [Display(Name = "Category")]
        public string Category { get; set; }
    }

}
