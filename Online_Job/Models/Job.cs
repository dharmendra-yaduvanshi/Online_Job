using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Online_Job.Models
{
    public class Job
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = string.Empty;

        [Required]
        public string Location { get; set; } = string.Empty;

        [Required]
        public string Level { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string CompanyLogo { get; set; } = string.Empty;

        public string CTC { get; set; } = string.Empty;

        public string CompanyName { get; set; } = string.Empty;

        public DateTime PostedDate { get; set; } = DateTime.Now;

        public int ApplicantsCount { get; set; }

        public bool IsVisible { get; set; } = true;

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        public string UserName { get; set; } = string.Empty; // To track who posted the job

        // Initialize lists to avoid null reference exceptions
        public List<string> Responsibilities { get; set; } = new List<string>();

        public List<string> Skills { get; set; } = new List<string>();

        public List<Job> RelatedJobs { get; set; } = new List<Job>();
    }

    public class Application
    {
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string JobTitle { get; set; } = string.Empty;

        [Required]
        public string ResumeUrl { get; set; } = string.Empty; // URL of uploaded resume

        public string Status { get; set; } = "Pending";

        public string? Location { get; set; }
                 // e.g., "Pending", "Accepted", "Rejected"
        public string CompanyName { get; set; }        // e.g., "Google"
        public string CompanyLogoUrl { get; set; }     // URL to logo image
        public DateTime AppliedDate { get; set; }      // Application date
       
    }   
}
