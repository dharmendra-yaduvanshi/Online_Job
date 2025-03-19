namespace Online_Job.Models;

public class Job
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Location { get; set; }
    public required string Level { get; set; }
    public required string Description { get; set; }
    public required string CompanyLogo { get; set; }
    public string Company { get; set; }
   
}

