using UseOfFactoryPattern.Interface;

namespace UseOfFactoryPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                IVehicle car = VehicleFactoryManager.CreateVehicle(VehicleType.Car);
                car.Design();
                car.Manufacture();
                IVehicle bike = VehicleFactoryManager.CreateVehicle(VehicleType.Bike);
                bike.Design();
                bike.Manufacture();
                IVehicle truck = VehicleFactoryManager.CreateVehicle(VehicleType.Truck);
                truck.Design();
                truck.Manufacture();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }

    //Models
    public class Car : IVehicle
    {
        public void Design() => Console.WriteLine("Designing a car...");
        public void Manufacture() => Console.WriteLine("Manufacturing a car...");
    }
    public class Bike : IVehicle
    {
        public void Design() => Console.WriteLine("Designing a bike...");
        public void Manufacture() => Console.WriteLine("Manufacturing a bike...");
    }
    public class Truck : IVehicle
    {
        public void Design() => Console.WriteLine("Designing a truck...");
        public void Manufacture() => Console.WriteLine("Manufacturing a truck...");
    }

    //Factories
    public class CarFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle() => new Car();
    }
    public class BikeFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle() => new Bike();
    }
    public class TruckFactory : IVehicleFactory
    {
        public IVehicle CreateVehicle() => new Truck();
    }
}
