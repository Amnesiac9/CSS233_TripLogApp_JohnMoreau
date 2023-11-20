using CSS233_TripLogApp_JohnMoreau.Models;
using Microsoft.AspNetCore.Mvc;

namespace CSS233_TripLogApp_JohnMoreau.Controllers
{
    public class TripController : Controller
    {

        private TripContext Context { get; set; }
        public TripController(TripContext ctx) => Context = ctx;

        [HttpGet]
        public IActionResult Add() //string page, string subheader
        {

            ViewBag.Action = "Add";
            ViewBag.SubHeader = "Trip Destination and Dates";

            return View("Page1", new TripPage1ViewModel());

        }

        [HttpGet]
        public IActionResult Edit()
        {
            ViewBag.Action = "Edit";
            ViewBag.SubHeader = "Trip Destination and Dates";
        }


        [HttpPost]
        public IActionResult Add1(TripPage1ViewModel trip)
        {

            if (trip == null || !ModelState.IsValid)
            {
                ViewBag.SubHeader = "Add Trip Destination and Dates";

                return View("Page1", trip ?? new TripPage1ViewModel());
            }

            TempData["TripDestination"] = trip.Destination;
            TempData["TripAccommodation"] = trip.Accommodation;
            TempData["TripStartDate"] = trip.StartDate.ToString("d");
            TempData["TripEndDate"] = trip.EndDate.ToString("d");



            ViewBag.SubHeader = "Add Info for " + trip.Accommodation;
            return View("Page2", new TripPage2ViewModel());


        }

        [HttpPost]
        public IActionResult Add2(TripPage2ViewModel trip2)
        {

            if (trip2 == null || !ModelState.IsValid)
            {
                ViewBag.SubHeader = "Add Trip Destination and Dates";

                return View("Page1", new TripPage1ViewModel());
            }

            TempData["TripAccommodationPhone"] = trip2.AccommodationPhone;
            TempData["TripAccommodationEmail"] = trip2.AccommodationEmail;

            var destination = TempData.Peek("TripDestination");

            ViewBag.SubHeader = "Add Things To Do in " + destination;

            return View("Page3", new TripPage3ViewModel());

        }

        [HttpPost]
        public IActionResult Add3(TripPage3ViewModel trip3)
        {

            if (trip3 == null || !ModelState.IsValid)
            {
                ViewBag.SubHeader = "Add Trip Destination and Dates";

                return View("Page1", new TripPage1ViewModel());
            }

            //var trip1 = TempData["trip1"] as TripPage1ViewModel;
            //var trip2 = TempData["trip2"] as TripPage2ViewModel;

            //if (trip1 == null || trip2 == null)
            //{
            //    Console.WriteLine("trip1 or trip2 not found in TempData");
            //    return View("Page1", trip1 ?? new TripPage1ViewModel());
            //}


            // Add success message for index to read

            var destination = TempData["TripDestination"]?.ToString() ?? "";

            // Add data to a trip object
            var trip = new Trip()
            {
                Destination = destination,
                Accommodation = TempData["TripAccommodation"]?.ToString() ?? "",
                StartDate = DateTime.Parse(TempData["TripStartDate"]?.ToString() ?? "1/1/1990"),
                EndDate = DateTime.Parse(TempData["TripEndDate"]?.ToString() ?? "1/1/1990"),
                AccommodationPhone = TempData["TripAccommodationPhone"]?.ToString() ?? "",
                AccommodationEmail = TempData["TripAccommodationEmail"]?.ToString() ?? "",
                Activity1 = trip3.Activity1 ?? "",
                Activity2 = trip3.Activity2 ?? "",
                Activity3 = trip3.Activity3 ?? ""
            };


            //// Add data to a trip object
            //var trip = new Trip()
            //{
            //    Destination = trip1.Destination,
            //    Accommodation = trip1.Accommodation,
            //    StartDate = trip1.StartDate,
            //    EndDate = trip1.EndDate,
            //    AccommodationPhone = trip2.AccommodationPhone,
            //    AccommodationEmail = trip2.AccommodationEmail,
            //    Activity1 = trip3.Activity1,
            //    Activity2 = trip3.Activity2,
            //    Activity3 = trip3.Activity3
            //};

            // Add the new trip to our database
            Context.Trips.Add(trip);
            Context.SaveChanges();

            TempData["SuccessMessage"] = destination + " Successfully Added!";

            // Redirect to home
            return RedirectToAction("Index", "Home");

        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var trip = Context.Trips.Find(id);
            return View(trip);




        }


        [HttpPost]
        public IActionResult Delete(Trip trip)
        {
            Context.Trips.Remove(trip);
            Context.SaveChanges();
            TempData["SuccessMessage"] = trip.Destination + " Successfully Removed.";
            return RedirectToAction("Index", "Home");

        }
    }

}