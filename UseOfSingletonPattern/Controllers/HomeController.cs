using Microsoft.AspNetCore.Mvc;

namespace UseOfSingletonPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : AppControllerBase<HomeController>
    {
        public HomeController(ILogger<HomeController> logger)
         : base(logger)
        {
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            _logger.LogInformation("Request received in HomeController.");
            // Other business logic
            return Ok();
        }
    }
}