## Extend Factory Design Pattern Using Dependency Injection (DI)


Let sus assume we have a service to generate label
```
public class VinLabelGenService
{
    public string Prefix { get; }
    public VinLabelGenService(string prefix)
    {
        Prefix = prefix;
    }
    public string Generate() => $"{Prefix}{Guid.NewGuid()}";
}
```
we cna resolve the service in DI container like this 

```
private static void ConfigureServices(IServiceCollection services)
{
    // Register your services here
    services.AddSingleton<VinLabelGenService>(serviceProvider =>
    {              
        return new VinLabelGenService(Contants.VINPREFIX);
    });
}
```
In this scenario we have not used factory pattern yet but just shown the Di reolved service resolving.


## Let us assume if the prefix is egnerated by another service. In this case we can use a factory pattern.

this is some service to get prefix. for the simplicity I as using first and last letter of current month to generate prefix
```
 public class PrefixGenService : IPrefixGenService
 {
     public string GetPrefix()
     {
         // Get the current month name
         string monthName = DateTime.Now.ToString("MMMM");

         // Get the first and last letter of the month name
         string prefix = monthName[0].ToString() + monthName[monthName.Length - 1].ToString();

         return prefix.ToUpper();
     }
 }
```

Now we can use factory to call the service to get prefix and then return the `VinLabelGenService` instance. This approach offers better encapsulation and a decoupled architecture. By doing this, we get rid of the direct dependency on a third-party service. Instead, we now can inject/resolve our own factory dependency and get access to that service 

```
   public class LabelGenServiceFactory
   {
       private readonly VinLabelGenService _vinLabelGenService;
       private readonly IPrefixGenService _prefixGenService;

       public LabelGenServiceFactory(IPrefixGenService prefixGenService)
       {
           _prefixGenService = prefixGenService;
           _vinLabelGenService = new(_prefixGenService.GetPrefix());
       }

       public VinLabelGenService GetVinLabelGenService() => _vinLabelGenService;
   }
```

## Conditional Object Instantiation

scenario: Imagine if we want to generate different types of vehicle using a generate label.

first we create a abstract class

```
 public abstract class Vehicle(string vinLabel)
 {
     public abstract void Design();
     public abstract void Manufacture();
 }
```

then we create different vehicle model
```
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
```

finally we create vehicle factory
```
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
```

## Conditional Service Resolution With Factory Pattern

Scenario: if we have solid implementation of multiple services using common interface. we can use factory pattern to resolve the required service inside a factory class.

```
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
```
Let us assume we have some solid implementation of maintance service of different vehicles.

```
 services.AddTransient<IMaintanceService, LiveMaintanceService>();
 services.AddTransient<IMaintanceService, TestMaintanceService>();
 services.AddTransient<IMaintanceService, OfflineMaintanceService>();
```
each of that is added to DI container.   
Then we  create a maintance factory which resolves the specfic service based on the mode.

```
public class MaintanceServiceFactory
{
    private readonly IEnumerable<IMaintanceService> _maintanceServices;
    public MaintanceServiceFactory(IEnumerable<IMaintanceService> maintanceServices)
    {
        _maintanceServices = maintanceServices;
    }
    public IMaintanceService GetMaintanceService(MaintanceMode mMode)
    {
        return _maintanceServices.FirstOrDefault(e => e.Mode == mMode)
            ?? throw new NotSupportedException();
    }
}
```
Finally we need to add the factory calss also to DI
` services.AddSingleton<MaintanceServiceFactory>();`


## Encapsulate Service Initialization
Some service need some initial check and initial setup before performing any operation in it. these can be encapsulated using factory method.

```
    public class OilService
    {
        private bool _isVehicleSwitchedOff = false;
        public void InitialCheck()
        {
            //perform initial check before oil change
            _isVehicleSwitchedOff = true;
        }
        public string DrainOil(string performedBy)
        {
            if (!_isVehicleSwitchedOff)
                throw new InvalidOperationException("Vehicle is not ready");
            return $"Draining oil performed by: {performedBy}";
        }

        public string AddOil(string performedBy)
        {
            if (!_isVehicleSwitchedOff)
                throw new InvalidOperationException("Vehicle is not ready");
            return $"Adding new oil performed by: {performedBy}";
        }
    }
```
factory method to encpsulate 

```
 public class OilServiceFactory
 {
     public OilService CreateOilService()
     {
         var service = new OilService();
         service.InitialCheck();
         return service;
     }
 }
```

## Abstract Factory With Dependency Injection

A factory may act as an abstraction over other factories, which we refer to as the Abstract Factory Pattern.

Imagine we need to have sperate sets of vehicles called smart.

```
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
```
we create abstraction by creating a Manager 

```
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
```
