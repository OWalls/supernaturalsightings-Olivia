using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewCategoryController : Controller
    {
        private ReviewDbContext _dbContext;

        public ReviewCategoryController(ReviewDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: /<controller>/
        [HttpGet]
        public IActionResult Index()
        {
            List<ReviewCategory> categories = _dbContext.Categories.ToList();
            
            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            AddReviewCategoryViewModel addReviewCategoryViewModel = new AddReviewCategoryViewModel();
            return View(addReviewCategoryViewModel);
        }

        [HttpPost]
        public IActionResult ProcessCreateReviewCategoryForm(AddReviewCategoryViewModel addReviewCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ReviewCategory newCategory = new ReviewCategory
                {
                    UserName = addReviewCategoryViewModel.UserName
                };

                _dbContext.Categories.Add(newCategory);
                _dbContext.SaveChanges();

                return RedirectToAction("/ReviewCategory");
            }

            return View("Create", addReviewCategoryViewModel);
        }
    }
}
