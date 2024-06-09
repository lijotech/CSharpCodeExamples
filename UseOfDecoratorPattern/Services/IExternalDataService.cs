namespace UseOfDecoratorPattern.Services
{
    public interface IExternalDataService
    {
        Task<List<int>> GetExternalDataAsync();
    }
}
