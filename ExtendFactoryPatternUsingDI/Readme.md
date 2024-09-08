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