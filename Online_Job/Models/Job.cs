namespace Online_Job.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;  // Job title
        public string Location { get; set; } = string.Empty;  // Job location
        public string Level { get; set; } = string.Empty;  // Job level (e.g., junior, senior)
        public string Description { get; set; } = string.Empty;  // Job description
        public string CompanyLogo { get; set; } = string.Empty;  // Path to company logo
        public string CTC { get; set; } = string.Empty;  // Cost to company
        public string CompanyName { get; set; } = string.Empty;  // Company name
        public DateTime PostedDate { get; set; } = DateTime.Now;  // Date when the job was posted
        public int ApplicantsCount { get; set; }  // Number of applicants
        public bool IsVisible { get; set; } = true;  // Visibility of the job
        public DateTime Date { get; set; } = DateTime.Now;  // Date the job was created
        public string UserName { get; set; } = string.Empty;  // User who posted the job
        public List<string> Responsibilities { get; set; } = new List<string>();  // Responsibilities for the job
        public List<string> Skills { get; set; } = new List<string>();  // Required skills for the job
        public List<Job> RelatedJobs { get; set; } = new List<Job>();  // List of related jobs
        public string Category { get; set; } = string.Empty;  // Job category (e.g., IT, Marketing)
        public int Salary { get; set; }  // Salary for the job
    }
}
