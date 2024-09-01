## Factory Design Pattern 

The `Factory Design Pattern`  is a way to create objects in a way that hides the creation logic from the user. Instead of creating objects directly using the new keyword, you use a special method (the factory) to create them. This makes your code more flexible and easier to maintain.

### In simple terms 
Imagine you have a toy factory. Instead of making each toy by hand, you have a machine (the factory) that makes toys for you. You just tell the machine what kind of toy you want, and it gives you the toy. This way, if you want to change how toys are made, you only need to change the machine, not every place where toys are used.

### Advantages

1. Encapsulation:
   The creation logic is hidden from the client, making the code cleaner and easier to manage.
2. Loose Coupling:
   The client code is decoupled from the concrete classes it needs to instantiate. This makes it easier to change or extend the system without affecting the client code.
3. Flexibility:
   It�s easy to introduce new types of objects without changing the existing code. You just need to add new classes and update the factory method.
4. Single Responsibility Principle:
	The factory method is responsible for creating objects, while the client code focuses on using them. This separation of concerns makes the code more modular.
5. Improved Code Readability:
   Factory methods can have meaningful names that describe the object being created, making the code more readable.

### Disadvantages

1. Increased Complexity:
   The pattern introduces additional classes and interfaces, which can make the code more complex and harder to understand, especially for those unfamiliar with the pattern.
2. Performance Overhead:
   The use of additional objects and layers of abstraction can lead to a slight decrease in performance.
3. Maintenance Overhead:
   With more classes and interfaces, maintaining the code can become more challenging. Changes in the creation logic might require updates in multiple places.
4. Overuse:
   If not used appropriately, the Factory Design Pattern can lead to over-engineering. It�s important to assess whether the pattern is necessary for the given problem.


The `Factory Design Pattern` is powerful for managing object creation and promoting loose coupling, but it comes with trade-offs in terms of complexity and performance. It�s best used when the benefits outweigh the drawbacks, particularly in large and complex systems.