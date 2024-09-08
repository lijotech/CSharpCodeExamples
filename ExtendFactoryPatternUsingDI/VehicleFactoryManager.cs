using ExtendFactoryPatternUsingDI.Interface;

namespace ExtendFactoryPatternUsingDI
{
    public static class VehicleFactoryManager
    {
        /// <summary>
        /// the dictionary to map each VehicleType to its corresponding factory.
        /// </summary>
        private static readonly Dictionary<VehicleType, IVehicleFactory> _factories = new Dictionary<VehicleType, IVehicleFactory>
         {
             { VehicleType.Car, new CarFactory() },
             { VehicleType.Bike, new BikeFactory() },
             { VehicleType.Truck, new TruckFactory() }
         };

        /// <summary>
        /// The CreateVehicle method retrieves the appropriate factory from the dictionary and uses it to create the vehicle.
        /// </summary>
        /// <param name="vehicleType"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static IVehicle CreateVehicle(VehicleType vehicleType)
        {
            if (_factories.TryGetValue(vehicleType, out var factory))
            {
                return factory.CreateVehicle();
            }
            throw new ArgumentException("Invalid vehicle type");
        }
    }
}
