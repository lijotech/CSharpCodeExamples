## Builder Design Pattern with Recursive Generics

### Recursive Generics
Recursive generics are used to ensure that each method in the builder chain returns the correct type, allowing for fluent method chaining. Here’s how it works:

ComputerCPUBuilder<T> is defined with a generic type parameter T that extends ComputerCPUBuilder<T>. This allows the SetCPU method to return T, ensuring that the next method in the chain is available.
Similarly, ComputerGPUBuilder<T>, ComputerStorageBuilder<T> and ComputerRAMBuilder<T> follow the same pattern, each extending the previous builder class and returning T.

### Fluent Method Calls
The fluent method calls work irrespective of the order because each method returns the builder instance (this) cast to the correct type (T). This allows you to chain methods in any order, as long as the methods are defined in the builder classes.

### Explanation

* __Base Builder Class__ (ComputerBuilder): Initializes a Computer object and provides a Build method to return the constructed Computer.
* __Intermediate Builder Classes__: Each class adds a method to set a specific property of the Computer and uses recursive generics to return the correct type for method chaining.

	- ComputerCPUBuilder<T>: Adds the SetCPU method.
	- ComputerGPUBuilder<T>: Adds the SetGPU method.
	- ComputerRAMBuilder<T>: Adds the SetRAM method.
	- ComputerStorageBuilder<T>: Adds the SetStorage method.
* __Director Class__ (ComputerBuilderDirector): Inherits from the most derived builder class (ComputerStorageBuilder<ComputerBuilderDirector>) to provide a complete set of builder methods.

- Recursive Generics: Ensure that each method returns the correct type for chaining.
- Fluent Interface: Allows methods to be called in any order, as long as they are defined in the builder classes.
- Builder Pattern: Separates the construction of a complex object from its representation, making the code more readable and maintainable.

### Advantages
- Fluent Interface: Allows for intuitive and readable method chaining.
- Type Safety: Ensures that each method returns the correct type, preventing runtime errors.
- Flexibility: Methods can be called in any order, making the builder flexible.

### Disadvantages
- Complexity: The use of recursive generics can be difficult to understand and implement.
- Verbosity: Requires multiple builder classes, which can lead to more verbose code.


### Usage Scenarios
- When you need to build complex objects with many optional parameters.
- When you want to ensure type safety and provide a fluent interface for object construction.
 
---
 
## Faceted Builder

The Faceted Builder pattern uses multiple builder classes to construct different aspects (facets) of an object. This pattern is useful when an object has multiple parts that can be built independently.

### Advantages

- Separation of Concerns: Different aspects of the object are built by different builders, making the code more modular and maintainable.
- Clarity: Each builder class has a clear responsibility, making the code easier to understand.

### Disadvantages

- Coordination: Requires coordination between multiple builder classes, which can add complexity.
- Overhead: May introduce additional overhead due to the need for multiple builder classes.

### Usage Scenarios
- When an object has multiple independent parts that need to be built separately.
- When you want to separate the construction logic for different aspects of an object to improve modularity and maintainability.

### Summary
- `Recursive Builder`: Best for building complex objects with many optional parameters, providing a fluent interface and ensuring type safety.
- `Faceted Builder`: Best for building objects with multiple independent parts, improving modularity and separation of concerns.

- Both patterns have their own strengths and are suitable for different scenarios. The choice between them depends on the specific requirements of your object construction process.