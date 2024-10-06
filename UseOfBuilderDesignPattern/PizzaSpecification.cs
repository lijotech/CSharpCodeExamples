namespace UseOfBuilderDesignPattern
{
    public class PizzaSpecification
    {
        public string Size { get; set; }
        public string CrustType { get; set; }
        public List<string> Toppings { get; set; } = new ();
        public bool HasExtraCheese { get; set; }
    }
}
