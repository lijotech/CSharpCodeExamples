The Visitor Design Pattern is a behavioral design pattern that allows adding new operations to existing object structures without modifying them. It helps separate concerns by keeping operations separate from the objects they operate on.


## Stepwise Process of Designing the Visitor Pattern

- Create an Interface for the Visitor – Define an interface with a method to visit different types of elements.
- Define Concrete Visitors – Implement different operations in visitor classes.
- Create an Interface for Elements – Define an interface that accepts visitors.
- Implement Concrete Elements – Implement classes that accept visitors.
- Implement the Client Code – Utilize the visitor to operate on the elements.

## Usage Scenarios for Visitor Pattern

- Extending Functionality: Adding operations to complex object structures without altering them.
- Processing Hierarchical Objects: Suitable for traversing trees or composite objects.
- Operations on Different Objects: Applying calculations, validation, or transformations across different object types.
- Code Maintainability: Prevents cluttering elements with unrelated logic.




## Real-World Example: Shopping Cart Discount Calculation

Imagine an e-commerce platform where we want to apply different discounts based on item types. Instead of modifying item classes, we use the Visitor Pattern to encapsulate discount calculation.

### Step 1: Create Visitor Interface

```csharp
public interface IVisitor
{
    void Visit(Book book);
    void Visit(Electronics electronics);
}
```

This defines the `IVisitor` interface, which ensures that any class implementing it can visit both `Book` and `Electronics` objects. It provides two methods, one for books and another for electronics, allowing operations to be defined for different item types separately


### Step 2: Implement Concrete Visitor

```csharp
public class DiscountVisitor : IVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Applying 10% discount on book: {book.Title}");
    }

    public void Visit(Electronics electronics)
    {
        Console.WriteLine($"Applying 5% discount on electronic: {electronics.Model}");
    }
}
```

The DiscountVisitor class implements the IVisitor interface. When visiting a book, it applies a 10% discount and prints the book title. When visiting an electronic item, it applies a 5% discount and prints the model.

### Step 3: Create Element Interface

```csharp
public interface IVisitable
{
    void Accept(IVisitor visitor);
}
```

The IVisitable interface ensures that every object can accept a visitor. Any class implementing this interface must define the Accept() method, which allows it to interact with a visitor.

### Step 4: Implement Concrete Elements

```csharp
public class Book : IVisitable
{
    public string Title { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}

public class Electronics : IVisitable
{
    public string Model { get; set; }

    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
}
```

- Book class holds a `Title` property and it implements `Accept(IVisitor visitor)`, allowing a visitor to call the `Visit(Book book)` method.
- Electronics class holds a `Model` property and it implements `Accept(IVisitor visitor)`, allowing a visitor to call the `Visit(Electronics electronics)` method.


### Step 5: Implement Client Code

```csharp
class Program
{
    static void Main()
    {
        List<IVisitable> items = new List<IVisitable>
        {
            new Book { Title = "Design Patterns" },
            new Electronics { Model = "Smartphone" }
        };

        DiscountVisitor discountVisitor = new DiscountVisitor();

        foreach (var item in items)
        {
            item.Accept(discountVisitor);
        }
    }
}
```
A List<IVisitable> is created containing a Book and an Electronics item. Using a loop, each item in the list calls its `Accept()` method, passing the discountVisitor. The corresponding `Visit()` method executes, applying the discount and printing details.

Final Output When Program Runs

> - Applying 10% discount on book: Design Patterns
> - Applying 5% discount on electronic: Smartphone


## Adding additional operation

Now lets us look at how we can extend the **Visitor Pattern** by adding a new visitor class for tax calculation. This allows us to introduce new operations without modifying existing classes.

### Step 1: Create a New Visitor Interface

We extend the visitor functionality by adding a **TaxVisitor**, which will calculate tax based on item type.

```csharp
public class TaxVisitor : IVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Calculating 5% tax for book: {book.Title}");
    }

    public void Visit(Electronics electronics)
    {
        Console.WriteLine($"Calculating 18% tax for electronic: {electronics.Model}");
    }
}
```

### Step 2: Modify Client Code to Use Both Visitors

Now, we modify the client code to apply both discounts and taxes.

```csharp
class Program
{
    static void Main()
    {
        List<IVisitable> items = new List<IVisitable>
        {
            new Book { Title = "Design Patterns" },
            new Electronics { Model = "Smartphone" }
        };

        DiscountVisitor discountVisitor = new DiscountVisitor();
        TaxVisitor taxVisitor = new TaxVisitor();

        foreach (var item in items)
        {
            item.Accept(discountVisitor);
            item.Accept(taxVisitor);
        }
    }
}
```

This code ensures that each item in the list is visited by both the `DiscountVisitor` and `TaxVisitor`. This approach allows us to apply multiple operations without modifying existing classes, keeping the code flexible and maintainable.

Expected Output

> - Applying 10% discount on book: Design Patterns
> - Calculating 5% tax for book: Design Patterns
> - Applying 5% discount on electronic: Smartphone
> - Calculating 18% tax for electronic: Smartphone
 
This is the power of the Visitor Pattern—you can keep extending operations without touching the original classes!


## Challenging Scenario

The Visitor Pattern becomes challenging when a new element type is introduced because every existing visitor must be updated to handle the new type. Let's explore this issue based on our Shopping Cart example.

### Scenario: Adding a "Clothing" Item to the Shopping Cart
Imagine that the store decides to add **Clothing** items alongside Books and Electronics. Now, we need to:

- Introduce a new class `Clothing` that implements `IVisitable`.
- Update every existing visitor (DiscountVisitor, TaxVisitor) to handle `Clothing` items.
- Ensure all visitors provide appropriate operations for `Clothing`.


### Step 1: Adding the New Clothing Class

```csharp
public class Clothing : IVisitable
{
    public string Brand { get; set; }

    public void Accept(IVisitor visitor)
    {        
        visitor.Visit(this);
    }
}
```
This class introduces Brand as a new property. It implements `Accept()`, but the existing visitors don't yet support `Clothing`.

### Step 2: Updating Every Visitor
Every visitor must now include a new method for handling `Clothing`.

```csharp
public class DiscountVisitor : IVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Applying 10% discount on book: {book.Title}");
    }

    public void Visit(Electronics electronics)
    {
        Console.WriteLine($"Applying 5% discount on electronic: {electronics.Model}");
    }

    public void Visit(Clothing clothing)
    {
        Console.WriteLine($"Applying 15% discount on clothing brand: {clothing.Brand}");
    }
}

public class TaxVisitor : IVisitor
{
    public void Visit(Book book)
    {
        Console.WriteLine($"Calculating 5% tax for book: {book.Title}");
    }

    public void Visit(Electronics electronics)
    {
        Console.WriteLine($"Calculating 18% tax for electronic: {electronics.Model}");
    }

    public void Visit(Clothing clothing)
    {
        Console.WriteLine($"Calculating 12% tax for clothing brand: {clothing.Brand}");
    }
}
```

### Challenges in Adding the New Element Type

- **Breaking Open/Closed Principle** – Every time a new element (e.g., Clothing) is introduced, all visitor implementations must be updated, which contradicts the principle of avoiding modifications to existing code.
- **Scalability Issues** – As more items (e.g., Furniture, Toys, Jewelry) are added, visitor classes grow in complexity, making them harder to maintain.
- **Refactoring Concerns **– If some visitors don’t need to operate on `Clothing`, they still have to define a `Visit(Clothing clothing)` method, even if it does nothing.

## Pros and Cons of the Visitor Design Pattern

### Pros (Advantages)
- Separation of Concerns – Keeps operations separate from object structures, enhancing maintainability.
- Extensibility – You can add new operations without modifying existing element classes.
- Open/Closed Principle – Objects remain unchanged while new behaviors can be added.
- Centralized Operations – Helps organize related operations in one place, rather than spreading logic across multiple classes.
- Suitable for Complex Object Structures – Works well in hierarchical or tree-like structures (e.g., parsing XML or compiler AST).

### Cons (Disadvantages)
- Modification Difficulty – Adding new element types requires modifying all visitors, making changes cumbersome.
- Breaks Encapsulation – Requires exposing internal details of elements, potentially violating encapsulation.
- Harder to Understand – Can be complex for beginners, especially when multiple visitors interact with many elements.
- Performance Overhead – If not implemented carefully, frequent visitor calls may introduce overhead in large object structures.

## Key considerations when implementing Visitor pattern

- Ensure object structures are stable and won’t frequently change.
- Identify whether multiple operations will need to be performed on elements.
- Consider alternatives like Strategy Pattern if operations vary based on external parameters.
- Keep visitor interfaces flexible to allow future expansions.
- Avoid making visitors too dependent on specific data types, improving adaptability.
- Optimize performance for large object structures by minimizing unnecessary traversals.

## Conclusion
The Visitor Pattern is great for adding multiple behaviors to fixed structures, but it’s not ideal if element types frequently change. Thoughtful planning and well-structured interfaces help maximize its benefits while minimizing its downsides.

