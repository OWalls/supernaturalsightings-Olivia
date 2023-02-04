using Google.Apis.SecretManager.v1.Data;
using Microsoft.AspNetCore.Mvc;

namespace supernaturalsightings_olivia.Controllers
{
    public class RandomLocationListController : SearchController
    {
        public IActionResult Index()
        {

            //Read data from CSV file
            List<Location> locations = ReadLocationFromCsv("entities.csv");

            //Select a random location from the list
            var randomLocation = locations[new Random().Next(locations.Count)];

            //Pass the selected location to the view
            return View(randomLocation);
        }

        private static List<Location> ReadLocationFromCsv(string randomizerFile)
        {

            List<Location> locations = new List<Location>();
            using (var reader = new StreamReader(randomizerFile))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    locations.Add(new Location { State = values[0], City = values[1] });
                }
            }

            return locations;
        }
    }
   
}
