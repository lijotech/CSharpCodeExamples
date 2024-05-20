using Microsoft.FeatureManagement;

namespace UseOfFeatureManagement
{
    [FilterAlias(nameof(LanguageFilter))]
    public class LanguageFilter : IFeatureFilter
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LanguageFilter(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public Task<bool> EvaluateAsync(FeatureFilterEvaluationContext context)
        {
            var userLanguage = _httpContextAccessor?.HttpContext?.Request.Headers.AcceptLanguage.ToString();
            var settings = context.Parameters.Get<LanguageFilterSettings>();
            return Task.FromResult(settings.AllowedLanguages.Any(a => userLanguage.Contains(a)));
        }
    }

    public class LanguageFilterSettings
    {
        public string[] AllowedLanguages { get; set; }
    }
}
