using Microsoft.AspNetCore.Mvc;

namespace MS.AFORO255.Security.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("ping")]
        public IActionResult Ping()
        {
            _logger.LogDebug("Ping ...");
            return Ok();
        }
    }
}
