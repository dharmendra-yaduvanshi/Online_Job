using System;
using System.Collections.Generic;

namespace Online_Job.Models
{
    public class Job
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Location { get; set; }
        public required string Level { get; set; }
        public required string Description { get; set; }
        public required string CompanyLogo { get; set; }
        public string CTC { get; set; }
        public string CompanyName { get; set; }

        public DateTime PostedDate { get; set; }
        public int ApplicantsCount { get; set; }
        public bool IsVisible { get; set; }

        // Initialize lists to avoid null reference exceptions
        public List<string> Responsibilities { get; set; } = new List<string>();
        public List<string> Skills { get; set; } = new List<string>();
        public List<Job> RelatedJobs { get; set; } = new List<Job>();
    }
}
