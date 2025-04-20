using System;

namespace Online_Job.Models
{
    public class ApplicationViewModel
    {
        public int ApplicationId { get; set; }              // Correct type: int
        public string ApplicantName { get; set; }            // Applicant Name
        public string JobTitle { get; set; }                 // Job Title
        public string Location { get; set; }                 // Job Location
        public string ResumeUrl { get; set; }                // Resume download link
        public string Status { get; set; }                   // Application Status (Accepted, Rejected, Pending)
        public string CompanyLogoUrl { get; set; }           // Company logo image URL
        public string CompanyName { get; set; }              // Company name
        public DateTime AppliedDate { get; set; }            // When application was made
        public int JobId { get; set; }

        public string CoverLetter { get; set; }
   
    }
}
