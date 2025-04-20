namespace Online_Job.Models
{
    public class Application
    {
        public int Id { get; set; }
        public string ApplicantName { get; set; } = string.Empty;  // Stores applicant's name
        public string JobTitle { get; set; } = string.Empty;  // Stores job title
        public string ResumeUrl { get; set; } = string.Empty;  // Stores the URL of the applicant's resume
        public string Status { get; set; } = "Pending";  // Default status set to "Pending"
        public string CompanyLogoUrl { get; set; } = string.Empty;  // Stores the URL of the company logo
        public string CompanyName { get; set; } = string.Empty;  // Stores the company name
        public DateTime AppliedDate { get; set; } = DateTime.Now;  // Date when the application was submitted
    }
}
