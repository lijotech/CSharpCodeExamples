namespace UseOfDecoratorPattern.Helper
{
    public class CircuitBreakerException : Exception
    {
        public CircuitBreakerException() : base() { }

        public CircuitBreakerException(string message) : base(message) { }

        public CircuitBreakerException(string message, Exception innerException) : base(message, innerException) { }
    }
}
