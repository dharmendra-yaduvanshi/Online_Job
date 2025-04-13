    using Microsoft.AspNetCore.Mvc;
    using Online_Job.Models;
    using System;
    using System.Collections.Generic;

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
                // Mock job data - replace this with a DB call in production
                var jobs = new List<Job>
                {
                    new Job { Id = 1, Title = "Full Stack Developer", Date = DateTime.Now, Location = "Bangalore", ApplicantsCount = 20, IsVisible = true },
                    new Job { Id = 2, Title = "Data Scientist", Date = DateTime.Now.AddDays(-10), Location = "New York", ApplicantsCount = 15, IsVisible = true },
                    new Job { Id = 3, Title = "UI/UX Designer", Date = DateTime.Now.AddDays(-5), Location = "Mumbai", ApplicantsCount = 10, IsVisible = true },
                    new Job { Id = 4, Title = "DevOps Engineer", Date = DateTime.Now.AddDays(-3), Location = "London", ApplicantsCount = 12, IsVisible = true }
                };

                return View(jobs);
            }

            public IActionResult ViewApplications()
            {
                var applications = new List<ApplicationViewModel>
        {
            new ApplicationViewModel
            {
                ApplicantName = "John Doe",
                JobTitle = "Software Developer",
                Location = "New York",
                ResumeUrl = "/resumes/johndoe.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "Jane Smith",
                JobTitle = "UI/UX Designer",
                Location = "San Francisco",
                ResumeUrl = "/resumes/janesmith.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "Michael Johnson",
                JobTitle = "Data Analyst",
                Location = "Chicago",
                ResumeUrl = "/resumes/michaeljohnson.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "Emily Brown",
                JobTitle = "Marketing Specialist",
                Location = "Seattle",
                ResumeUrl = "/resumes/emilybrown.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "David Lee",
                JobTitle = "DevOps Engineer",
                Location = "Austin",
                ResumeUrl = "/resumes/davidlee.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "Sophia Wilson",
                JobTitle = "Content Writer",
                Location = "Boston",
                ResumeUrl = "/resumes/sophiawilson.pdf"
            },
            new ApplicationViewModel
            {
                ApplicantName = "Chris Evans",
                JobTitle = "Product Manager",
                Location = "Los Angeles",
                ResumeUrl = "/resumes/chrisevans.pdf"
            }
        };

                return View(applications);
            }

            public IActionResult Logout()
            {
                return RedirectToAction("Login", "Account");
            }

            [HttpPost]
            public IActionResult SaveJob(string jobTitle, string jobDescription, string category, string location, string level, int salary)
            {
                // In a real app, you would save to DB here using EF Core or similar
                TempData["Message"] = "Job added successfully!";
                return RedirectToAction("ManageJobs");
            }
        }

 
    }
