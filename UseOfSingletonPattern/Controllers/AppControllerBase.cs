using Microsoft.AspNetCore.Mvc;

namespace UseOfSingletonPattern.Controllers
{
    /// <summary>
    /// Base class for controllers with common functionality
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class AppControllerBase<T> : Controller
    {
        protected readonly ILogger<T> _logger;

        public AppControllerBase(ILogger<T> logger)
        {
            _logger = logger;
        }
    }
}