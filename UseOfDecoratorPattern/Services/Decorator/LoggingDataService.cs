using System.Diagnostics;

namespace UseOfDecoratorPattern.Services.Decorator
{    
    public class LoggingDataService : IDataService
    {
        private readonly IDataService _dataService;
        private readonly ILogger<LoggingDataService> _logger;

        /// <summary>
        /// Helps to log the details and also track the metrics
        /// </summary>
        public LoggingDataService(IDataService dataService, ILogger<LoggingDataService> logger)
        {
            _dataService = dataService;
            _logger = logger;
        }

        public List<int> GetData()
        {
            _logger.LogInformation("Starting to get data");
            var stopwatch = Stopwatch.StartNew();
            var data = _dataService.GetData();
            stopwatch.Stop();
            var elapsedTime = stopwatch.ElapsedMilliseconds;
            _logger.LogInformation("Finished getting data in {elapsedTime} milliseconds", elapsedTime);
            return data;
        }
    }
}
