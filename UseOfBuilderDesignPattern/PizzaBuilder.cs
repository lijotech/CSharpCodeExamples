namespace UseOfBuilderDesignPattern
{
    public class PizzaConcreteBuilder : IPizzaConcreteBuilder
    {
        private Pizza _pizza;
        public PizzaConcreteBuilder()
        {
            _pizza = new Pizza();
        }
        public void SetSize(string size) => _pizza.Size = size;
        public void SetCrustType(string crustType) => _pizza.CrustType = crustType;
        public void AddToppings(List<string> toppings) => _pizza.Toppings = toppings;
        public void SetExtraCheese(bool hasExtraCheese) => _pizza.HasExtraCheese = hasExtraCheese;
        public Pizza GetPizza() => _pizza;

    }

    public class PizzaFluentBuilder : IPizzaFluentBuilder
    {
        private Pizza _pizza;
        public PizzaFluentBuilder()
        {
            _pizza = new Pizza();
            _pizza.Toppings = new();
        }
        public IPizzaFluentBuilder SetSize(string size)
        {
            _pizza.Size = size;
            return this;
        }
        public IPizzaFluentBuilder SetCrustType(string crustType)
        {
            _pizza.CrustType = crustType;
            return this;
        }
        public IPizzaFluentBuilder AddTopping(string topping)
        {
            _pizza.Toppings.Add(topping);
            return this;
        }
        public IPizzaFluentBuilder SetExtraCheese(bool hasExtraCheese)
        {
            _pizza.HasExtraCheese = hasExtraCheese;
            return this;
        }
        public Pizza Build()
        {
            return _pizza;
        }

        public PizzaFluentBuilder FromSpecification(PizzaSpecification spec)
        {
            _pizza.Size = spec.Size;
            _pizza.CrustType = spec.CrustType;
            _pizza.Toppings = new List<string>(spec.Toppings);
            _pizza.HasExtraCheese = spec.HasExtraCheese;
            return this;
        }
    }
}
