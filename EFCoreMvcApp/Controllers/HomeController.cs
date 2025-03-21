using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using EFCoreMvcApp.Models;
using TripsApp.Data;
using System.Linq;
using SQLitePCL;

namespace EFCoreMvcApp.Controllers;

public class HomeController : Controller
{
    private readonly TripContext _context;

    public HomeController(TripContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var trips = _context.Trips.ToList();
        return View(trips);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
