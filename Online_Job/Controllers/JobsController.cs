using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Online_Job.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace Online_Job.Controllers
{
    public class JobController : Controller
    {
        public IActionResult Applied()
        {
            var applications = new List<ApplicationViewModel>
            {
                new ApplicationViewModel { ApplicantName = "Dharmendra", JobTitle = "Full Stack Developer", Location = "Bangalore", ResumeUrl = "/resumes/Dharmendra_resume.pdf", Status = "Pending", CompanyLogoUrl = "/images/Amazon.png", CompanyName = "Amazon", AppliedDate = new DateTime(2025, 3, 22) },
                new ApplicationViewModel { ApplicantName = "Dharmendra Kumar", JobTitle = "UI/UX Designer", Location = "Mumbai", ResumeUrl = "/resumes/uttam_resume.pdf", Status = "Accepted", CompanyLogoUrl = "/images/google.jpg", CompanyName = "Google", AppliedDate = new DateTime(2025, 3, 18) },
                new ApplicationViewModel { ApplicantName = "Uttam", JobTitle = "DevOps Engineer", Location = "Hyderabad", ResumeUrl = "/resumes/uttam_resume.pdf", Status = "Rejected", CompanyLogoUrl = "/images/azure.jpg", CompanyName = "Microsoft Azure", AppliedDate = new DateTime(2025, 3, 12) },
                new ApplicationViewModel { ApplicantName = "Uttam", JobTitle = "Machine Learning Engineer", Location = "Chennai", ResumeUrl = "/resumes/uttam_resume.pdf", Status = "Interview Scheduled", CompanyLogoUrl = "/images/facebook.png", CompanyName = "Facebook", AppliedDate = new DateTime(2025, 3, 25) },
                new ApplicationViewModel { ApplicantName = "Uttam", JobTitle = "Cybersecurity Analyst", Location = "Delhi", ResumeUrl = "/resumes/uttam_resume.pdf", Status = "Accepted", CompanyLogoUrl = "/images/kaspersky.png", CompanyName = "Kaspersky", AppliedDate = new DateTime(2025, 3, 28) }
            };

            return View(applications);
        }

        [HttpGet]
        public IActionResult EditResume()
        {
            return View(); // Make sure EditResume.cshtml exists
        }

        [HttpPost]
        public IActionResult UploadResume(IFormFile resumeFile)
        {
            if (resumeFile != null && resumeFile.Length > 0)
            {
                var resumesDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes");

                if (!Directory.Exists(resumesDir))
                {
                    Directory.CreateDirectory(resumesDir);
                }

                var fileName = Path.GetFileName(resumeFile.FileName);
                var filePath = Path.Combine(resumesDir, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    resumeFile.CopyTo(stream);
                }

                TempData["Message"] = "Resume uploaded successfully!";
                TempData["ResumeUrl"] = "/resumes/" + fileName;
            }
            else
            {
                TempData["Message"] = "Please select a valid resume file.";
            }

            return RedirectToAction("Applied");
        }

        [HttpGet]
        public IActionResult DownloadResume()
        {
            var resumeFile = "resume.pdf"; // You can make this dynamic if needed
            var resumePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes", resumeFile);

            if (!System.IO.File.Exists(resumePath))
            {
                TempData["Message"] = "Resume file not found.";
                return RedirectToAction("AppliedJobs"); // or wherever you're returning
            }

            var mimeType = "application/pdf";
            return PhysicalFile(resumePath, mimeType, resumeFile);
        }

    }
}
