using Microsoft.AspNetCore.Mvc;
using Online_Job.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Online_Job.Controllers
{
    public class JobsController : Controller
    {
        private const int JobsPerPage = 9;

        // Mock job list
        private List<Job> GetJobList()
        {
            return new List<Job>
            {
                new Job { Id = 1, Title = "Full Stack Developer", Location = "Pune", Level = "Senior", Description = "You will be responsible for frontend and backend development tasks.", CompanyLogo = "/img/slack.png" },
                new Job { Id = 2, Title = "Cloud Engineer", Location = "Delhi", Level = "Senior", Description = "Manage cloud infrastructure.", CompanyLogo = "/img/slack.png" },
                new Job { Id = 3, Title = "Data Scientist", Location = "Bangalore", Level = "Intermediate", Description = "Work with big data analytics.", CompanyLogo = "/img/slack.png" },
                new Job { Id = 4, Title = "UX/UI Designer", Location = "Mumbai", Level = "Junior", Description = "Design user interfaces and experiences.", CompanyLogo = "/img/google.png" },
                new Job { Id = 5, Title = "Backend Developer", Location = "Chennai", Level = "Senior", Description = "Work with server-side technologies.", CompanyLogo = "/img/amazon.png" },
                new Job { Id = 6, Title = "Machine Learning Engineer", Location = "Hyderabad", Level = "Intermediate", Description = "Develop machine learning models.", CompanyLogo = "/img/facebook.png" },
                new Job { Id = 7, Title = "DevOps Engineer", Location = "Bangalore", Level = "Senior", Description = "Automate and improve software deployment.", CompanyLogo = "/img/azure.png" },
                new Job { Id = 8, Title = "Product Manager", Location = "Delhi", Level = "Senior", Description = "Manage the development of new products.", CompanyLogo = "/img/apple.png" },
                new Job { Id = 9, Title = "Software Engineer", Location = "Kolkata", Level = "Junior", Description = "Write clean, maintainable code.", CompanyLogo = "/img/microsoft.png" },
                new Job { Id = 10, Title = "Digital Marketing Specialist", Location = "Noida", Level = "Intermediate", Description = "Develop online marketing strategies.", CompanyLogo = "/img/telstra.png" },
                new Job { Id = 11, Title = "Network Administrator", Location = "Pune", Level = "Intermediate", Description = "Maintain and support network infrastructure.", CompanyLogo = "/img/cisco.png" },
                new Job { Id = 12, Title = "Game Developer", Location = "Bangalore", Level = "Junior", Description = "Develop engaging games for various platforms.", CompanyLogo = "/img/unity.png" },
                new Job { Id = 13, Title = "Cybersecurity Analyst", Location = "Hyderabad", Level = "Senior", Description = "Monitor and secure IT infrastructure.", CompanyLogo = "/img/kaspersky.png" },
                new Job { Id = 14, Title = "Content Writer", Location = "Delhi", Level = "Junior", Description = "Create and manage content for various platforms.", CompanyLogo = "/img/wordpress.png" },
                new Job { Id = 15, Title = "Mobile App Developer", Location = "Mumbai", Level = "Intermediate", Description = "Build and maintain mobile applications.", CompanyLogo = "/img/android.png" }
            };
        }

        public IActionResult Index(int page = 1)
        {
            var jobs = GetJobList();
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling(jobs.Count / (double)JobsPerPage);

            var pagedJobs = jobs.Skip((page - 1) * JobsPerPage).Take(JobsPerPage).ToList();
            return View(pagedJobs);
        }

        public IActionResult Learnmore(int id)
        {
            var job = GetJobList().FirstOrDefault(j => j.Id == id);
            if (job == null) return NotFound();
            return View(job);
        }

        public IActionResult Apply(int jobId)
        {
            var job = GetJobList().FirstOrDefault(j => j.Id == jobId);
            if (job == null) return NotFound();
            return View(job);
        }

        [HttpPost]
        public IActionResult SubmitApplication(int jobId, string userName, string coverLetter)
        {
            TempData["Message"] = "Your application has been submitted successfully!";
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult EditResume()
        {
            return View(); // Looks for Views/Job/EditResume.cshtml
        }

        [HttpGet]
        public IActionResult Search(string jobTitle, string location)
        {
            if (string.IsNullOrEmpty(jobTitle) && string.IsNullOrEmpty(location))
            {
                ViewBag.Message = "Please enter a job title or location.";
                return View("SearchResults", new List<Job>());
            }

            var filteredJobs = GetJobList().Where(j =>
                (string.IsNullOrEmpty(jobTitle) || j.Title.Contains(jobTitle, StringComparison.OrdinalIgnoreCase)) &&
                (string.IsNullOrEmpty(location) || j.Location.Contains(location, StringComparison.OrdinalIgnoreCase))
            ).ToList();

            ViewBag.Message = filteredJobs.Any()
                ? $"Found {filteredJobs.Count} job(s) matching your criteria."
                : "No jobs found.";

            return View("SearchResults", filteredJobs);
        }
    }
}
