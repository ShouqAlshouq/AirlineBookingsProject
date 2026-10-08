using AirlineBookingsProject.Data;
using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingsProject.Controllers
{
    public class FlightsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public FlightsController(AppDbContext ctx)
        {
            _dbContext = ctx;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowAllFlights()
        {
            List<Flight> flights = _dbContext.Flights.ToList();
            return View(flights);
        }

        public IActionResult Search()
        {
            ViewBag.LastFromCity = Request.Cookies["LastFromCity"];
            ViewBag.LastToCity = Request.Cookies["LastToCity"];
            ViewBag.LastDate = Request.Cookies["LastDate"];

            return View(new List<Flight>());
        }

        [HttpPost]
        public IActionResult Search(string fromCity, string toCity, DateTime? date)
        {
            CookieOptions options = new CookieOptions
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true,
                Secure = true
            };

            Response.Cookies.Append("LastFromCity", fromCity ?? "", options);
            Response.Cookies.Append("LastToCity", toCity ?? "", options);
            Response.Cookies.Append("LastDate", date?.ToString("yyyy-MM-dd") ?? "", options);

            var flights = _dbContext.Flights.AsQueryable();

            if (!string.IsNullOrEmpty(fromCity))
                flights = flights.Where(f => f.FromCity.Contains(fromCity));

            if (!string.IsNullOrEmpty(toCity))
                flights = flights.Where(f => f.ToCity.Contains(toCity));

            if (date.HasValue)
                flights = flights.Where(f => f.Date.Date == date.Value.Date);

            return View(flights.ToList());
        }

    }
}
