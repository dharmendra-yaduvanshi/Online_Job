using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Online_Job.Controllers
{
    public class AccountController : Controller
    {
        // ✅ GET: Show User Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // ✅ POST: Handle User Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            // Example: Retrieve stored username and password from session (replace with real validation)
            var storedUsername = HttpContext.Session.GetString("Username");
            var storedPassword = HttpContext.Session.GetString("Password");

            // Validate the entered credentials
            if (username == storedUsername && password == storedPassword)
            {
                // If credentials are correct, store username in session and redirect to home page
                HttpContext.Session.SetString("Username", username);
                return RedirectToAction("Index", "Home");
            }

            // If login fails, show error
            ViewBag.Error = "Invalid login credentials.";
            return View();
        }

        // ✅ GET: Show User Registration Page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // ✅ POST: Handle User Registration
        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword)
        {
            // Validate that all fields are filled in
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "All fields are required!";
                return View();
            }

            // Check if passwords match
            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }

            try
            {
                // Normally, you would save the user to the database here
                // Example: SaveUserToDatabase(username, email, password);

                // After successful registration, store the credentials in session (not recommended for real apps)
                HttpContext.Session.SetString("Username", username); // Store username in session
                HttpContext.Session.SetString("Password", password); // Store password in session (hashed passwords are recommended)

                // Redirect to the login page after successful registration
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // ✅ POST: Logout User (Clear session data)
        [HttpPost]
        public IActionResult Logout()
        {
            // Clear session data (log out the user)
            HttpContext.Session.Clear();

            // Redirect to login page after logging out
            return RedirectToAction("Login");
        }
    }
}
