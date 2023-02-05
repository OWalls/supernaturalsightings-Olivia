using Microsoft.AspNetCore.Mvc;
using supernaturalsightings_olivia.Models;
using System.Diagnostics;
using supernaturalsightings_olivia.ViewModels;
using supernaturalsightings_olivia.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Google.Apis.SecretManager.v1.Data;



namespace supernaturalsightings_olivia.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        //added for ability to add new sightings
        public List<Entity> entityList = new List<Entity>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        //add sighting to csv
        [HttpGet("/Add")]
        public IActionResult AddSighting()
        {

            AddSightingViewModel addSightingViewModel = new AddSightingViewModel();
            return View(addSightingViewModel);
        }


        public IActionResult ProcessAddSightingForm(AddSightingViewModel addSightingViewModel)
        {
            Entity newEntity = new Entity
            {
                Name = addSightingViewModel.Name,
                City = addSightingViewModel.City,
                State = addSightingViewModel.State,
                Description = addSightingViewModel.Description,
                Type = addSightingViewModel.Type,
            };

            EntityData.AddNewSighting(newEntity);

            return Redirect("/Add");
            //return View(addSightingViewModel);

        }

            [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}