// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
//using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using supernaturalsightings_olivia.Areas.Identity.Data;
using supernaturalsightings_olivia.Models;
using System.Security.Claims;
//using System.Web.Mvc;

namespace supernaturalsightings_olivia.Controllers
{
    public class ReviewListController : ReviewController
    {
        internal static Dictionary<string, string> ColumnChoices = new Dictionary<string, string>()
        {
            {"all", "All" },
            {"username", "Username"},
            {"location", "Location" },
            {"encounterType", "EncounterType" },
           
        };

        private static Dictionary<string, List<ReviewField>> tableChoices = new Dictionary<string, List<ReviewField>>()
        {
            //{"all", "All"};
            {"username", ReviewData.GetAllUsernames()},
            {"location", ReviewData.GetAllLocations()},
            {"encounterType", ReviewData.GetAllEncounterTypes()},
            {"reviewCategory", ReviewData.GetAllReviewCategories()}
        };

        internal static List<Review> reviews;

        public ReviewListController(SightDbContext dbContext) : base(dbContext)
        {
        }

        internal static Dictionary<string, List<ReviewField>> TableChoices { get => tableChoices; set => tableChoices = value; }

        public new IActionResult Index()
        {
            ViewBag.columns = ColumnChoices;
            ViewBag.tablechoices = TableChoices;
            ViewBag.usernames = ReviewData.GetAllUsernames();
            ViewBag.locations = ReviewData.GetAllLocations();
            ViewBag.encounterTypes = ReviewData.GetAllEncounterTypes();
            

            return View();
        }

        // TODO #2 - Complete the Jobs action method
        public IActionResult Reviews(string column, string value)
        {

            if (column.ToLower().Equals("all"))
            {
                reviews = ReviewData.FindAll();
                ViewBag.title = "All Jobs";
            }
            else
            {
                reviews = ReviewData.FindByColumnAndValue(column, value);
                ViewBag.title = "Reviews with " + ColumnChoices[column] + ": " + value;
            }

            ViewBag.reivews = reviews;

            return View();
        }

        public IActionResult AllReviews()
        {
            ViewBag.title = ReviewData.FindAll();
            ViewBag.title = "All Reviews";
            ViewBag.value = ColumnChoices;
            ViewBag.reviews = reviews;

            return View();
        }

        public override bool Equals(object? obj)
        {
            return obj is ReviewListController controller &&
                   EqualityComparer<HttpContext>.Default.Equals(HttpContext, controller.HttpContext) &&
                   EqualityComparer<HttpRequest>.Default.Equals(Request, controller.Request) &&
                   EqualityComparer<HttpResponse>.Default.Equals(Response, controller.Response) &&
                   EqualityComparer<RouteData>.Default.Equals(RouteData, controller.RouteData) &&
                   EqualityComparer<Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary>.Default.Equals(ModelState, controller.ModelState) &&
                   EqualityComparer<Microsoft.AspNetCore.Mvc.ControllerContext>.Default.Equals(ControllerContext, controller.ControllerContext) &&
                   EqualityComparer<IModelMetadataProvider>.Default.Equals(MetadataProvider, controller.MetadataProvider) &&
                   EqualityComparer<IModelBinderFactory>.Default.Equals(ModelBinderFactory, controller.ModelBinderFactory) &&
                   EqualityComparer<IUrlHelper>.Default.Equals(Url, controller.Url) &&
                   EqualityComparer<IObjectModelValidator>.Default.Equals(ObjectValidator, controller.ObjectValidator) &&
                   EqualityComparer<ProblemDetailsFactory>.Default.Equals(ProblemDetailsFactory, controller.ProblemDetailsFactory) &&
                   EqualityComparer<ClaimsPrincipal>.Default.Equals(User, controller.User) &&
                   EqualityComparer<Microsoft.AspNetCore.Mvc.ViewFeatures.ViewDataDictionary>.Default.Equals(ViewData, controller.ViewData) &&
                   EqualityComparer<ITempDataDictionary>.Default.Equals(TempData, controller.TempData) &&
                   EqualityComparer<dynamic>.Default.Equals(ViewBag, controller.ViewBag);
        }

        public override int GetHashCode()
        {
            HashCode hash = new HashCode();
            hash.Add(HttpContext);
            hash.Add(Request);
            hash.Add(Response);
            hash.Add(RouteData);
            hash.Add(ModelState);
            hash.Add(ControllerContext);
            hash.Add(MetadataProvider);
            hash.Add(ModelBinderFactory);
            hash.Add(Url);
            hash.Add(ObjectValidator);
            hash.Add(ProblemDetailsFactory);
            hash.Add(User);
            hash.Add(ViewData);
            hash.Add(TempData);
            hash.Add(ViewBag);
            return hash.ToHashCode();
        }
    }
    
}
