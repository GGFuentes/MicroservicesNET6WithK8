using Microsoft.AspNetCore.Mvc;

namespace MS.AFORO255.Account.Controllers
{
    [Route("")]
    [ApiController]
    public class HomeController : ControllerBase
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
