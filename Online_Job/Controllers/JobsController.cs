using Microsoft.AspNetCore.Mvc;
using Online_Job.Models;
using System.Collections.Generic;

public class JobsController : Controller
{
    public IActionResult Index()
    {
        var jobs = new List<Job>
        {
            new Job { Id = 1, Title = "Full Stack Developer", Location = "Pune", Level = "Senior",
                      Description = "Responsible for frontend and backend tasks.", CompanyLogo = "/img/slack.png" },
            new Job { Id = 2, Title = "Cloud Engineer", Location = "Delhi", Level = "Senior",
                      Description = "Manage cloud infrastructure.", CompanyLogo = "/img/slack.png" },
            new Job { Id = 3, Title = "Data Scientist", Location = "Bangalore", Level = "Intermediate",
                      Description = "Work with big data analytics.", CompanyLogo = "/img/slack.png" }
        };

        return View(jobs);
    }
}
