namespace Online_Job.Models
{
    public class JobApplication
    {
        public int Id { get; set; }
        public string Company { get; set; }
        public string JobTitle { get; set; }
        public string Location { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } // Pending, Accepted, Rejected
    }
}
