using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;  // [Route] , ControllerBase
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;


namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewController : Controller
    {
        private readonly SightDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public ReviewController(SightDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        //Get: Review/Rating Details
        //public IActionResult RemoveReviewComment(string formSightId)
        //{
        //    if (!int.TryParse(formSightId, out var sightid))
        //        return BadRequest();

        //    var userId = Guid.Parse(_userManager.GetUserId(User));
        //    var reviews = _context.Reviews
        //        .FirstOrDefault()

        }


        //delete a review 
     
    }
}

