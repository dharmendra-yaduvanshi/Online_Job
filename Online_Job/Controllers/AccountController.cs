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
                // Normally, save the user to the database here

                // After successful registration, store credentials in session
                HttpContext.Session.SetString("Username", username);
                HttpContext.Session.SetString("Password", password);

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
        public IActionResult RecruiterLogin(string email, string password)
        {
            // Simple validation (Replace with proper validation logic)
            if (email == "recruiter@example.com" && password == "password123")
            {
                // Store recruiter info in session after successful login
                HttpContext.Session.SetString("RecruiterUsername", email);  // Store email in session

                return RedirectToAction("Dashboard", "Recruiter");  // Redirect to Recruiter Dashboard
            }

            ViewBag.Error = "Invalid email or password.";
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
        public IActionResult RecruiterRegister(string companyName, string fullName, string email, string password, string confirmPassword)
        {
            // Basic input validation
            if (string.IsNullOrEmpty(companyName) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
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
                // Save recruiter details to the database (Typically done via a service)

                // After successful registration, redirect to recruiter login page
                return RedirectToAction("RecruiterLogin");
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // POST: Logout User or Recruiter (Clear session data)
        [HttpPost]
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Account");
        }
    }
}
