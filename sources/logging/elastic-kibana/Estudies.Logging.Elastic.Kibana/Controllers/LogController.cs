using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Net;

namespace Estudies.Logging.Elastic.Kibana.Controllers
{
    [Route("api/[controller]")]
    public class LogController : Controller
    {
        readonly ILogger<LogController> _logger;

        public LogController(ILogger<LogController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Status")]
        public string Get()
        {
            return HttpStatusCode.OK.ToString();
        }

        [HttpPost("Information")]
        public void PostInformation(string message)
        {
            _logger.LogInformation(message);
        }

        [HttpPost("Error")]
        public void PostError(string message)
        {
            var exception = new Exception(message);
            _logger.LogError(exception, "Error occurred.");
        }

        [HttpPost("Fatal")]
        public void PostFatal(string message)
        {
            var exception = new Exception(message);
            _logger.LogCritical("Fatal Error occurred", exception);
        }
    }
}
