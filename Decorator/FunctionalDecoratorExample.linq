<Query Kind="Program" />

void Main()
{
    // Demonstrates Functional Decoration approach from the definition
    // Shows how decorators can be composed in different orders
    Func<int, int, int> add = PrintResult(Add);                   // Single decorator
    Func<int, int, int> addPrintSquare = Square(add);            // Chaining decorators
    Func<int, int, int> addSquarePrint = PrintResult(Square(Add)); // Different order of decoration

    // Testing different decorator combinations
    add(5, 5);
    addPrintSquare(5, 5).Dump("after");
    addSquarePrint(5, 5);
}

// Original function (Concrete Component in traditional terms)
public int Add(int a, int b) => a + b;

// Decorator function that adds logging behavior
// Demonstrates cross-cutting concerns mentioned in Common Use Cases
public Func<int, int, int> PrintResult(Func<int, int, int> fn)
{
    // Following the Functional Approach pattern from definition
    return (int a, int b) =>
    {
        int result = fn(a, b);
        // Additional behavior (logging) wrapped around original function
        result.Dump("inside");
        return result;
    };
}

// Decorator function that adds transformation behavior
// Demonstrates "Data Processing - Adding data transformation" from Real-World Examples
public Func<int, int, int> Square(Func<int, int, int> fn)
{
    // Shows how decorators can modify the result while maintaining the same interface
    return (int a, int b) =>
    {
        int result = fn(a, b);
        return result * result;
    };
}
