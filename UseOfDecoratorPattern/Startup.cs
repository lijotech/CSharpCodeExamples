﻿using Microsoft.Extensions.Caching.Memory;
using UseOfDecoratorPattern.Services;
using UseOfDecoratorPattern.Services.Decorator;

namespace UseOfDecoratorPattern
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
            services.AddMemoryCache();

            services.AddSingleton<ICircuitBreaker, CircuitBreaker>();
            services.AddScoped(serviceProvider =>
            {
                var logger = serviceProvider.GetService<ILogger<LoggingDataService>>();
                var memoryCache = serviceProvider.GetService<IMemoryCache>();

                IDataService concreteService = new DataService();
                IDataService cachingDecorator = new CachingDataService(concreteService, memoryCache);
                IDataService loggingDecorator = new LoggingDataService(cachingDecorator, logger);

                return loggingDecorator;
            });

            services.AddScoped(serviceProvider =>
            {
                var circuitBreaker = serviceProvider.GetService<ICircuitBreaker>();

                IExternalDataService concreteService = new ExternalDataService();
                IExternalDataService circuitBreakerDecorator = new CircuitBreakerDataService(concreteService, circuitBreaker);

                //if we want to exclude circuit breaking then replace the below with `concreteService` 
                return circuitBreakerDecorator;
            });
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
