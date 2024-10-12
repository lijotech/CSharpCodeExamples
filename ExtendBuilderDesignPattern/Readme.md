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

This pattern ensures that you can chain methods in any order to build a Computer object with all necessary attributes. The use of recursive generics allows each method to return the correct type, enabling fluent method chaining.

### Summary
- Recursive Generics: Ensure that each method returns the correct type for chaining.
- Fluent Interface: Allows methods to be called in any order, as long as they are defined in the builder classes.
- Builder Pattern: Separates the construction of a complex object from its representation, making the code more readable and maintainable.

- This pattern is particularly useful for creating complex objects with many optional parameters, providing a clear and flexible way to construct objects step by step.