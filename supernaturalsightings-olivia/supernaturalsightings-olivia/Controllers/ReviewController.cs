using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    [Authorize]
    public class ReviewController : Controller
    {
        private Data.SightDbContext _context;

        public ReviewController(Data.SightDbContext dbContext)
        {
            _context = dbContext;
        }

        public IActionResult Index()
        {
            List<Review> reviews = new List<Review>();
            return View(reviews);
            
        }

        [HttpGet("/Add")]
        public IActionResult Add()
        {
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel();

            return View(addReviewViewModel);
        }

        public IActionResult ProcessAddReviewForm(AddReviewViewModel addReviewViewModel)
        {
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    UserName = addReviewViewModel.Username,
                    Description = addReviewViewModel.Description,
                    ReviewId = addReviewViewModel.CategoryId

                };

                _context.Review.Add(newReview);
                _context.SaveChanges();

                return Redirect("Index");
            }

            return View("Add", addReviewViewModel);
        }
    }
}