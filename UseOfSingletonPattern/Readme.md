## Singleton Design Pattern

The `Singleton Design Pattern` ensures that a class has only one instance and provides a global point of access to it. In C#, it’s useful when you need exactly one instance of a class to coordinate actions across the system. Here are the key characteristics:

- Single Instance: Only one instance of the Singleton class is created throughout the application.
- Global Access: Provides a global access point to that instance.
- Lazy Initialization: The instance is created when needed, not when the application starts.
- Thread Safety: It must be thread-safe to prevent multiple instances.


In this example:
- `Logger` is a singleton class with a private constructor.
- The instance is lazily initialized using `Lazy<T>`.
- The `Logger.Instance` property provides global access.
- `AppControllerBase` is an abstract class that initializes the logger.
- `HomeController` inherits from `AppControllerBase` and uses the logger to log requests
- You can use `_logger` in any controller or service to log messages consistently.
---

### Differences between the `Singleton pattern` and using a `static class` in C#

1. Singleton Pattern:
- Purpose: The Singleton pattern ensures that only one instance of a class exists throughout the application’s lifetime.
- Instance Creation: The singleton instance is created lazily (when needed) or eagerly (at application startup).
- Global Access: Provides a global point of access to that single instance.
- Flexibility: Allows you to implement interfaces, change behavior, and manage state.
- Example: A logging system where a single logger instance is shared across different parts of the application.

2. Static Class:
- Purpose: A static class contains only static members (methods, properties, fields) and cannot be instantiated.
- Instance Creation: No instance is created; all members are accessed directly via the class name.
- Global Access: Provides global access to its static members.
- Flexibility: Limited; cannot implement interfaces or change behavior dynamically.
- Example: Utility classes with stateless functions or constants (e.g., Math, File, Console).

> ### Brief usage scenarios analysis:
>  Use a `Singleton` if you need object-oriented features, state management, and flexibility.
>  Use a `static class` for simple, stateless functions or global constants.
