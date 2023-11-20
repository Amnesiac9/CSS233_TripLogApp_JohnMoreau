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
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.SubHeader = "Trip Destination and Dates";

            var trip = Context.Trips.Find(id);

            if (trip == null)
            {
                return RedirectToAction("Index", "Home");
            }

            TempData["TripDestination"] = trip.Destination;
            TempData["TripAccommodation"] = trip.Accommodation;
            TempData["TripStartDate"] = trip.StartDate.ToString("d");
            TempData["TripEndDate"] = trip.EndDate.ToString("d");
            TempData["TripAccommodationPhone"] = trip.AccommodationPhone;
            TempData["TripAccommodationEmail"] = trip.AccommodationEmail;
            TempData["TripActivity1"] = trip.Activity1;
            TempData["TripActivity2"] = trip.Activity2;
            TempData["TripActivity3"] = trip.Activity3;




            return View("Page1", new TripPage1ViewModel(trip));
        }


        [HttpPost]
        public IActionResult Add1(TripPage1ViewModel trip1)
        {
            ViewBag.Action = (trip1?.Id == 0) ? "Add" : "Edit";

            if (trip1 == null || !ModelState.IsValid)
            {
                
                ViewBag.SubHeader = "Trip Destination and Dates";

                return View("Page1", trip1 ?? new TripPage1ViewModel());
            }

            // Set Temp Data
            TempData["TripDestination"] = trip1.Destination;
            TempData["TripAccommodation"] = trip1.Accommodation;
            TempData["TripStartDate"] = trip1.StartDate.ToString("d");
            TempData["TripEndDate"] = trip1.EndDate.ToString("d");


            // Set Shared Subheader
            ViewBag.SubHeader = "Info for " + trip1.Accommodation;
           
            // If id is 0, this is an ADD, return basic new TripPage2ViewModel
            if (trip1.Id == 0)
            {
                return View("Page2", new TripPage2ViewModel());
            }

            // If we can find the ID, pass the trip to TripPage2ViewModel constructor and page two.
            var trip = Context.Trips.Find(trip1.Id);
            if (trip == null) {
                return View("Page1", trip1 ?? new TripPage1ViewModel());
            }


            return View("Page2", new TripPage2ViewModel(trip));

        }

        [HttpPost]
        public IActionResult Add2(TripPage2ViewModel trip2)
        {
            ViewBag.Action = (trip2?.Id == 0) ? "Add" : "Edit";

            if (trip2 == null || !ModelState.IsValid)
            {
                ViewBag.SubHeader = "Trip Destination and Dates";

                return View("Page1", new TripPage1ViewModel());
            }

            // Set Temp Data
            TempData["TripAccommodationPhone"] = trip2.AccommodationPhone;
            TempData["TripAccommodationEmail"] = trip2.AccommodationEmail;

            // Set Shared SubHeader
            var destination = TempData.Peek("TripDestination");
            ViewBag.SubHeader = "Things To Do in " + destination;


            if (trip2.Id == 0)
            {
                return View("Page3", new TripPage3ViewModel());
            }

            // If we can find the ID, pass the trip to ViewModel constructor and next Page.
            var trip = Context.Trips.Find(trip2.Id);
            if (trip == null)
            {
                ViewBag.SubHeader = "Info for " + trip?.Accommodation ?? "Unknown";
                return View("Page2", trip2 ?? new TripPage2ViewModel());
            }

            return View("Page3", new TripPage3ViewModel(trip));

        }

        [HttpPost]
        public IActionResult Add3(TripPage3ViewModel trip3)
        {
            ViewBag.Action = (trip3?.Id == 0) ? "Add" : "Edit";

            if (trip3 == null || !ModelState.IsValid)
            {
                ViewBag.SubHeader = "Trip Destination and Dates";

                return View("Page1", new TripPage1ViewModel());
            }

            
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

            if (trip3.Id == 0)
            {
                // Add the new trip to our database
                Context.Trips.Add(trip);
                Context.SaveChanges();

                // Add success message for index to read
                TempData["SuccessMessage"] = "Trip to " + destination + " Added!";
            }
            else
            {
                trip.Id = trip3.Id ?? 0;
                // Update the trip in our database
                Context.Trips.Update(trip);
                Context.SaveChanges();

                TempData["SuccessMessage"] = "Trip to " + destination + " Updated!";
            }


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
            TempData["SuccessMessage"] = "Trip to " + trip.Destination + " Removed.";
            return RedirectToAction("Index", "Home");

        }

        public IActionResult Cancel()
        {
            // Clear Temp Data
            TempData.Clear();

            return RedirectToAction("Index", "Home");
        }
    }

}