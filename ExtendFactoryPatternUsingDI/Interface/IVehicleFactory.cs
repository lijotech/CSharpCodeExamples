namespace ExtendFactoryPatternUsingDI.Interface
{
    public interface IVehicleFactory
    {
        Vehicle CreateVehicle(VehicleType vehicleType);
    }
}
