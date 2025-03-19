using Microsoft.AspNetCore.Mvc;

namespace Online_Job.Controllers
{
    public class JobApplicationsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
