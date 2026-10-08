using AirlineBookingsProject.Data;
using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AirlineBookingsProject.Controllers
{
    [Authorize]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;

        public UsersController(UserManager<User> userManager, AppDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _userManager.GetUserAsync(User);

            ViewBag.PhotoList = new List<string>
            {
                "noimage.jpg",
                "womanimage.jpg",
                "manimage.jpg"
            };

            var bookings = _dbContext.Bookings
                .Where(b => b.UserId == user.Id)
                .Include(b => b.Flight)
                .ToList();

            ViewBag.Bookings = bookings;

            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Profile(User updatedUser)
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
                return RedirectToAction("Login", "Account");

            user.FullName = updatedUser.FullName;
            user.PhoneNumber = updatedUser.PhoneNumber;
            user.UserPhoto = updatedUser.UserPhoto;

            await _userManager.UpdateAsync(user);

            return RedirectToAction("Profile");
        }
    }
}
