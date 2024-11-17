The Adapter Design Pattern is a structural design pattern that allows objects with incompatible interfaces to work together. It acts as a bridge between two incompatible interfaces by converting the interface of a class into another interface that a client expects. This pattern is particularly useful when integrating new components into an existing system without modifying the existing code.

The Adapter Pattern involves four main components:

* Target Interface: This is the interface that the client expects to work with.

* Adaptee: This is the existing class that needs to be adapted.

* Adapter: This is the class that implements the target interface and translates the requests from the client to the adaptee.

* Client: This is the class that interacts with the target interface.

The Adapter Pattern can be implemented in two ways:

- Class Adapter: Uses inheritance to adapt one interface to another.

- Object Adapter: Uses composition to adapt one interface to another.

## Usage Scenarios

- Legacy System Integration: When integrating a new system with an existing legacy system, the Adapter Pattern can be used to make the new system compatible with the old one without modifying the legacy code. For example, adapting a legacy logging system to work with a new logging interface.

- Third-Party Library Integration: When using third-party libraries that have different interfaces from what your application expects, the Adapter Pattern can be used to create a wrapper that makes the third-party library compatible with your application. For example, adapting a third-party payment gateway to work with your e-commerce platform.

- Multiple Interface Compatibility: When a class needs to work with multiple interfaces that are not compatible with each other, the Adapter Pattern can be used to create adapters for each interface. For example, adapting different types of data sources (e.g., XML, JSON, databases) to a common data processing interface.

- User Interface Components: When developing user interface components that need to work with different types of data models, the Adapter Pattern can be used to create adapters that convert the data models into a format that the UI components can understand. For example, adapting different data models to a common UI component interface in a graphical user interface application.

## Example Scenario

Imagine we have an old logging system that writes logs to a text file, but we need to integrate it with a new logging interface that writes logs to a database. We'll use the Adapter pattern to achieve this.

Legacy Logging System:
```csharp
public class LegacyLogger
{
    public void LogMessage(string message)
    {
        // Simulate writing to a text file
        Console.WriteLine($"Logging to text file: {message}");
    }
}

```
This class represents the old logging system that writes logs to a text file. It has a method `LogMessage` that simulates writing a log message to a text file.

New Logging Interface:
```
public interface INewLogger
{
    void Log(string message);
}

```
This interface defines the new logging system that is supposed to write logs to a database. It has a method `Log` that is intended to be implemented by any new logging system.

Database Logger:
```
public class DatabaseLogger : INewLogger
{
    public void Log(string message)
    {
        // Simulate writing to a database
        Console.WriteLine($"Logging to database: {message}");
    }
}

```
This class implements the `INewLogger` interface and simulates writing logs to a database. In a real-world scenario, this class would contain the logic to write logs to a database.

Adapter Implementation:

```
public class LoggerAdapter : INewLogger
{
    private readonly LegacyLogger _legacyLogger;

    public LoggerAdapter(LegacyLogger legacyLogger)
    {
        _legacyLogger = legacyLogger;
    }

    public void Log(string message)
    {
        // Adapt the legacy logger to the new logger interface
        _legacyLogger.LogMessage(message);
    }
}

```
This class acts as an adapter that allows the `LegacyLogger` to be used where the `INewLogger` interface is expected. It implements the `INewLogger` interface and internally uses an instance of `LegacyLogger` to log messages.

Client Code:
```
class Program
{
    static void Main(string[] args)
    {
        // Using the legacy logger directly
        var legacyLogger = new LegacyLogger();
        legacyLogger.LogMessage("This is a legacy log message.");

        // Using the new logger interface with the adapter
        INewLogger newLogger = new LoggerAdapter(legacyLogger);
        newLogger.Log("This is a log message through the adapter.");
    }
}

```

## How the Adapter Works
When the `Log` method of the `LoggerAdapter` is called, it internally calls the `LogMessage` method of the `LegacyLogger`.

This means that even though the `LoggerAdapter` is being used where the `INewLogger` interface is expected, it is still using the legacy logging system to write logs to a text file.

The rationale behind using the adapter pattern in this scenario is to allow the integration of a legacy system with a new interface without modifying the existing legacy code. This is useful in situations where:

- The legacy system is still functional and reliable, and there is no immediate need to replace it.

- The new system requires a different interface, and you want to avoid rewriting the legacy system to conform to the new interface.

- You want to gradually transition from the legacy system to the new system without disrupting existing functionality.

By using the adapter pattern, you can achieve compatibility between the legacy system and the new interface, allowing for a smoother transition and integration process.

# Phased approach

To transition from the legacy logging system to the new database logging system, you can follow a phased approach. This allows you to gradually shift from the old system to the new one without disrupting existing functionality.

## Update the Adapter to Support Both Systems:
```
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
        // Log to both legacy and new systems
        _legacyLogger.LogMessage(message);
        _newLogger.Log(message);
    }
}

```
Modify the adapter to support both the legacy and new logging systems. This way, you can log messages to both systems during the transition period.

## Gradually Shift Logging Responsibility:

Start using the adapter in your application to log messages to both systems.

```
class Program
{
    static void Main(string[] args)
    {
        var legacyLogger = new LegacyLogger();
        var databaseLogger = new DatabaseLogger();
        INewLogger logger = new LoggerAdapter(legacyLogger, databaseLogger);

        logger.Log("This is a log message during the transition period.");
    }
}

```
Monitor and Validate:

Monitor the logs in both systems to ensure that they are being recorded correctly. Validate that the new logging system is functioning as expected.

Phase Out the Legacy System:

Once you are confident that the new logging system is stable and reliable, you can phase out the legacy logging system. Update the adapter to only use the new logging system.

```
public class LoggerAdapter : INewLogger
{
    private readonly INewLogger _newLogger;

    public LoggerAdapter(INewLogger newLogger)
    {
        _newLogger = newLogger;
    }

    public void Log(string message)
    {
        // Log only to the new system
        _newLogger.Log(message);
    }
}

```

Once the new system is validated and the legacy system is phased out, you can directly use the `DatabaseLogger` to log messages. This simplifies the code and eliminates the need for the adapter.


Update Client Code:

Update your client code to use the new logging system directly, if desired.

```
class Program
{
    static void Main(string[] args)
    {
        INewLogger logger = new DatabaseLogger();
        logger.Log("This is a log message using the new logging system.");
    }
}

```

This approach allows for a smooth transition from the legacy logging system to the new database logging system, minimizing disruptions and ensuring data integrity.