using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Online_Job.Models;
using System.Diagnostics;

namespace Online_Job.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            // Check if the user is authenticated and set the username in ViewBag
            if (User.Identity.IsAuthenticated)
            {
                ViewBag.Username = User.Identity.Name;
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
