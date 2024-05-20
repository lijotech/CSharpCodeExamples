using Microsoft.AspNetCore.Mvc;
using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.Mvc;

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

        [HttpGet("CustomLanguageFeature")]
        public async Task<IActionResult> GetCustomFeature()
        {
            if (await _featureManager.IsEnabledAsync("CustomLanguageFeature"))
            {
                return Ok("Custom Language feature enabled");
            }
            else
            {
                return BadRequest("Custom Language feature is disabled");
            }
        }

        [HttpGet("TimeWindowFeature")]
        public async Task<IActionResult> GetTimeWindowFilter()
        {
            if (await _featureManager.IsEnabledAsync("TimeWindowFeature"))
            {
                return Ok("Time Window feature enabled");
            }
            else
            {
                return BadRequest("Time Window feature is disabled");
            }
        }

        [HttpGet("TargetingFeature")]
        public async Task<IActionResult> GetTargetingFeature()
        {
            if (await _featureManager.IsEnabledAsync("TargetingFeature"))
            {
                return Ok("Targeting feature is enabled");
            }
            else
            {
                return BadRequest("Targeting feature is disabled");
            }
        }

        [HttpGet("BooleanFeatureUsingFeatureGate")]
        [FeatureGate("BooleanFeature")]
        public async Task<IActionResult> GetBooleanFeatureUsingFeatureGate()
        {
            return Ok("Boolean feature is enabled");
        }
    }
}
