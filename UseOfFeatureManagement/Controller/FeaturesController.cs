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

        // Endpoint for PercentageFilter
        [HttpGet("PercentageFeature")]
        public async Task<IActionResult> GetPercentageFeature()
        {
            if (await _featureManager.IsEnabledAsync("PercentageFeature"))
            {
                return Ok("Percentage feature is enabled");
            }
            else
            {
                return BadRequest("Percentage feature is disabled");
            }
        }

        [HttpGet("CustomLanguageFilter")]
        public async Task<IActionResult> CustomFilter()
        {
            if (await _featureManager.IsEnabledAsync("CustomLanguageFilter"))
            {
                return Ok("Custom Language Filter enabled");
            }
            else
            {
                return BadRequest("Custom Language Filter not enabled");
            }
        }
    }
}
