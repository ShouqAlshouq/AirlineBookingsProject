using AirlineBookingsProject.Data;
using AirlineBookingsProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AirlineBookingsProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public AccountController(AppDbContext ctx,
                                 UserManager<User> userManager,
                                 SignInManager<User> signInManager)
        {
            _dbContext = ctx;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            HttpContext.Session.Clear();

            Response.Cookies.Delete("LastFromCity");
            Response.Cookies.Delete("LastToCity");
            Response.Cookies.Delete("LastDate");

            return RedirectToAction("Login");
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            var photos = new List<string> { "noimage.jpg", "womanimage.jpg", "manimage.jpg" };
            ViewBag.PhotoList = new SelectList(photos);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User u, string password)
        {
            if (ModelState.IsValid)
            {
                int userCount = _dbContext.Users.Count();
                int nextNumber = userCount + 1;
                u.Id = "U" + nextNumber.ToString().PadLeft(3, '0');

                u.UserName = u.Email;

                var result = await _userManager.CreateAsync(u, password);

                if (result.Succeeded)
                {
                    return Redirect("/Users/Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            var photos = new List<string> { "noimage.jpg", "womanimage.jpg", "manimage.jpg" };
            ViewBag.PhotoList = new SelectList(photos);
            return View(u);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string email, string password)
        {
            var user = await _userManager.FindByEmailAsync(email);

            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (result.Succeeded)
                {
                    HttpContext.Session.SetString("UserId", user.Id);
                    HttpContext.Session.SetString("UserName", user.FullName);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    if (user.Role == "Admin")
                    {
                        return RedirectToAction("Index", "Admin");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }

                }
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }
        [AllowAnonymous]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
