using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewController : Controller
    {
        private ReviewDbContext context;

        public ReviewController(ReviewDbContext context)
        {
            this.context = context;
        }
        
        //GET: /<controller>/
       

        public IActionResult Index()
        {
            List<Review> reviews = context.Reviews.ToList();
            
            return View(reviews);
        }

        public IActionResult Review()
        {
            List<ReviewCategory> categories = context.Categories.ToList();
            AddReviewViewModel addReviewViewModel = new AddReviewViewModel(categories);

            return View(addReviewViewModel);
        }

        
    }

}

