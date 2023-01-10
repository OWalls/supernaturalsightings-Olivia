using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewCategoryViewModel
    {
        [Required(ErrorMessage = "Username is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 20 characters long")]
        public string UserName { get; set; }
    }
}
