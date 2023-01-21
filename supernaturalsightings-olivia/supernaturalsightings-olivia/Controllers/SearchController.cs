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
            return View();
        }

        public IActionResult Results(string searchType, string searchTerm, string[] type)
        {
            List<string> selected = new List<string>();
            string stateCode = "";

            if(searchType == "Screw It. Just Show Me Everything!")
            {
                Console.WriteLine("32: Find all entities.");
                entityList = EntityData.FindAll();
            }

            else if (type.Length > 0)
            {
                Console.WriteLine("38: Convert Array to List.");
                foreach (string entityName in type)
                {
                    selected.Add(entityName);
                }

                if (searchType == "state")
                {
                    Console.WriteLine("45: Search By State.");
                    stateCode = States.GetStateByName(searchTerm);

                    entityList = EntityData.FindByColumnAndValue(searchType, stateCode, selected);
                }
                else if (searchType != null && searchTerm != null && searchTerm != null)
                {
                    Console.WriteLine("52: Search By Description or City.");
                    entityList = EntityData.FindByColumnAndValue(searchType, searchTerm, selected);
                }
                else if (searchType == null && searchTerm == "" || searchTerm == null)
                {
                    Console.WriteLine("57: Only check boxes selected.");
                    entityList = EntityData.FindByType(selected);
                }
                else
                {
                    Console.WriteLine("WTF?");
                }

            }
            else if (type.Length == 0 && searchType != null && searchTerm != null)
            {
                if (searchType == "state")
                {
                    Console.WriteLine("45: Search By State.");
                    stateCode = States.GetStateByName(searchTerm);

                    entityList = EntityData.FindByColumnAndValue(searchType, stateCode);
                }
                else
                {
                    Console.WriteLine("64: No Check Boxes Selected. Radio Button Selected.");
                    entityList = EntityData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            else if (type.Length == 0 && searchType == null && searchTerm != null)
            {
                Console.WriteLine("69: Only the search box was used.");
                entityList = EntityData.FindByValue(searchTerm);
            }
            else
            {
                Console.WriteLine("WTF2: Electric Boogaloo");
            }

            ViewBag.entityList = entityList;
            return View("Index");
        }
    }
}
