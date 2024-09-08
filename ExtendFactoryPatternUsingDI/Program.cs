using ExtendFactoryPatternUsingDI.Interface;
using ExtendFactoryPatternUsingDI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;

namespace ExtendFactoryPatternUsingDI
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            try
            {
                var service = host.Services.GetService<VinLabelGenService>()!;
                Console.WriteLine("Vin label generated using DI-resolved service instance.");
                Console.WriteLine(service.Generate());

                var serviceFactory = host.Services.GetService<LabelGenServiceFactory>()!.GetVinLabelGenService();
                Console.WriteLine("Vin label generated using factory instance.");
                Console.WriteLine(serviceFactory.Generate());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            ConfigureServices(services);
        });

        private static void ConfigureServices(IServiceCollection services)
        {
            // Register your services here
            services.AddSingleton<IPrefixGenService, PrefixGenService>();
            services.AddSingleton<LabelGenServiceFactory>();
            services.AddSingleton<VinLabelGenService>(serviceProvider =>
            {
                return new VinLabelGenService(Contants.VINPREFIX);
            });
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