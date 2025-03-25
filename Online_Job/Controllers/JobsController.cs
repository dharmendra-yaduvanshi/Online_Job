using Microsoft.AspNetCore.Mvc;
using Online_Job.Models;
using System.Collections.Generic;
using System.Linq;
using System;

public class JobsController : Controller
{
    private const int JobsPerPage = 6;  // Number of jobs to show per page

    public IActionResult Index(int page = 1)
    {
        var jobs = new List<Job>
        { new Job { Id = 1, Title = "Full Stack Developer", Location = "Pune", Level = "Senior",
                      Description = "Responsible for frontend and backend tasks.", CompanyLogo = "/img/slack.png" },
            new Job { Id = 2, Title = "Cloud Engineer", Location = "Delhi", Level = "Senior",
                      Description = "Manage cloud infrastructure.", CompanyLogo = "/img/slack.png" },
            new Job { Id = 3, Title = "Data Scientist", Location = "Bangalore", Level = "Intermediate",
                      Description = "Work with big data analytics.", CompanyLogo = "/img/slack.png" },
            new Job { Id = 4, Title = "UX/UI Designer", Location = "Mumbai", Level = "Junior",
                      Description = "Design user interfaces and experience.", CompanyLogo = "/img/google.png" },
            new Job { Id = 5, Title = "Backend Developer", Location = "Chennai", Level = "Senior",
                      Description = "Work with server-side technologies.", CompanyLogo = "/img/amazon.png" },
            new Job { Id = 6, Title = "Machine Learning Engineer", Location = "Hyderabad", Level = "Intermediate",
                      Description = "Develop machine learning models.", CompanyLogo = "/img/facebook.png" },
            new Job { Id = 7, Title = "DevOps Engineer", Location = "Bangalore", Level = "Senior",
                      Description = "Automate and improve software deployment.", CompanyLogo = "/img/azure.png" },
            new Job { Id = 8, Title = "Product Manager", Location = "Delhi", Level = "Senior",
                      Description = "Manage the development of new products.", CompanyLogo = "/img/apple.png" },
            new Job { Id = 9, Title = "Software Engineer", Location = "Kolkata", Level = "Junior",
                      Description = "Write clean, maintainable code.", CompanyLogo = "/img/microsoft.png" },
            new Job { Id = 10, Title = "Digital Marketing Specialist", Location = "Noida", Level = "Intermediate",
                      Description = "Develop online marketing strategies.", CompanyLogo = "/img/telstra.png" },
            new Job { Id = 11, Title = "Data Engineer", Location = "Pune", Level = "Senior",
                      Description = "Design and build systems for data collection and processing.", CompanyLogo = "/img/google.png" },
            new Job { Id = 12, Title = "Product Designer", Location = "Bangalore", Level = "Intermediate",
                      Description = "Create and design user-friendly product interfaces.", CompanyLogo = "/img/facebook.png" },
            new Job { Id = 13, Title = "QA Engineer", Location = "Chennai", Level = "Senior",
                      Description = "Ensure quality through testing and bug fixes.", CompanyLogo = "/img/amazon.png" },
            new Job { Id = 14, Title = "Network Engineer", Location = "Hyderabad", Level = "Intermediate",
                      Description = "Design, implement, and maintain networks.", CompanyLogo = "/img/azure.png" },
            new Job { Id = 15, Title = "Content Writer", Location = "Delhi", Level = "Junior",
                      Description = "Write and edit content for websites and blogs.", CompanyLogo = "/img/wordpress.png" },
            new Job { Id = 16, Title = "Cybersecurity Specialist", Location = "Kolkata", Level = "Senior",
                      Description = "Monitor and secure the organization’s computer systems and networks.", CompanyLogo = "/img/cisco.png" },
            new Job { Id = 17, Title = "Salesforce Developer", Location = "Mumbai", Level = "Intermediate",
                      Description = "Develop and customize Salesforce applications.", CompanyLogo = "/img/salesforce.png" },
            new Job { Id = 18, Title = "Business Analyst", Location = "Bangalore", Level = "Senior",
                      Description = "Analyze business processes and provide solutions.", CompanyLogo = "/img/ibm.png" },
            new Job { Id = 19, Title = "Cloud Architect", Location = "Noida", Level = "Senior",
                      Description = "Design and implement cloud computing strategies.", CompanyLogo = "/img/amazon-aws.png" },
            new Job { Id = 20, Title = "SEO Specialist", Location = "Delhi", Level = "Intermediate",
                      Description = "Optimize website content for search engines.", CompanyLogo = "/img/google.png" }
        };

        var pagedJobs = jobs.Skip((page - 1) * JobsPerPage).Take(JobsPerPage).ToList();
        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(jobs.Count / (double)JobsPerPage);

        return View(pagedJobs);
    }

    // Action to show the application page for a specific job
    public IActionResult Apply(int jobId)
    {
        var job = new Job
        {
            Id = jobId,
            Title = "Full Stack Developer", // Fetch job details based on jobId (this can come from a service or database)
            Location = "Pune",
            Level = "Senior",
            Description = "Responsible for frontend and backend tasks.",
            CompanyLogo = "/img/slack.png"
        };

        if (job == null)
        {
            return NotFound(); // Handle case when job is not found
        }

        return View(job); // Pass the job details to Apply.cshtml view
    }

    // POST action to handle the job application form submission
    [HttpPost]
    public IActionResult SubmitApplication(int jobId, string userName, string coverLetter)
    {
        // Handle job application logic (e.g., save to database, send confirmation, etc.)
        TempData["Message"] = "Your application has been submitted successfully!";
        return RedirectToAction("Index"); // Redirect back to the job listings page
    }
}
