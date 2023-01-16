using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Newtonsoft.Json.Linq;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;


namespace supernaturalsightings_olivia.Controllers
{
    public class SearchController : Controller
    {
        public List<Entity> entityList = new List<Entity>();

        public IActionResult Index()
        {
            ViewBag.columns = ResultsController.ColumnChoices;
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm)
        {
            var value = "";

            if (searchType.ToLower() == "state")
            {
                value = States.GetStateByName(searchTerm);

                entityList = EntityData.FindByColumnAndValue(searchType, value);
            }
            else if (searchTerm != null && searchTerm != "")
            {
                entityList = EntityData.FindByColumnAndValue(searchType, searchTerm);
            }
            else
            {
                entityList = EntityData.FindAll();
            }

            ViewBag.entityList = entityList;
            ViewBag.columns = ResultsController.ColumnChoices;
            return View("Index");
        }
    }
}
