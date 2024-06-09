namespace UseOfDecoratorPattern.Services
{
    public class ExternalDataService : IExternalDataService
    {
        public async Task<List<int>> GetExternalDataAsync()
        {
            // Implementation of external data retrivel...
            //Currently artifically creating and exception to make circuit breaker to work.
            throw new NotImplementedException();
        }
    }
}
