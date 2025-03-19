using Microsoft.AspNetCore.Mvc;

namespace Online_Job.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AddJob()
        {
            return View();
        }

        public IActionResult ManageJobs()
        {
            return View();
        }

        public IActionResult ViewApplications()
        {
            return View();
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Login", "Account");
        }

        // ✅ [HttpPost] must be inside the class
        [HttpPost]
        public IActionResult SaveJob(string jobTitle, string jobDescription, string category, string location, string level, int salary)
        {
            // Here, you can save the job details to the database
            TempData["Message"] = "Job added successfully!";
            return RedirectToAction("ManageJobs");
        }
    }
}
