using Estudies.Logging.Elastic.Kibana.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;

namespace Estudies.Logging.Elastic.Kibana.Controllers
{
    public class HomeController : Controller
    {
        readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LogInformation()
        {
            _logger.LogInformation($"HomeController. {DateTime.UtcNow}");
            return View();
        }

        public IActionResult LogError()
        {
            var exception = new Exception("Error occurred.");
            _logger.LogError(exception, "ur code iz buggy.");
            return View();
        }

        public IActionResult LogFatal()
        {
            var exception = new Exception("Fatal Error occurred.");
            _logger.LogCritical("ur app haz critical error", exception);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
