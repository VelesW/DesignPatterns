<Query Kind="Program" />

void Main()
{
    // Basic usage of concrete component
    var d = new Doer();
    d.Something();
    "---".Dump();
    
    // Demonstrates runtime flexibility by adding decorators dynamically
    var atd = new AnotherThing(d);
    atd.Something();
    "---".Dump();
    
    var iad = new InAddition(d);
    iad.Something();
    "---".Dump();
    
    // Shows how decorators can be chained in different orders
    // Demonstrates composition over inheritance principle
    var iaatd = new InAddition(atd);
    iaatd.Something();
    "---".Dump();
    
    var atiad = new AnotherThing(iad);
    atiad.Something();
}

// Component Interface - defines the contract that both concrete components 
// and decorators must follow
public interface IDoSomething
{
    void Something();
}

// Concrete Component - the basic object that can be decorated
public class Doer : IDoSomething
{
    public void Something() => "Something".Dump();
}

// Concrete Decorator - follows the Classical Object-Oriented Approach
// Demonstrates Method Decoration pattern from the definition
public class AnotherThing : IDoSomething
{
    // Reference to the wrapped component (follows Structural Components from definition)
    protected IDoSomething _doSomething;

    // Constructor injection following Best Practices
    public AnotherThing(IDoSomething doSomething) => _doSomething = doSomething;

    // Method decoration showing how additional behavior is added
    public void Something()
    {
        _doSomething.Something();
        "Another Thing".Dump();
    }
}

// Another Concrete Decorator - demonstrates Single Responsibility Principle
// Each decorator adds one specific behavior
public class InAddition : IDoSomething
{
    protected IDoSomething _doSomething;

    public InAddition(IDoSomething doSomething) => _doSomething = doSomething;

    public void Something()
    {
        _doSomething.Something();
        "In Addition".Dump();
    }
}
