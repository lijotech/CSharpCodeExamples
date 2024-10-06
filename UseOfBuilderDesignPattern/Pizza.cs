namespace UseOfBuilderDesignPattern
{
    public class Pizza
    {
        public string Size { get; set; }
        public string CrustType { get; set; }
        public List<string> Toppings { get; set; }
        public bool HasExtraCheese { get; set; }
        public void Display()
        {
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Crust Type: {CrustType}");
            Console.WriteLine("Toppings:");
            foreach (var topping in Toppings)
            {
                Console.WriteLine($"- {topping}");
            }
            Console.WriteLine($"Extra Cheese: {(HasExtraCheese ? "Yes" : "No")}");
        }
    }

}
