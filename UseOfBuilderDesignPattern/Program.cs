using UseOfBuilderDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("===Concrete Builder===");
        Console.WriteLine();

        IPizzaConcreteBuilder pizzaBuilder = new PizzaConcreteBuilder();
        PizzaDirector director = new PizzaDirector(pizzaBuilder);
        director.MakePizza();
        Pizza concretePizza = pizzaBuilder.GetPizza();
        concretePizza.Display();
        Console.WriteLine();
        Console.Write("===Fluent Builder===");
        Console.WriteLine();
        Pizza fluentPizza = new PizzaFluentBuilder()
             .SetSize("Large")
             .SetCrustType("Thin Crust")
             .AddTopping("Pepperoni")
             .AddTopping("Hammoos")
             .AddTopping("Onions")
             .SetExtraCheese(false)
             .Build();
        fluentPizza.Display();
        Console.WriteLine();
        Console.Write("===Fluent Builder with parameter Object===");
        Console.WriteLine();
        var pizzaSpec = new PizzaSpecification
        {
            Size = "Medium",
            CrustType = "Thick Crust",
            Toppings = new List<string> { "Salt", "Mushrooms", "Onions" },
            HasExtraCheese = true
        };
        Pizza fluentParameterPizza = new PizzaFluentBuilder()
        .FromSpecification(pizzaSpec)
        .Build();
        fluentParameterPizza.Display();


    }
}