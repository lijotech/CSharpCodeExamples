using ExtendFactoryPatternUsingDI.Enums;
using ExtendFactoryPatternUsingDI.Interface;
using ExtendFactoryPatternUsingDI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

                Console.WriteLine();
                var serviceFactory = host.Services.GetService<LabelGenServiceFactory>()!.GetVinLabelGenService();
                Console.WriteLine("Vin label generated using factory instance.");
                Console.WriteLine(serviceFactory.Generate());

                Console.WriteLine();
                var vehicleFactory = host.Services.GetService<IVehicleFactory>()!;
                Console.WriteLine("Car design generated using factory instance with conditional object instantiation.");
                vehicleFactory.CreateVehicle(VehicleType.Car).Design();

                Console.WriteLine();
                var maintanceFactory = host.Services.GetService<MaintanceServiceFactory>()!;
                Console.WriteLine("Maintance info generated using conditional service resolution.");
                Console.WriteLine(maintanceFactory.GetMaintanceService(MaintanceMode.Test).Perform("Demo"));

                Console.WriteLine();
                var oilServiceFactory = host.Services.GetService<OilServiceFactory>()!;
                Console.WriteLine("Oil service info generated using encapsulate service initialization with factory.");
                Console.WriteLine(oilServiceFactory.CreateOilService().DrainOil("DemoPerson"));

                Console.WriteLine();
                var masterFactory = host.Services.GetService<VehicleFactoryManager>()!;
                var classic = masterFactory.GetClassicFactory();
                var smart = masterFactory.GetSmartFactory();

                Console.WriteLine("Car design generated from classic family using abstract factory.");
                classic.CreateVehicle(VehicleType.Car).Design();
                Console.WriteLine();
                Console.WriteLine("Car design generated from smart family using abstract factory.");
                smart.CreateVehicle(VehicleType.Car).Design();

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
            services.AddTransient<IVehicleFactory, SmartVehicleFactory>();

            services.AddTransient<IMaintanceService, LiveMaintanceService>();
            services.AddTransient<IMaintanceService, TestMaintanceService>();
            services.AddTransient<IMaintanceService, OfflineMaintanceService>();
            services.AddSingleton<MaintanceServiceFactory>();

            services.AddSingleton<VehicleFactoryManager>();
            services.AddSingleton<OilServiceFactory>();
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

    //Maintance services
    public class LiveMaintanceService : IMaintanceService
    {
        public MaintanceMode Mode => MaintanceMode.Live;
        public string Perform(string message) => $"Live: {message}";
    }

    public class TestMaintanceService : IMaintanceService
    {
        public MaintanceMode Mode => MaintanceMode.Test;
        public string Perform(string message) => $"Test: {message}";
    }

    public class OfflineMaintanceService : IMaintanceService
    {
        public MaintanceMode Mode => MaintanceMode.Offline;
        public string Perform(string message) => $"Offline: {message}";
    }

    //Smart Models
    public class SmartCar(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing smart car with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a car...");
    }
    public class SmartBike(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing smart bike with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a bike...");
    }
    public class SmartTruck(string vinLabel) : Vehicle(vinLabel)
    {
        private readonly string _vinLabel = vinLabel;

        public override void Design() => Console.WriteLine($"Designing smart truck with vin {_vinLabel}...");
        public override void Manufacture() => Console.WriteLine("Manufacturing a truck...");
    }
}