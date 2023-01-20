// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using supernaturalsightings_olivia.Models;
using System.ComponentModel.DataAnnotations;

namespace supernaturalsightings_olivia.ViewModels
{
    public class AddReviewViewModel
    {

        //[Required(ErrorMessage = "Username is required!")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 15 characters long")]
        //[Display(Name = "Username")]
        //public string Username { get; set; }

        //[Required(ErrorMessage = "Tell us your weird experience!")]
        //[StringLength(1000, MinimumLength = 3, ErrorMessage = "Description must be longer than that")]
        //public string Description { get; set; }

        //[Required(ErrorMessage = "Category is required!")]
        //[StringLength(20, MinimumLength = 3, ErrorMessage = "Pick a category")]
        //[Display(Name = "Category")]
        //public string Category { get; set; }

        public List<ReviewCategory> Categories { get; set; }
        public int ReviewId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string ReviewCategory { get; set; }
        public string TagText { get; set; }
        public int ReviewCategoryId { get; set; }

        public AddReviewViewModel(Review theReview, List<ReviewTag> reviewTags)
        {
            ReviewId = theReview.ReviewId;
            Username = theReview.Username;
            Description = theReview.Description;
            ReviewCategory = theReview.Category.ReviewType;

            TagText = "";

            for (var i = 0; i < reviewTags.Count; i++)
            {
                TagText += "#" + reviewTags[i].Tag.ToString();

                if (i < reviewTags.Count - 1)
                {
                    TagText += ", ";
                }
            }
        }

        public List<SelectListItem> ReviewCategories { get; set; }

        public AddReviewViewModel(List<ReviewCategory> categories)
        {
            ReviewCategories = new List<SelectListItem>();

            foreach (var category in categories)
            {
                ReviewCategories.Add(
                    new SelectListItem
                    {
                        Value = category.Review.ToString(),
                        Text = category.Username
                    }
                    );
               
            }

        }

        public AddReviewViewModel()
        {
        }

        public override bool Equals(object? obj)
        {
            return obj is AddReviewViewModel model &&
                   Username == model.Username;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Username);
        }
    }
}        

    