namespace UseOfStrategyDesignPattern
{
    /// <summary>
    /// Create a Context Class (Delegates the work to a chosen strategy):
    /// </summary>
    public class PaymentProcessor
    {
        private IPaymentStrategy _paymentStrategy;

        public PaymentProcessor(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void ExecutePayment(decimal amount)
        {
            _paymentStrategy.ProcessPayment(amount);
        }
    }

}
