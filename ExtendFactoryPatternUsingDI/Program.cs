using ExtendFactoryPatternUsingDI.Interface;
using ExtendFactoryPatternUsingDI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;

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

                var vehicleFactory = host.Services.GetService<IVehicleFactory>()!;
                Console.WriteLine("Car design generated using factory instance using condition.");
                vehicleFactory.CreateVehicle(VehicleType.Car).Design();
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
            services.AddTransient<IVehicleFactory, VehicleFactory>();
            services.AddSingleton<LabelGenServiceFactory>();
            services.AddSingleton<VinLabelGenService>(serviceProvider =>
            {
                return new VinLabelGenService(Contants.VINPREFIX);
            });
        }
    }

    //Models
    public class Car(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing a car with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a car...");
    }
    public class Bike(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing a bike with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a bike...");
    }
    public class Truck(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing a truck with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a truck...");
    }
}