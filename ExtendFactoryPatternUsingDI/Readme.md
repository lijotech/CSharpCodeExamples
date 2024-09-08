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




