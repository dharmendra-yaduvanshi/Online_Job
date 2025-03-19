using Microsoft.AspNetCore.Mvc;

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
            if (username == "admin" && password == "password") // Replace with database validation
            {
                return RedirectToAction("Index", "Home"); // Redirect to homepage after login
            }

            ViewBag.Error = "Invalid login credentials.";
            return View();
        }

        // ✅ GET: Show Recruiter Login Page
        [HttpGet]
        public IActionResult RecruiterLogin()
        {
            return View();
        }

        // ✅ POST: Handle Recruiter Login
        [HttpPost]
        public IActionResult RecruiterLogin(string email, string password)
        {
            if (email == "recruiter@example.com" && password == "password123") // Replace with database validation
            {
                return RedirectToAction("Dashboard", "Recruiter"); // Redirect to Recruiter Dashboard
            }

            ViewBag.Error = "Invalid email or password.";
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
                // TODO: Save user details in the database

                return RedirectToAction("Login"); // Redirect to login page after successful registration
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }

        // ✅ GET: Show Recruiter Registration Page
        [HttpGet]
        public IActionResult RecruiterRegister()
        {
            return View();
        }

        // ✅ POST: Handle Recruiter Registration
        [HttpPost]
        public IActionResult RecruiterRegister(string companyName, string fullName, string email, string password, string confirmPassword)
        {
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
                // TODO: Save recruiter details in the database

                return RedirectToAction("RecruiterLogin"); // Redirect to recruiter login page
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }
    }
}
