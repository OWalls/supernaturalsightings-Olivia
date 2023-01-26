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

            //Checks to see if someone has clicked the button to see everything.
            if(searchType == "Show Me Everything!")
            {
                entityList = EntityData.FindAll();
            }
            //Checks to see if they selected any of the checkboxes.
            else if (type.Length > 0)
            {
                foreach (string entityName in type)
                {
                    selected.Add(entityName);
                }

                //Exectues if they selected checkboxes and tried to search by state with a search term.
                if (searchType == "state" && searchTerm != null && searchTerm != "")
                {
                    stateCode = States.GetStateByName(searchTerm);

                    entityList = EntityData.FindByColumnValueAndType(searchType, stateCode, selected);
                }
                //Exectutes if they selected checkboxes and search by city or description.
                else if (searchType != null && searchTerm != null && searchTerm != "")
                {
                    entityList = EntityData.FindByColumnValueAndType(searchType, searchTerm, selected);
                }
                //Executes if they selected checkboxes but did not enter a search term or select a radio button.
                else if (searchType == null && searchTerm == "" || searchTerm == null)
                {
                    entityList = EntityData.FindByType(selected);
                }
                else
                {
                    ViewBag.entityList = null;
                }

            }
            //Checks to see if they selected a search type and search term but no check boxes.
            else if (type.Length == 0 && searchType != null && searchTerm != null)
            {
                //Exectutes if they search by state and search term only.
                if (searchType == "state" && searchTerm != null && searchTerm != "")
                {
                    stateCode = States.GetStateByName(searchTerm);

                    entityList = EntityData.FindByColumnAndValue(searchType, stateCode);
                }
                //Exectues if they search by city or description with a search term.
                else
                {
                    entityList = EntityData.FindByColumnAndValue(searchType, searchTerm);
                }
            }
            //Exectues if they don't select any buttons but input a search term in the search box.
            else if (type.Length == 0 && searchType == null && searchTerm != null)
            {
                entityList = EntityData.FindByValue(searchTerm);
            }
            else
            {
                ViewBag.entityList = null;
            }

            ViewBag.entityList = entityList;
            return View();
        }
    }
}
