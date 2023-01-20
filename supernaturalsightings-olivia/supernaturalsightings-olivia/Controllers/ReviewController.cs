using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    
    public class ReviewController : Controller
    {
        private SightDbContext _context;

        public ReviewController(SightDbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Review> review = _context.Review
                .Include(r => r.Category)
                .ToList();

            return View(review);
            
        }

        [HttpGet("/Review")]

        public IActionResult Add()
        {
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel();

            return View(addReviewViewModel);
        }

        [HttpPost]
        [Route("Review/Add")]
        public IActionResult Add(AddReviewViewModel addReviewViewModel)
        //public IActionResult ProcessAddReviewForm(AddReviewViewModel addReviewViewModel)
        {
            if (ModelState.IsValid)
            {
                Review newReview = new Review
                {
                    Username = addReviewViewModel.Username,
                    Description = addReviewViewModel.Description,
                    ReviewId = addReviewViewModel.ReviewCategoryId

                };


                _context.Review.Add(newReview);
                _context.SaveChanges();
               

                return Redirect("Index");
            }

            return View("Review", addReviewViewModel);
        }

        //public IActionResult Delete()
        //{
        //    ViewBag.reviews = Review.GetAll();

        //    return View();
        //}
    }
}