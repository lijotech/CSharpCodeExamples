namespace UseOfDecoratorPattern.Services
{
    public interface ICircuitBreaker
    {
        bool IsOpen { get; }
        void Trip();
        void Reset();
    }

    /// <summary>
    /// This is a simple implementation of CircuitBreaker and might not be suitable for all use cases.
    /// </summary>
    public class CircuitBreaker : ICircuitBreaker
    {
        private bool _isOpen = false;
        private DateTime _lastFailedAttempt = DateTime.MinValue;
        private TimeSpan _timeout = TimeSpan.FromSeconds(10);

        /// <summary>
        /// Indicates whether the circuit is open or closed
        /// </summary>
        /// <remarks>The IsOpen property checks if the circuit is open and if the timeout has passed since the last failed attempt. If the timeout has passed, it automatically resets the circuit.</remarks>
        public bool IsOpen
        {
            get
            {
                // If the circuit is open but the timeout has passed, reset it
                if (_isOpen && DateTime.Now > _lastFailedAttempt + _timeout)
                {
                    Reset();
                }

                return _isOpen;
            }
        }

        /// <summary>
        /// The Trip method opens the circuit and records the time of the last failed attempt.
        /// </summary>
        public void Trip()
        {
            _isOpen = true;
            _lastFailedAttempt = DateTime.Now;
        }

        /// <summary>
        /// The Reset method closes the circuit.
        /// </summary>
        public void Reset()
        {
            _isOpen = false;
        }
    }
}
