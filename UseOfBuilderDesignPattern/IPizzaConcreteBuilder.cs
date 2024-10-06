namespace UseOfBuilderDesignPattern
{
    public interface IPizzaConcreteBuilder
    {
        void SetSize(string size);
        void SetCrustType(string crustType);
        void AddToppings(List<string> toppings);
        void SetExtraCheese(bool hasExtraCheese);
        Pizza GetPizza();
    }

    public interface IPizzaFluentBuilder
    {
        IPizzaFluentBuilder SetSize(string size);
        IPizzaFluentBuilder SetCrustType(string crustType);
        IPizzaFluentBuilder AddTopping(string topping);
        IPizzaFluentBuilder SetExtraCheese(bool hasExtraCheese);
        Pizza Build();
    }
}
