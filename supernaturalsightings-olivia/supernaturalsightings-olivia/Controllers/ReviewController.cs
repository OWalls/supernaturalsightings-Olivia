using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Controllers;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;
//using System.Web.Mvc;

namespace supernaturalsightings_olivia.Controllers
{
    
    public class ReviewController : Controller
    {
        private readonly SightDbContext _context;

        public ReviewController(SightDbContext dbContext)
        {
            _context = dbContext;
        }
        // GET: /<controller>/
        [HttpGet("/Review")]
        public IActionResult Index()
        {
            List<Review> review = _context.Review
                .Include(r => r.ReviewCategory)
                .ToList();

            return View(review);

        }

        private IActionResult View(AddReviewViewModel addReviewViewModel)
        {
            throw new NotImplementedException();
        }

        [HttpGet("/Review")]

        public IActionResult Add()
        {
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel();

            return View(addReviewViewModel);
        }

        [HttpPost]
        [Route("Review/Add")]
        // public IActionResult Create(AddReviewViewModel addReviewViewModel)
        public IActionResult ProcessAddReviewForm(AddReviewViewModel addReviewViewModel)
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
//GET: /< controller >/
//        public IActionResult Index()
//{
//    ViewBag.columns = ReviewListController.ColumnChoices;
//    return View();
//}

////ToDo Create an action method to process a search request and render the updated search views.
//[HttpPost]
//public IActionResult Results(string searchType, string searchTerm)
//{
//    List<Review> reviews;
//    if (searchType == null)
//    {
//        reviews = ReviewData.FindAll();
//        ViewBag.title = "All Reviews";
//    }
//    else
//    {
//        reviews = ReviewData.FindByColumnAndValue(searchType, searchTerm);
//    }

//    ViewBag.columns = ReviewListController.ColumnChoices;
//    ViewBag.reviews = reviews;

//    return View("Index");
//}
//            }
//        }
