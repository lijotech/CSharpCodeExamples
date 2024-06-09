using Microsoft.Extensions.Caching.Memory;

namespace UseOfDecoratorPattern.Services.Decorator
{
    public class CachingDataService : IDataService
    {
        private const string cacheKey = "data-cachekey";
        private const int expireTimeInMinutes = 120;

        private readonly IDataService _dataService;
        private readonly IMemoryCache _memoryCache;

        public CachingDataService(IDataService dataService, IMemoryCache memoryCache)
        {
            _dataService = dataService;
            _memoryCache = memoryCache;
        }

        public List<int> GetData()
        {
            if (!_memoryCache.TryGetValue<List<int>>(cacheKey, out var data))
            {
                data = _dataService.GetData();
                _memoryCache.Set(cacheKey, data, TimeSpan.FromMinutes(expireTimeInMinutes));
            }
            return data;
        }
    }
}
