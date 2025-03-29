namespace JobPortal.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public DateTime PostedDate { get; set; }
        public int ApplicantsCount { get; set; }
        public bool IsVisible { get; set; }
        public string Level { get; set; }
        public string CTC { get; set; }
        public string Description { get; set; }
        public List<string> Responsibilities { get; set; } = new List<string>();
        public List<string> Skills { get; set; } = new List<string>();
        public string CompanyName { get; set; }
           // Added IsVisible
        public List<Job> RelatedJobs { get; set; } = new List<Job>();
    }
}
