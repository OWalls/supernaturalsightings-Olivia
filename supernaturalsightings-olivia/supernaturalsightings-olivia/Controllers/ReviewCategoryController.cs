//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using supernaturalsightings_olivia.Areas.Identity.Data;
//using supernaturalsightings_olivia.Models;
//using supernaturalsightings_olivia.ViewModels;

//namespace supernaturalsightings_olivia.Controllers
//{
//    [Authorize]
//    public class ReviewCategoryController : Controller
//    {
//        private SightDbContext _dbContext;

//        public ReviewCategoryController(SightDbContext dbContext)
//        {
//            _dbContext = dbContext;
//        }

//        //GET: /<controller>/

//        public IActionResult Index()
//        {
//            List<ReviewCategory> categories = _dbContext.ReviewCategory.ToList();

//            return View(categories);
//        }


//        [HttpGet("/Review")]
//        [Route("/Review/")]
//        public IActionResult Create()
//        {

//            return View();
//        }

//        [HttpPost]
//        [Route("/Review/")]
//        public IActionResult ProcessCreateReviewCategoryForm()
//        {
//            if (ModelState.IsValid)
//            {
//                ReviewCategory newCategory = new ReviewCategory
//                {
                
//                };

//                 //_dbContext.Category.Add(newCategory);
//                 //_dbContext.SaveChanges();

//                return RedirectToAction("/ReviewCategory");
//            }

//            return View("Create");
//        }

//        private class ReviewDbContext
//        {
//        }
//    }
//}

