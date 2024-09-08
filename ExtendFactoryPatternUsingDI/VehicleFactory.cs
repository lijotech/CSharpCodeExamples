using ExtendFactoryPatternUsingDI.Interface;
using ExtendFactoryPatternUsingDI.Services;

namespace ExtendFactoryPatternUsingDI
{
    public  class VehicleFactory: IVehicleFactory
    {
        private readonly LabelGenServiceFactory _labelFactory;
        public VehicleFactory(LabelGenServiceFactory labelFactory)
        {
            _labelFactory = labelFactory;
        }

        public Vehicle CreateVehicle(VehicleType vehicleType)
        {
            var label = _labelFactory.GetVinLabelGenService().Generate();

            return vehicleType switch
            {
                VehicleType.Car => new Car(label),
                VehicleType.Bike => new Bike(label),
                VehicleType.Truck => new Truck(label),
                _ => throw new ArgumentException("Invalid vehicle type")
            };
        }
    }
}