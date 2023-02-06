using Microsoft.AspNetCore.Mvc;  // [Route] , ControllerBase
using Microsoft.CodeAnalysis.CSharp.Syntax;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewController : Controller
    {
        private readonly SightDbContext _context;

        public IEnumerable<object> ratings { get; private set; }

        public ReviewController(SightDbContext context)
        {
            _context = context;
        }

        //Get: /<controller>/
        public IActionResult Index()
        {
            List<Review> reviews = _context.Reviews
                
                .ToList();
            return View(reviews);
        }


        [HttpGet("/Search/Results")]
        public IActionResult AddReview()
        {
            AddReviewViewModel viewModel = new AddReviewViewModel();

            return View(viewModel);
        }

        [HttpPost]
        [Route("/Add/Review")]
        [ValidateAntiForgeryToken]
        public IActionResult ProcessAddReviewForm(AddReviewViewModel addReviewViewModel)
        {
            if (ModelState.IsValid)
            {

                Review newReview = new Review
                {
                    //EntityId = addReviewViewModel.EntityId,
                    DisplayName = addReviewViewModel.DisplayName,
                    ReviewComment = addReviewViewModel.ReviewComment,
                    ReviewTitle = addReviewViewModel.ReviewTitle,
                    Rating = addReviewViewModel.Rating,
                };

                
                _context.Reviews.Add(newReview);
                _context.SaveChanges();

                return Redirect("/Review");
            }

            return View("AddReview", addReviewViewModel);
        }

        //[HttpPost]
        //[Route("/AddReview/Review")]
        //public async Task<IActionResult> ProcessAddReviewForm(AddReviewViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        //Calculate the rating based on some logic
        //        //int rating = CalculateRating(model.ReviewComment);

        //        var review = new Review
        //        {
        //            DisplayName = model.DisplayName,
        //            ReviewTitle = model.ReviewTitle,
        //            ReviewComment = model.ReviewComment,
        //            Rating = model.Rating,
        //        };

        //        _context.Add(review);
        //        await _context.SaveChangesAsync();

        //        return RedirectToAction("Index");
        //    }

        //    return View("AddReview", model);
        //}

        //private int CalculateRating(string reviewComment)
        //{
        //    throw new NotImplementedException();
        //}

        //private int CalculateRating(string ratings)
        //{
        //    //Added logic to calculate the rating based on the average 5 "star" rating
        //    double totalStars = 0;
        //    int numberOfRatings = 0;

        //    foreach (var rating in ratings)
        //    {
        //        totalStars += rating.Stars;
        //        numberOfRatings++;
        //    }
        //        double averageRating = totalStars / numberOfRatings;
        //    return averageRating(ratings);
    }

        
    }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult AddReview(AddReviewViewModel viewModel)
//        {
//            if (ModelState.IsValid)
//            {
//                var newReview = new Review
//                {
//                    Username = viewModel.Username,
//                    ReviewComment = viewModel.ReviewComment
//                };

//                _context.Reviews.Add(newReview);
//                _context.SaveChanges();

//                return Redirect("/Comment");
//            }

//            return View("AddReview", viewModel);
//        }

//    }
//}