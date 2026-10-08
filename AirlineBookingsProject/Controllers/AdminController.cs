using AirlineBookingsProject.Data;
using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingsProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly AppDbContext _dbContext;
        public AdminController(AppDbContext ctx)
        {
            _dbContext = ctx;
        }
        public IActionResult Index()
        {
            ViewBag.Confirmed = _dbContext.Bookings.Count(b => b.Status == "Confirmed");
            ViewBag.Pending = _dbContext.Bookings.Count(b => b.Status == "Pending");
            ViewBag.Cancelled = _dbContext.Bookings.Count(b => b.Status == "Cancelled");

            ViewBag.TotalPassengers = _dbContext.Passengers.Count();
            ViewBag.TotalFlights = _dbContext.Flights.Count();
            ViewBag.TotalUsers = _dbContext.Users.Count();

            return View();
        }

        public IActionResult FlightRecords()
        {
            return View();
        }
        public IActionResult ShowAllUsers()
        {
            List<User> users = _dbContext.Users.ToList();
            return View(users);
        }

        [HttpPost]
        public IActionResult FlightRecords(Flight f)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Flights.Add(f);
                _dbContext.SaveChanges();

                return Redirect("/Flights/ShowAllFlights");
            }
            return View(f);
        }

        public IActionResult ManageFlights()
        {
            var flights = _dbContext.Flights.ToList();
            return View(flights);
        }

        public IActionResult UpdateFlight(string id)
        {
            var flight = _dbContext.Flights.Find(id);
            return View(flight);
        }

        [HttpPost]
        public IActionResult UpdateFlight(Flight updatedFlight)
        {
            if (!ModelState.IsValid)
            {
                return View(updatedFlight);
            }

            _dbContext.Flights.Update(updatedFlight);
            _dbContext.SaveChanges();

            return RedirectToAction("ManageFlights");
        }


        public IActionResult DeleteFlight(string id)
        {
            var flight = _dbContext.Flights.Find(id);

            if (flight != null)
            {
                _dbContext.Flights.Remove(flight);
                _dbContext.SaveChanges();
            }
            return RedirectToAction("ManageFlights");
        }

    }
}
