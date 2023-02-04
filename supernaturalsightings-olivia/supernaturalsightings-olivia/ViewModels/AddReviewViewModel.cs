using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewViewModel
    {


        [Required(ErrorMessage = "Display Name is required!")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Display Name must be between 3 and 15 characters long")]
        [Display(Name = "DisplayName")]
        public string DisplayName { get; set; }

        [Required(ErrorMessage = "Tell us your weird experience!")]
        [StringLength(1000, MinimumLength = 3, ErrorMessage = "Review Comment must be longer than that")]
        public string ReviewComment { get; set; }

        [Required()] //Removed ErrorMessage = "" -Tanya
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Pick a category")]
        [Display(Name = "ReviewTitle")]
        public string ReviewTitle { get; set; }

        public int Rating { get; set; }


        public AddReviewViewModel()
        {
        }

        public override bool Equals(object? obj)
        {
            return Equals(obj as AddReviewViewModel);
        }

        public bool Equals(AddReviewViewModel? other)
        {
            return other is not null &&
                   DisplayName == other.DisplayName &&
                   ReviewComment == other.ReviewComment &&
                   ReviewTitle == other.ReviewTitle;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(DisplayName, ReviewComment, ReviewTitle);
        }
    }

}
