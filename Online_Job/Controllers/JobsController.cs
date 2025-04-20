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
        // Action for displaying the applied jobs list
        public IActionResult Applied()
        {
            var applications = new List<ApplicationViewModel>
            {
                new ApplicationViewModel
                {
                    ApplicantName = "Dharmendra",
                    JobTitle = "Full Stack Developer",
                    Location = "Bangalore",
                    ResumeUrl = "/resumes/Dharmendra_resume.pdf",
                    Status = "Pending",
                    CompanyLogoUrl = "/images/Amazon.png",
                    CompanyName = "Amazon",
                    AppliedDate = new DateTime(2025, 3, 22)
                },
                new ApplicationViewModel
                {
                    ApplicantName = "Dharmendra Kumar",
                    JobTitle = "UI/UX Designer",
                    Location = "Mumbai",
                    ResumeUrl = "/resumes/uttam_resume.pdf",
                    Status = "Accepted",
                    CompanyLogoUrl = "/images/google.jpg",
                    CompanyName = "Google",
                    AppliedDate = new DateTime(2025, 3, 18)
                },
                new ApplicationViewModel
                {
                    ApplicantName = "Uttam",
                    JobTitle = "DevOps Engineer",
                    Location = "Hyderabad",
                    ResumeUrl = "/resumes/uttam_resume.pdf",
                    Status = "Rejected",
                    CompanyLogoUrl = "/images/azure.jpg",
                    CompanyName = "Microsoft Azure",
                    AppliedDate = new DateTime(2025, 3, 12)
                },
                new ApplicationViewModel
                {
                    ApplicantName = "Uttam",
                    JobTitle = "Machine Learning Engineer",
                    Location = "Chennai",
                    ResumeUrl = "/resumes/uttam_resume.pdf",
                    Status = "Interview Scheduled",
                    CompanyLogoUrl = "/images/facebook.png",
                    CompanyName = "Facebook",
                    AppliedDate = new DateTime(2025, 3, 25)
                },
                new ApplicationViewModel
                {
                    ApplicantName = "Uttam",
                    JobTitle = "Cybersecurity Analyst",
                    Location = "Delhi",
                    ResumeUrl = "/resumes/uttam_resume.pdf",
                    Status = "Accepted",
                    CompanyLogoUrl = "/images/kaspersky.png",
                    CompanyName = "Kaspersky",
                    AppliedDate = new DateTime(2025, 3, 28)
                }
            };

            return View(applications); // Passing the applications list to the View
        }

        // Action to show the edit resume page
        [HttpGet]
        public IActionResult EditResume()
        {
            return View(); // Ensure EditResume.cshtml exists
        }

        // Action to handle resume file upload
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

                // Saving the uploaded file
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

            return RedirectToAction("Applied"); // Redirect back to the applied jobs page
        }

        // Action to download the resume
        [HttpGet]
        public IActionResult DownloadResume(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                TempData["Message"] = "No resume selected for download.";
                return RedirectToAction("Applied");
            }

            var resumePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "resumes", fileName);

            if (!System.IO.File.Exists(resumePath))
            {
                TempData["Message"] = "Resume file not found.";
                return RedirectToAction("Applied");
            }

            var mimeType = "application/pdf"; // Assuming the file is PDF, change as needed
            return PhysicalFile(resumePath, mimeType, fileName); // Return the file as a download
        }
    }
}
