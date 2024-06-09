namespace UseOfDecoratorPattern.Services
{
    public class DataService: IDataService
    {        
        /// <summary>
        /// Get required data from the database or other service.
        /// </summary>
        /// <returns></returns>
        public List<int> GetData()
        {
            var data = new List<int>();

            for (var i = 0; i < 10; i++)
            {
                data.Add(i);

                Thread.Sleep(500);
            }
            return data;
        }
    }
}
