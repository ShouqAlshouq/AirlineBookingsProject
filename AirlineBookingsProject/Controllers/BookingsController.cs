using AirlineBookingsProject.Data;
using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingsProject.Controllers
{
    public class BookingsController : Controller
    {
        private readonly AppDbContext _dbContext;
        public BookingsController(AppDbContext ctx)
        {
            _dbContext = ctx;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult BookFlight(string id)
        {
            var flight = _dbContext.Flights
                .FirstOrDefault(f => f.FlightId == id);

            return View(flight);
        }

        [HttpPost]
        public IActionResult BookFlight(Booking booking, Passenger passenger, Payment payment)
        {
            string userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
                return RedirectToAction("Login", "Account");

            if (booking == null)
                booking = new Booking();

            booking.UserId = userId;
            booking.BookingDate = DateTime.Now;
            booking.Status = "Pending";

            booking.BookingId = "B" + (_dbContext.Bookings.Count() + 1).ToString("000");

            _dbContext.Bookings.Add(booking);
            _dbContext.SaveChanges();

            passenger.PassengerId = "P" + (_dbContext.Passengers.Count() + 1).ToString("000");
            passenger.BookingId = booking.BookingId;

            payment.PaymentId = "PAY" + (_dbContext.Payments.Count() + 1).ToString("000");
            payment.PaymentDate = DateTime.Now;
            payment.BookingId = booking.BookingId;

            _dbContext.Passengers.Add(passenger);
            _dbContext.Payments.Add(payment);
            _dbContext.SaveChanges();

            return RedirectToAction("MyBookings");
        }

        public IActionResult MyBookings()
        {
            string userId = HttpContext.Session.GetString("UserId");

            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var bookings = _dbContext.Bookings
                .Where(b => b.UserId == userId)
                .Include(b => b.Flight)
                .Include(b => b.Passengers)
                .Include(b => b.Payment)
                .ToList();
            return View(bookings);
        }

        public IActionResult DeleteBooking(string id)
        {
            var booking = _dbContext.Bookings
                .Include(b => b.Passengers)
                .Include(b => b.Payment)
                .Include(b => b.Flight)
                .FirstOrDefault(b => b.BookingId == id);
            
                _dbContext.Bookings.Remove(booking);
                _dbContext.SaveChanges();
            return Redirect("/Bookings/MyBookings");
        }
    }
}
