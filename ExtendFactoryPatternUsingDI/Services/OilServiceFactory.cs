namespace ExtendFactoryPatternUsingDI.Services
{
    public class OilServiceFactory
    {
        public OilService CreateOilService()
        {
            var service = new OilService();
            service.InitialCheck();
            return service;
        }
    }
}
