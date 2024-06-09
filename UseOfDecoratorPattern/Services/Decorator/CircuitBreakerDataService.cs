using System.Diagnostics;
using UseOfDecoratorPattern.Helper;

namespace UseOfDecoratorPattern.Services.Decorator
{
    public class CircuitBreakerDataService : IExternalDataService
    {
        private readonly IExternalDataService _dataService;
        private readonly ICircuitBreaker _circuitBreaker;

        /// <summary>
        /// Helps check if the external service has any exception then enable circuit breaking.
        /// </summary>
        public CircuitBreakerDataService(IExternalDataService dataService, ICircuitBreaker circuitBreaker)
        {
            _dataService = dataService;
            _circuitBreaker = circuitBreaker;
        }
        
        public async Task<List<int>> GetExternalDataAsync()
        {          
            try
            {
                if (_circuitBreaker.IsOpen)
                {
                    throw new CircuitBreakerException("Circuit breaker is open");
                }
                var forecast = await _dataService.GetExternalDataAsync();
                _circuitBreaker.Reset();
                return forecast;
            }
            catch (Exception)
            {
                _circuitBreaker.Trip();
                throw;
            }
        }
    }
}
