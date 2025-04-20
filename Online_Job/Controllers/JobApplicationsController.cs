using Microsoft.AspNetCore.Mvc;
using Online_Job.Models; // Make sure you import your models namespace
using System.Collections.Generic;
using System.Linq;

namespace Online_Job.Controllers
{
    public class JobApplicationsController : Controller
    {
        // Dummy in-memory list (replace this with your database logic)
        private static List<ApplicationViewModel> Applications = new List<ApplicationViewModel>
        {
            new ApplicationViewModel { ApplicationId = 1, ApplicantName = "John Doe", JobTitle = "Software Developer", Location = "New York", ResumeUrl = "/resumes/john_resume.pdf", Status = "Pending" },
            new ApplicationViewModel { ApplicationId = 2, ApplicantName = "Jane Smith", JobTitle = "Graphic Designer", Location = "California", ResumeUrl = "/resumes/jane_resume.pdf", Status = "Pending" }
        };

        // Show applications
        public IActionResult ViewApplications()
        {
            return View(Applications);
        }

        // Accept application (via POST for AJAX)
        [HttpPost]
        public IActionResult Accept(int id)
        {
            var application = Applications.FirstOrDefault(a => a.ApplicationId == id);
            if (application != null)
            {
                // Update status
                application.Status = "Accepted";
            }

            // Return JSON response to the client
            return Json(new { success = true });
        }

        // Reject application (via POST for AJAX)
        [HttpPost]
        public IActionResult Reject(int id)
        {
            var application = Applications.FirstOrDefault(a => a.ApplicationId == id);
            if (application != null)
            {
                // Optionally, update the status or remove the application
                application.Status = "Rejected";  // You can use this to track rejected status
                Applications.Remove(application); // Remove from list if needed
            }

            // Return JSON response to the client
            return Json(new { success = true });
        }

        public IActionResult Index()
        {
            return RedirectToAction("ViewApplications");
        }
    }
}
