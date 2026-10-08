using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingsProject.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error()
        {
            return View();
        }

        public IActionResult StatusCode404()
        {
            return View("NotFound");
        }
    }

}
