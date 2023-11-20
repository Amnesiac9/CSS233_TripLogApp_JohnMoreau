using CSS233_TripLogApp_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CSS233_TripLogApp_JohnMoreau.Controllers
{
    public class HomeController : Controller
    {

        private TripContext Context { get; set; }
        public HomeController(TripContext ctx) => Context = ctx;


        public IActionResult Index(string sortBy, string sortOrder)
        {

            // Set Context
            var trips = Context.Trips;

            // Return early if SortOrder is empty to increase performance.
            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                return View(trips.OrderBy(p => p.Id).ToList());
            }

            // Store the latest sortOrder and SortBy in the ViewBag to send to the view.
            ViewBag.SortOrder = sortOrder;
            ViewBag.SortBy = sortBy;

            switch (sortBy) 
            {
                case "Destination":
                    return sortOrder switch
                    {
                        "asc" => View(trips.OrderBy(p => p.Destination).ToList()),
                        "desc" => View(trips.OrderByDescending(p => p.Destination).ToList()),
                        _ => View(trips.OrderBy(p => p.Id).ToList()),
                    };
                case "StartDate":
                    return sortOrder switch
                    {
                        "asc" => View(trips.OrderBy(p => p.StartDate).ToList()),
                        "desc" => View(trips.OrderByDescending(p => p.StartDate).ToList()),
                        _ => View(trips.OrderBy(p => p.Id).ToList()),
                    };
                case "EndDate":
                    return sortOrder switch
                    {
                        "asc" => View(trips.OrderBy(p => p.StartDate).ToList()),
                        "desc" => View(trips.OrderByDescending(p => p.StartDate).ToList()),
                        _ => View(trips.OrderBy(p => p.Id).ToList()),
                    };
                case "Accommodations":
                    return sortOrder switch
                    {
                        "asc" => View(trips.OrderBy(p => p.Accommodation).ToList()),
                        "desc" => View(trips.OrderByDescending(p => p.Accommodation).ToList()),
                        _ => View(trips.OrderBy(p => p.Id).ToList()),
                    };
                case "ToDo":
                    return sortOrder switch
                    {
                        "asc" => View(trips.OrderBy(p => p.Activity1).ToList()),
                        "desc" => View(trips.OrderByDescending(p => p.Activity1).ToList()),
                        _ => View(trips.OrderBy(p => p.Id).ToList()),
                    };
                default:
                    return View(trips.OrderBy(p => p.Id).ToList());

            }
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}