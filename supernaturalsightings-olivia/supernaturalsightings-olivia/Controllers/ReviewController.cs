using Microsoft.AspNetCore.Mvc;  // [Route] , ControllerBase
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewController : Controller
    {
        private readonly SightDbContext _context;
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


        //  [HttpGet("/Review")]
        public IActionResult AddReview()
        {
            AddReviewViewModel viewModel = new AddReviewViewModel();

            return View(viewModel);
        }

        [HttpPost]
        // [Route("/Review/Add")]
        //[ValidateAntiForgeryToken]
        public IActionResult ProcessAddReviewForm(AddReviewViewModel addReviewViewModel)
        {
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    Username = addReviewViewModel.Username,
                    ReviewComment = addReviewViewModel.ReviewComment,
                    ReviewTitle = addReviewViewModel.ReviewTitle,
                };

                _context.Add(newReview);
                _context.SaveChanges();

                return Redirect("/Review");
            }

            return View("AddReview", addReviewViewModel);
        }

    }
}