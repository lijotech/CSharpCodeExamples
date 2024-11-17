namespace UseOfAdapterDesignPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            // Using the legacy logger directly
            var legacyLogger = new LegacyLogger();
            var databaseLogger = new DatabaseLogger();
            legacyLogger.LogMessage("This is a legacy log message.");

            // Using both old and new approach with logger interface with the adapter
            INewLogger newLogger = new LoggerAdapter(legacyLogger, databaseLogger);
            newLogger.Log("This is a log message through the adapter.");
        }
    }

    public class LegacyLogger
    {
        public void LogMessage(string message)
        {
            // Simulate writing to a text file
            Console.WriteLine($"Logging to text file: {message}");
        }
    }

    public interface INewLogger
    {
        void Log(string message);
    }

    public class DatabaseLogger : INewLogger
    {
        public void Log(string message)
        {
            // Simulate writing to a database
            Console.WriteLine($"Logging to database: {message}");
        }
    }

}
