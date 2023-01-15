using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supernaturalsightings_olivia.Data;
using supernaturalsightings_olivia.Models;
using supernaturalsightings_olivia.ViewModels;

namespace supernaturalsightings_olivia.Controllers
{
    [Authorize]
    public class ReviewCategoryController : Controller
    {
        private SightDbContext _dbContext;

        public ReviewCategoryController(SightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        //GET: /<controller>/
        
        public IActionResult Index()
        {
            List<ReviewCategory> categories = _dbContext.Categories.ToList();

            return View(categories);
        }


        [HttpGet("/Review")]
        [Route("/Review/")]
        public IActionResult Create()
        {
            AddReviewCategoryViewModel addReviewCategoryViewModel = new AddReviewCategoryViewModel();
            return View(addReviewCategoryViewModel);
        }

        [HttpPost]
        [Route("/review/")]
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

        private class ReviewDbContext
        {
        }
    }
}
