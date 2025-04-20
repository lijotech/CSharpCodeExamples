namespace UseOfStrategyDesignPattern
{
    /// <summary>
    /// Define the Strategy Interface (The common interface for all algorithms)
    /// </summary>
    public interface IPaymentStrategy
    {
        void ProcessPayment(decimal amount);
    }

    //Implement Concrete Strategies (Different payment methods):
    public class CreditCardPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount} via Credit Card");
        }
    }

    public class PayPalPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount} via PayPal");
        }
    }

    public class BitcoinPayment : IPaymentStrategy
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing {amount} via Bitcoin");
        }
    }

}
