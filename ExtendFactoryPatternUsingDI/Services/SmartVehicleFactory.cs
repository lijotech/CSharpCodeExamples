using ExtendFactoryPatternUsingDI.Interface;

namespace ExtendFactoryPatternUsingDI.Services
{
    public class SmartVehicleFactory : IVehicleFactory
    {
        private readonly LabelGenServiceFactory _labelFactory;
        public SmartVehicleFactory(LabelGenServiceFactory labelFactory)
        {
            _labelFactory = labelFactory;
        }

        public Vehicle CreateVehicle(VehicleType vehicleType)
        {
            var label = _labelFactory.GetVinLabelGenService().Generate();

            return vehicleType switch
            {
                VehicleType.Car => new SmartCar(label),
                VehicleType.Bike => new SmartBike(label),
                VehicleType.Truck => new SmartTruck(label),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }  
}
