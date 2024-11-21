using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApp.Models;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private static List<User> users = new();

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (users.Any(u => u.Username == user.Username))
                {
                    ModelState.AddModelError("Username", "Username already exists.");
                    return View(user);
                }
                users.Add(user);
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var user = users.FirstOrDefault(u => u.Username == username && u.Password == password);
            if (user != null)
            {
                TempData["Username"] = user.Username;
                return RedirectToAction("Profile");
            }
            ModelState.AddModelError("", "Invalid login attempt.");
            return View();
        }

        [Authorize]
        public IActionResult Profile()
        {
            var username = TempData["Username"] as string;
            if (username == null) return RedirectToAction("Login");

            var user = users.FirstOrDefault(u => u.Username == username);
            return View(user);
        }
    }
}
