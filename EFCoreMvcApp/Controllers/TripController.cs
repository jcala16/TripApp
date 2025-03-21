using Microsoft.AspNetCore.Mvc;
using TripsApp.Data;
using TripsApp.Models;
namespace TripsApp.Controllers;
using System.Text.Json;


public class TripController : Controller
{
private readonly TripContext _context;
public TripController(TripContext context)
{
_context = context;
}
// GET: Trip/Add1 - Page 1: Destination and Dates
public IActionResult Add1()
{
return View();
}
// POST: Trip/Add1 - Page 1 Submission
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Add1(Trip trip)
{
     Console.WriteLine($"Destination: {trip.Destination}");
    Console.WriteLine($"Start Date: {trip.StartDate}");
    Console.WriteLine($"End Date: {trip.EndDate}");
    

if (true)
{
    Console.WriteLine("Redirected to Add2");

TempData["TripData"] = JsonSerializer.Serialize(trip);; // Store the Trip object in TempData
return RedirectToAction(nameof(Add2)); // Redirect to page 2
}
return View(trip); // Return to Add1 view with validationerrors
}
// GET: Trip/Add2 - Page 2: Accommodations
public IActionResult Add2()
{
// Trip tripData = TempData["TripData"] as Trip; // Retrieve Trip data from TempData
var tripData = TempData["TripData"] != null
     ? JsonSerializer.Deserialize<Trip>((string)TempData["TripData"])
     : null;
TempData.Keep("TripData");


if (tripData == null)
{
return RedirectToAction(nameof(Add1)); // Redirect to Add1 if no data in TempData
}
ViewBag.SubHeader = $"Accommodation for{tripData.Destination}"; // Set subheader for the view
return View();
}
// POST: Trip/Add2 - Page 2 Submission
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Add2(Trip trip)
{
var tripData = TempData["TripData"] != null
    ? JsonSerializer.Deserialize<Trip>((string)TempData["TripData"])
    : null;

if (tripData == null)
{
return RedirectToAction(nameof(Add1)); // Redirect to Add1 if no data in TempData
}
// Update TempData Trip object with accommodation details
tripData.AccommodationPhone = trip.AccommodationPhone;
tripData.AccommodationEmail = trip.AccommodationEmail;
TempData["TripData"] = JsonSerializer.Serialize(tripData); // Update TempData
return RedirectToAction(nameof(Add3)); // Redirect to page 3
}
// GET: Trip/Add3 - Page 3: Activities
public IActionResult Add3()
{
var tripData = TempData["TripData"] != null
    ? JsonSerializer.Deserialize<Trip>((string)TempData["TripData"])
    : null;

TempData.Keep("TripData");


if (tripData == null)
{
return RedirectToAction(nameof(Add1)); // Redirect to Add1 if no data in TempData
}
ViewBag.SubHeader = $"Activities for{tripData.Destination}"; // Set subheader for the view
return View();
}
// POST: Trip/Add3 - Page 3 Submission & Data Persistence
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Add3(Trip trip)
{
var tripData = TempData["TripData"] != null
    ? JsonSerializer.Deserialize<Trip>((string)TempData["TripData"])
    : null;

if (tripData == null)
{
return RedirectToAction(nameof(Add1)); // Redirect to Add1 if no data in TempData
}
// Update TempData Trip object with activity details
tripData.Activity1 = trip.Activity1;
tripData.Activity2 = trip.Activity2;
tripData.Activity3 = trip.Activity3;
TempData["TripData"] = JsonSerializer.Serialize(tripData);
_context.Trips.Add(tripData); // Add the completed Trip to the DbContext
_context.SaveChanges(); // Save changes to he database
TempData.Clear(); // Clear TempData after successful save
TempData["Message"] = "Trip added successfully!"; //Success message
return RedirectToAction("Index", "Home"); // Redirect tothe homepage
}
// GET: Trip/Cancel - Cancel "Add Trip" process
public IActionResult Cancel()
{
TempData.Clear(); // Clear TempData, discarding any collected data
return RedirectToAction("Index", "Home"); // Redirect to the homepage
}
}
