using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;

namespace Online_Job.Controllers
{
    public class AccountController : Controller
    {
        // GET: Show User Login Page
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // POST: Handle User Login
        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            var storedUsername = HttpContext.Session.GetString("Username");
            var storedPassword = HttpContext.Session.GetString("Password");

            // Validate entered credentials
            if (username == storedUsername && password == storedPassword)
            {
                // Set session data after successful login
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("LoggedInUser", username);

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid login credentials.";
            return View();
        }

        // GET: Show User Registration Page
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // POST: Handle User Registration
        [HttpPost]
        public IActionResult Register(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "All fields are required!";
                return View();
            }

            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }

            try
            {
                // Store the credentials in session (or ideally, save in a database)
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Password", password);

                // Redirect to login page after successful registration
                return RedirectToAction("Login", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // GET: Show Recruiter Login Page
        [HttpGet]
        public IActionResult RecruiterLogin()
        {
            return View();
        }

        // POST: Handle Recruiter Login
        [HttpPost]
        public IActionResult RecruiterLogin(string username, string password)
        {
            var storedUsername = HttpContext.Session.GetString("RecruiterUsername");
            var storedPassword = HttpContext.Session.GetString("RecruiterPassword");

            // Validate entered credentials
            if (username == storedUsername && password == storedPassword)
            {
                // Set session data after successful login
                HttpContext.Session.SetString("IsAuthenticated", "true");
                HttpContext.Session.SetString("LoggedInUser", username);

                return RedirectToAction("Index", "Dashboard");
            }

            ViewBag.Error = "Invalid recruiter login credentials.";
            return View();
        }

        // GET: Show Recruiter Registration Page
        [HttpGet]
        public IActionResult RecruiterRegister()
        {
            return View();
        }

        // POST: Handle Recruiter Registration
        [HttpPost]
        public IActionResult RecruiterRegister(string username, string email, string password, string confirmPassword)
        {
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(email))
            {
                ViewBag.Error = "All fields are required!";
                return View();
            }

            if (password != confirmPassword)
            {
                ViewBag.Error = "Passwords do not match!";
                return View();
            }

            try
            {
                // Store the recruiter credentials in session (or ideally, save in a database)
                HttpContext.Session.SetString("RecruiterUsername", username);
                HttpContext.Session.SetString("RecruiterPassword", password);

                // Redirect to login page after successful registration
                return RedirectToAction("RecruiterLogin", "Account");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // POST: Logout User or Recruiter
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}
