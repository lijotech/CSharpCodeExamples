using Microsoft.AspNetCore.Mvc;
using UseOfDecoratorPattern.Services;

namespace UseOfDecoratorPattern.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IDataService _dataService;
        public HomeController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("GetData")]
        public IActionResult GetData()
        {
            var data = _dataService.GetData();
            return Ok(data);
        }
    }
}
