namespace UseOfBuilderDesignPattern
{
    public class PizzaDirector
    {
        private readonly IPizzaConcreteBuilder _pizzaBuilder;
        public PizzaDirector(IPizzaConcreteBuilder pizzaBuilder)
        {
            _pizzaBuilder = pizzaBuilder;
        }
        public void MakePizza()
        {
            _pizzaBuilder.SetSize("Large");
            _pizzaBuilder.SetCrustType("Thin Crust");
            _pizzaBuilder.AddToppings(new List<string> { "Pepperoni", "Mushrooms", "Onions" });
            _pizzaBuilder.SetExtraCheese(true);
        }
    }
}
