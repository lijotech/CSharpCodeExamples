namespace UseOfAdapterDesignPattern
{
    public class LoggerAdapter : INewLogger
    {
        private readonly LegacyLogger _legacyLogger;
        private readonly INewLogger _newLogger;

        public LoggerAdapter(LegacyLogger legacyLogger, INewLogger newLogger)
        {
            _legacyLogger = legacyLogger;
            _newLogger = newLogger;
        }

        public void Log(string message)
        {
            // Adapt the legacy logger to the new logger interface
            _legacyLogger.LogMessage(message);
            _newLogger.Log(message);
        }
    }
}