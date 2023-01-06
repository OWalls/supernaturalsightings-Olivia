using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;

namespace supernaturalsightings_olivia.Controllers
{
    public class SearchController : Controller
    {
        public List<Entity> entityList = new List<Entity>();

        public IActionResult Index()
        {
            //this controller does not yet exist, so I just made something up as a placeholder
            ViewBag.columns = ResultsController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            if (searchTerm != null && searchTerm != "")
            {
                entityList = EntityData.FindByColumnAndValue(searchType, searchTerm);
            }
            else
            {
                entityList = EntityData.FindAll();
            }

            ViewBag.jobsList = entityList;
            ViewBag.columns = ResultsController.ColumnChoices;
            return View("Index");
        }
    }
}
