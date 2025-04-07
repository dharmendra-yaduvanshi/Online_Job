using System;

namespace Online_Job.Models
{
    public class ApplicationViewModel
    {
        public string ApplicantName { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public string ResumeUrl { get; set; }
        public string Status { get; set; }
        public string CompanyLogoUrl { get; set; }
        public string CompanyName { get; set; }
        public DateTime AppliedDate { get; set; }
    }
}
