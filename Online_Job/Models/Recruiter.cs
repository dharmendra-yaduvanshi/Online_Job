using System.ComponentModel.DataAnnotations;

namespace Online_Job.Models
{
    public class Recruiter
    {
        public int Id { get; set; }

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public string FullName { get; set; }

        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string PasswordHash { get; set; } // Store hashed password
    }
}
