using System.Collections.Generic;
using Online_Job.Models;   // ✅ Correct namespace

namespace Online_Job.Models
{
    public static class JobStore
    {
        public static List<Job> Jobs { get; set; } = new List<Job>();
    }
}
