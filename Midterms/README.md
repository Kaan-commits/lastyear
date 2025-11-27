# C# MIDTERM EXAM - STUDY GUIDE
## Kaan Kara - 220404046

---

## 📚 Study Materials Overview

This folder contains comprehensive C# learning materials for your midterm exam covering:

1. **01_CSharp_Fundamentals.cs** - Basic C# concepts
2. **02_CSharp_OOP.cs** - Object-Oriented Programming
3. **03_SOLID_Principles.cs** - SOLID design principles
4. **04_Event_Based_Programming.cs** - Events and delegates
5. **05_Practice_Exercises.cs** - Practice problems with solutions

---

## 🎯 Exam Topics Breakdown

### 1. Introduction to C#
**Key Concepts:**
- Data types (int, double, string, bool, etc.)
- Variables and constants
- Operators (arithmetic, comparison, logical)
- Control flow (if, switch, loops)
- Arrays and collections (List, Dictionary)
- Methods (parameters, return values, out, ref)
- String operations

**What to memorize:**
```csharp
// Variable declaration
int age = 25;
string name = "Kaan";
const double PI = 3.14159;

// Type inference
var x = 10;  // Compiler knows it's int

// Arrays
int[] numbers = new int[5];
string[] names = { "Ali", "Ayşe" };

// Lists (dynamic arrays)
List<int> scores = new List<int>();
scores.Add(90);

// Methods
static int Add(int a, int b) => a + b;
```

---

### 2. Object-Oriented Programming (OOP)

**Four Pillars:**

#### A. **Encapsulation**
- Hide internal details
- Use private fields with public properties/methods
```csharp
class BankAccount
{
    private double balance;  // Hidden
    
    public void Deposit(double amount)  // Controlled access
    {
        if (amount > 0)
            balance += amount;
    }
}
```

#### B. **Inheritance**
- Create new classes from existing ones
- Use `: ParentClass` syntax
```csharp
class Animal
{
    public virtual void MakeSound() { }
}

class Dog : Animal
{
    public override void MakeSound()
    {
        Console.WriteLine("Hav hav!");
    }
}
```

#### C. **Polymorphism**
- Same interface, different implementations
- Use `virtual` and `override`
```csharp
Animal[] animals = { new Dog(), new Cat() };
foreach (Animal animal in animals)
{
    animal.MakeSound();  // Each makes different sound
}
```

#### D. **Abstraction**
- Hide complexity, show only essentials
- Use abstract classes or interfaces
```csharp
abstract class Shape
{
    public abstract double CalculateArea();
}

class Circle : Shape
{
    public override double CalculateArea() { ... }
}
```

**Key Differences:**
- **Abstract class** vs **Interface**:
  - Abstract: can have implementation, single inheritance
  - Interface: only signatures, multiple implementation

---

### 3. SOLID Principles

#### **S** - Single Responsibility Principle
- One class = One job
- Example: Separate UserValidator, UserRepository, EmailService

#### **O** - Open/Closed Principle
- Open for extension, closed for modification
- Use interfaces to add new functionality
- Example: Add new shapes without modifying AreaCalculator

#### **L** - Liskov Substitution Principle
- Child class must work wherever parent class works
- Don't break parent behavior
- Example: Don't make Penguin inherit Fly() if it can't fly

#### **I** - Interface Segregation Principle
- Many small interfaces > One large interface
- Don't force unused methods
- Example: IWorkable, IEatable, ISleepable instead of one IWorker

#### **D** - Dependency Inversion Principle
- Depend on abstractions, not concrete classes
- Use dependency injection
- Example: DatabaseManager depends on IDatabase, not SQLDatabase

---

### 4. Event-Based Programming

**Core Concepts:**

#### Delegates
```csharp
// Declare delegate
delegate int MathOperation(int a, int b);

// Use delegate
MathOperation op = Add;
int result = op(5, 3);

// Built-in delegates
Func<int, int, int> addFunc = (a, b) => a + b;
Action<string> print = Console.WriteLine;
```

#### Events
```csharp
// Declare event
public event EventHandler MyEvent;

// Subscribe
object.MyEvent += MethodName;

// Unsubscribe
object.MyEvent -= MethodName;

// Raise event
MyEvent?.Invoke(this, EventArgs.Empty);
```

#### Event Handler Signature
```csharp
void MethodName(object sender, EventArgs e)
{
    // sender: object that raised event
    // e: event data
}
```

#### Custom Event Args
```csharp
class MoneyEventArgs : EventArgs
{
    public double Amount { get; set; }
    public double NewBalance { get; set; }
}

public event EventHandler<MoneyEventArgs> MoneyDeposited;
```

---

## 📝 Common Exam Questions

### Question Types You'll See:

1. **Write a class with properties and methods**
   - Remember: public properties, private fields
   - Use constructors to initialize

2. **Implement inheritance**
   - Use `: ParentClass`
   - Call `base()` constructor if needed
   - Override methods with `override` keyword

3. **Identify SOLID violations**
   - Look for: classes doing too much (SRP)
   - Modifying existing code for new features (OCP)
   - Throwing exceptions in overridden methods (LSP)
   - Large interfaces with unused methods (ISP)
   - Direct dependency on concrete classes (DIP)

4. **Create events and event handlers**
   - Define: `public event EventHandler MyEvent;`
   - Subscribe: `obj.MyEvent += Handler;`
   - Raise: `MyEvent?.Invoke(this, EventArgs.Empty);`
   - Handler signature: `(object sender, EventArgs e)`

5. **Choose between abstract class and interface**
   - Abstract: when you have common implementation
   - Interface: when you just need a contract

---

## ⚠️ Common Mistakes to Avoid

1. ❌ Forgetting `virtual` and `override` keywords
2. ❌ Not checking null before invoking events: Use `?.`
3. ❌ Using `=` instead of `==` in conditions
4. ❌ Forgetting `break` in switch statements
5. ❌ Making fields public instead of using properties
6. ❌ Not calling `base()` constructor when needed
7. ❌ Confusing `ref` and `out` parameters
8. ❌ Forgetting `event` keyword (just using delegate)

---

## 🎓 Study Strategy

### 3 Days Before Exam:
- Read all 4 lesson files
- Understand concepts, don't just memorize
- Run the code examples

### 2 Days Before Exam:
- Do all practice exercises
- Try to solve without looking at answers first
- Understand why each solution works

### 1 Day Before Exam:
- Review this README
- Focus on areas you find difficult
- Practice writing code by hand (no IDE!)
- Review common mistakes section

### Day of Exam:
- Read this summary one more time
- Stay calm, you've got this! 💪

---

## 📊 Quick Reference Table

| Concept | Keyword | Example |
|---------|---------|---------|
| Class | `class` | `class Student { }` |
| Inheritance | `:` | `class Dog : Animal { }` |
| Abstract | `abstract` | `abstract class Shape { }` |
| Interface | `interface` | `interface IPayable { }` |
| Override | `override` | `public override void Method() { }` |
| Virtual | `virtual` | `public virtual void Method() { }` |
| Event | `event` | `public event EventHandler Clicked;` |
| Delegate | `delegate` | `delegate void MyDelegate();` |
| Lambda | `=>` | `(x, y) => x + y` |

---

## 💡 Pro Tips

1. **Understand relationships:**
   - HAS-A (composition): Car has Engine
   - IS-A (inheritance): Dog is Animal

2. **When to use what:**
   - Abstract class: Common implementation + contract
   - Interface: Just contract, multiple inheritance
   - Events: When you need publisher-subscriber pattern

3. **SOLID in one sentence each:**
   - S: One class, one job
   - O: Add new without modifying old
   - L: Child works where parent works
   - I: Small interfaces, not big ones
   - D: Depend on abstractions

4. **Events in 3 steps:**
   - Define: `public event EventHandler MyEvent;`
   - Subscribe: `obj.MyEvent += Method;`
   - Raise: `MyEvent?.Invoke(this, EventArgs.Empty);`

---

## 🚀 How to Use These Materials

1. **First Pass (Understanding):**
   - Read each .cs file slowly
   - Run the examples
   - Make sure you understand every line

2. **Second Pass (Practice):**
   - Try to modify examples
   - Change parameters, add features
   - Break something and fix it

3. **Third Pass (Mastery):**
   - Do practice exercises
   - Write code without looking at examples
   - Explain concepts in your own words

---

## 📞 Need Help?

If you're stuck on something:
1. Re-read the relevant section
2. Run the example code and see what happens
3. Try to explain it out loud (seriously, this helps!)
4. Draw diagrams for class relationships
5. Practice, practice, practice!

---

**Good luck on your midterm! 🎓**

Remember: Understanding > Memorization

You've got this! 💪

---

*Last updated: November 15, 2025*
