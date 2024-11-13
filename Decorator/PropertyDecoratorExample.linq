<Query Kind="Program" />

void Main()
{
    // Example usage would go here
}

// Component Interface - defines the contract that both concrete components 
// and decorators must follow
public interface IBasicData
{
    int Id { get; set; }
    string Name { get; set; }
    string Description { get; set; }
}

// Concrete Component - the basic object that can be decorated
// This is the core implementation that decorators will enhance
public class DumbData : IBasicData
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

// Base Decorator - abstract class that implements the component interface
// and contains a reference to a component (follows the definition's Structural Components)
public abstract class BaseDecorator : IBasicData
{
    // Reference to the wrapped component (could be either concrete component or another decorator)
    protected IBasicData data;

    // Constructor injection following "Composition Over Inheritance" principle
    public BaseDecorator(IBasicData data) => this.data = data;

    // Virtual methods allow concrete decorators to override and add behavior
    // Default implementation simply delegates to the wrapped component
    public virtual int Id { get => data.Id; set => data.Id = value; }
    public virtual string Name { get => data.Name; set => data.Name = value; }
    public virtual string Description { get => data.Description; set => data.Description = value; }
}

// Concrete Decorator - adds specific behavior (event emission) to the Name property
// Demonstrates "Single Responsibility Principle" by handling one specific concern
public class InjectedFunctionality : BaseDecorator
{
    // Constructor maintains the decorator chain
    public InjectedFunctionality(IBasicData data) : base(data) { }

    // Example of Property Decoration pattern from the definition
    // Adds event emission behavior while maintaining the original property behavior
    public override string Name
    {
        get => data.Name;
        set
        {
            data.Name = value;
            EmitEvent(value);  // Additional behavior
        }
    }

    // Private implementation detail of the decorator
    // Demonstrates how decorators can add functionality without changing the interface
    private void EmitEvent(string name)
    {
        // This is an example of a cross-cutting concern (event handling)
        // that can be added dynamically through decoration
    }
}