# Decorator Pattern

## Definition

Decorator pattern is a structural design pattern that allows adding new behaviors to objects dynamically by placing them inside special wrapper objects.

## Key Characteristics

### 1. Structural Components
 - **Component Interface/Base Class**: Defines the interface for objects that can have responsibilities added to them  
 - **Concrete Component**: The basic object that can be decorated  
 - **Base Decorator**: Abstract class that implements the component interface and contains a reference to the component it decorates  
 - **Concrete Decorator**: Add specific behaviors to the component

 ### 2. Implementation Approaches

 #### Classical Object-Oriented Approach
 ```csharp
    public interface IComponent { }

    public class BaseDecorator : IComponent
    {
        protected IComponent component;
    }

    public class ConcreteDecorator : BaseDecorator { } 
```

#### Functional Approach
```csharp
    Func<T, R> DecorateFunction(Func<T, R> originalFunction)
    {
        return (T param) => {
            // Add behavior before/after
            return originalFunction(param);
        };
    }
```
## Benefits
1. **Single Responsibility Principle**: Each decorator class handles one specific additional responsibility
2. **Open/Closed Principle**: New behaviors can be added by creating new decorators without modifying existing code
3. **Runtime Flexibility**: Decorators can be added or removed dynamically
4. **Composition Over Inheritance**: Achieves functionality extension through composition rather than inheritance

## Common Use Cases
1. Adding optional behaviors to objects
2. Cross-cutting concerns (logging, caching, validation)
3. Building complex objects step by step
4. Extending sealed classes or third-party libraries

## Real-World Examples
1. **Caching Layer**
   - Adding prefix functionality to cache keys
   - Adding compression or encryption to cached data

2. **Data Processing**
   - Adding validation
   - Adding event emission
   - Adding data transformation

## Implementation Patterns

### 1. Property Decoration
```csharp
    public override string Property
    {
        get => component.Property;
        set
        {
            component.Property = value;
            // Additional behavior
        }
    }
```

### 2. Method Decoration
```csharp
    public override void Method()
    {
        // Additional behavior
        component.Method();
    }
```

### 3. Functional Decoration
```csharp
    Func<int, int> decorated = PrintResult(Square(Original));
```

## Best Practices
1. Keep decorators lightweight
2. Maintain the component interface
3. Consider using a base decorator class
4. Ensure decorators are independent and can be applied in any order
5. Use dependency injection to manage decorated instances

## Considerations
- Can lead to many small classes
- Order of decorators may matter
- Can complicate object instantiation
- May increase complexity in debugging and testing

