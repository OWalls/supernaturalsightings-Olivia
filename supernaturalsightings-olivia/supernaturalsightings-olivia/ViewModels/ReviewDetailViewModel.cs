using supernaturalsightings_olivia.Models;

namespace supernaturalsightings_olivia.ViewModels
{
    public class ReviewDetailViewModel
    {
        public int ReviewId { get; set; }
        public string Username { get; set; }
        public string Description { get; set; }
        public string ReviewCategory { get; set; }
        public string TagText { get; set; }

        public ReviewDetailViewModel(Review theReview, List<ReviewTag> reviewTags)
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
        
    }
}
