using Microsoft.FeatureManagement;
using Microsoft.FeatureManagement.FeatureFilters;

namespace UseOfFeatureManagement
{
    public class Startup
    {
        public IConfiguration _configuration { get; }
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();

            services.AddHttpContextAccessor();
            services.AddSingleton<ITargetingContextAccessor, CustomTargetingContextAccessor>();
            services.AddFeatureManagement().AddFeatureFilter<LanguageFilter>().AddFeatureFilter<TargetingFilter>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseSwagger();

            app.UseSwaggerUI();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
