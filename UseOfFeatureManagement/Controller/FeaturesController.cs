using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;

namespace UseOfFeatureManagement.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IFeatureManager _featureManager;

        public FeaturesController(IFeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        // Endpoint for BooleanFilter
        [HttpGet("BooleanFeature")]
        public async Task<IActionResult> GetBooleanFeature()
        {
            if (await _featureManager.IsEnabledAsync("BooleanFeature"))
            {
                return Ok("Boolean feature is enabled");
            }
            else
            {
                return BadRequest("Boolean feature is disabled");
            }
        }
    }
}
