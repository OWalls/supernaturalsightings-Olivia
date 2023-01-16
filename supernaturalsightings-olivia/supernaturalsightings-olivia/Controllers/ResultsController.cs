using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;


namespace supernaturalsightings_olivia.Controllers
{
    public class ResultsController : Controller
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All"},
            {"name", "Name"},
            {"city", "City"},
            {"state", "State"},
            {"description", "Description"},
            {"type", "Type"}
        };

        internal static Dictionary<string, List<Entity>> TableChoices = new Dictionary<string, List<Entity>>()
        {
            {"name", EntityData.GetAllNames()},
            {"city", EntityData.GetAllCities()},
            {"state", EntityData.GetAllStates()},
            {"description", EntityData.GetAllDescriptions()},
            {"type", EntityData.GetAllTypes()}
        };

        public List<Entity> entities = new List<Entity>();

        public IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tableChoices = TableChoices;
            ViewBag.names = EntityData.GetAllNames();
            ViewBag.cities = EntityData.GetAllCities();
            ViewBag.states = EntityData.GetAllStates();
            ViewBag.descriptions = EntityData.GetAllDescriptions();
            ViewBag.types = EntityData.GetAllTypes();

            return View();
        }

        public IActionResult Entities(string column, string value)
        {

            if (column.ToLower() == "all")
            {
                entities = EntityData.FindAll();
                ViewBag.title = "All Entities";
            }
            else
            {
                entities = EntityData.FindByColumnAndValue(column, value);
                ViewBag.title = value;
            }

            ViewBag.entities = entities;

            return View();
        }
    }
}
