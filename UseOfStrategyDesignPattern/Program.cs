using UseOfStrategyDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Choose a payment method: 1-CreditCard 2-PayPal 3-Bitcoin");
        int choice = int.Parse(Console.ReadLine());

        IPaymentStrategy strategy = choice switch
        {
            1 => new CreditCardPayment(),
            2 => new PayPalPayment(),
            3 => new BitcoinPayment(),
            _ => throw new Exception("Invalid choice")
        };

        PaymentProcessor processor = new PaymentProcessor(strategy);
        processor.ExecutePayment(100.00m);
    }
}
