using Microsoft.FeatureManagement.FeatureFilters;
using System.Security.Claims;

namespace UseOfFeatureManagement
{
    public class CustomTargetingContextAccessor : ITargetingContextAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CustomTargetingContextAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ValueTask<TargetingContext> GetContextAsync()
        {
            var context = new TargetingContext
            {
                UserId = _httpContextAccessor.HttpContext.User.Identity.Name,
                Groups = GetUserGroups(_httpContextAccessor.HttpContext.User)
            };
            return new ValueTask<TargetingContext>(context);
        }

        private List<string> GetUserGroups(ClaimsPrincipal user)
        {
            // TODO: Implement this method based on your application's logic
            return new List<string> { "BetaTesters" };
        }
    }
}
