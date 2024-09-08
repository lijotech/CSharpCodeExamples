using ExtendFactoryPatternUsingDI.Interface;
using ExtendFactoryPatternUsingDI.Services;

namespace ExtendFactoryPatternUsingDI
{
    public class VehicleFactoryManager
    {
        private readonly IEnumerable<IVehicleFactory> _vehicleFactories;
        public VehicleFactoryManager(IEnumerable<IVehicleFactory> deviceFactories)
        {
            _vehicleFactories = deviceFactories;
        }
        public IVehicleFactory GetClassicFactory()
        {
            return _vehicleFactories.OfType<VehicleFactory>()
                .FirstOrDefault()!;
        }
        public IVehicleFactory GetSmartFactory()
        {
            return _vehicleFactories.OfType<SmartVehicleFactory>()
                .FirstOrDefault()!;
        }
    }
}
