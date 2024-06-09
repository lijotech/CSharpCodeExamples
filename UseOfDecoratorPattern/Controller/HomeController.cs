using Microsoft.AspNetCore.Mvc;
using UseOfDecoratorPattern.Helper;
using UseOfDecoratorPattern.Services;

namespace UseOfDecoratorPattern.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDataService _dataService;
        private readonly IExternalDataService _externalDataService;
        public HomeController(IDataService dataService, IExternalDataService externalDataService)
        {
            _dataService = dataService;
            _externalDataService = externalDataService;
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var data = _dataService.GetData();
            return Ok(data);
        }

        [HttpGet("GetExternalData")]
        public async Task<IActionResult> GetExternalData()
        {
            try
            {
                var data = await _externalDataService.GetExternalDataAsync();
                return Ok(data);
            }
            catch (CircuitBreakerException)
            {
                return BadRequest("Circuit breaker exception.");
            }
            catch (Exception)
            {
                return BadRequest("Unknown error.");
            }
        }
    }
}
