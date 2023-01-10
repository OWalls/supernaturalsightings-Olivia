using Microsoft.AspNetCore.Mvc.Rendering;
using supernaturalsightings_olivia.Models;
using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewViewModel
    {

        [Required(ErrorMessage = "Username is required.")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 50 characters")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(500, ErrorMessage = "Description too long!")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public int CategoryId { get; set; }

        public List<SelectListItem> Categories { get; set; }

        public AddReviewViewModel(List<ReviewCategory> categories)
        {
            Categories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                Categories.Add(
                    new SelectListItem
                    {
                        Value = category.ReviewId.ToString(),
                        Text = category.UserName
                    }
                    ); 
            }
        }

        public AddReviewViewModel() { }
    }
}
