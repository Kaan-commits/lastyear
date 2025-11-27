// ============================================================================
// C# OBJECT-ORIENTED PROGRAMMING (OOP)
// ============================================================================
// OOP is a programming paradigm based on the concept of "objects"
// Objects contain data (fields) and code (methods)
// Four main principles: Encapsulation, Inheritance, Polymorphism, Abstraction

using System;
using System.Collections.Generic;

namespace CSharpOOP
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# OBJECT-ORIENTED PROGRAMMING ===\n");
            
            // Test all OOP concepts
            EncapsulationDemo();
            InheritanceDemo();
            PolymorphismDemo();
            AbstractionDemo();
            InterfaceDemo();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // ====================================================================
        // 1. ENCAPSULATION - Hiding internal details, exposing only what's necessary
        // ====================================================================
        static void EncapsulationDemo()
        {
            Console.WriteLine("--- ENCAPSULATION ---");
            
            BankAccount account = new BankAccount("Kaan Kara", 1000);
            Console.WriteLine(account.GetBalance());
            
            account.Deposit(500);
            account.Withdraw(200);
            // account.balance = -9999;  // ERROR! Private field cannot be accessed
            
            Console.WriteLine(account.GetBalance());
            Console.WriteLine();
        }
        
        // ====================================================================
        // 2. INHERITANCE - Creating new classes from existing ones
        // ====================================================================
        static void InheritanceDemo()
        {
            Console.WriteLine("--- INHERITANCE ---");
            
            Dog dog = new Dog("Karabaş", 3);
            dog.Eat();           // From Animal class
            dog.Sleep();         // From Animal class
            dog.Bark();          // From Dog class
            dog.MakeSound();     // Overridden method
            
            Console.WriteLine();
            
            Cat cat = new Cat("Tekir", 2);
            cat.Eat();
            cat.Sleep();
            cat.Meow();
            cat.MakeSound();
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 3. POLYMORPHISM - Same interface, different implementations
        // ====================================================================
        static void PolymorphismDemo()
        {
            Console.WriteLine("--- POLYMORPHISM ---");
            
            // Polymorphism: treating derived classes as base class
            Animal[] animals = new Animal[3];
            animals[0] = new Dog("Max", 4);
            animals[1] = new Cat("Whiskers", 3);
            animals[2] = new Bird("Tweety", 1);
            
            foreach (Animal animal in animals)
            {
                animal.MakeSound();  // Each animal makes different sound!
            }
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 4. ABSTRACTION - Hiding complex implementation, showing only essentials
        // ====================================================================
        static void AbstractionDemo()
        {
            Console.WriteLine("--- ABSTRACTION ---");
            
            // Cannot create instance of abstract class
            // Shape shape = new Shape();  // ERROR!
            
            Shape circle = new Circle(5);
            Shape rectangle = new Rectangle(4, 6);
            
            Console.WriteLine($"Circle area: {circle.CalculateArea()}");
            Console.WriteLine($"Rectangle area: {rectangle.CalculateArea()}");
            
            circle.DisplayInfo();
            rectangle.DisplayInfo();
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 5. INTERFACES - Contracts that classes must implement
        // ====================================================================
        static void InterfaceDemo()
        {
            Console.WriteLine("--- INTERFACES ---");
            
            List<IPayable> payables = new List<IPayable>();
            payables.Add(new Employee("Ali", 5000));
            payables.Add(new Contractor("Ayşe", 3000));
            payables.Add(new Invoice(1500));
            
            double totalPayment = 0;
            foreach (IPayable payable in payables)
            {
                double amount = payable.CalculatePayment();
                Console.WriteLine($"Payment: {amount} TL");
                totalPayment += amount;
            }
            
            Console.WriteLine($"Total payment: {totalPayment} TL");
            Console.WriteLine();
        }
    }
    
    // ========================================================================
    // ENCAPSULATION EXAMPLE
    // ========================================================================
    class BankAccount
    {
        // Private fields (hidden from outside)
        private string ownerName;
        private double balance;
        
        // Constructor
        public BankAccount(string name, double initialBalance)
        {
            ownerName = name;
            balance = initialBalance;
        }
        
        // Public methods (controlled access)
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine($"Deposited: {amount} TL");
            }
        }
        
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                Console.WriteLine($"Withdrawn: {amount} TL");
            }
            else
            {
                Console.WriteLine("Insufficient funds!");
            }
        }
        
        public string GetBalance()
        {
            return $"{ownerName}'s balance: {balance} TL";
        }
    }
    
    // ========================================================================
    // INHERITANCE EXAMPLE
    // ========================================================================
    
    // Base class (Parent)
    class Animal
    {
        // Protected: accessible in derived classes
        protected string name;
        protected int age;
        
        public Animal(string name, int age)
        {
            this.name = name;
            this.age = age;
        }
        
        // Virtual method: can be overridden
        public virtual void MakeSound()
        {
            Console.WriteLine($"{name} makes a sound");
        }
        
        public void Eat()
        {
            Console.WriteLine($"{name} is eating");
        }
        
        public void Sleep()
        {
            Console.WriteLine($"{name} is sleeping");
        }
    }
    
    // Derived class (Child)
    class Dog : Animal
    {
        // Constructor calls base constructor
        public Dog(string name, int age) : base(name, age)
        {
        }
        
        // Override parent method
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Hav hav!");
        }
        
        // New method specific to Dog
        public void Bark()
        {
            Console.WriteLine($"{name} is barking");
        }
    }
    
    class Cat : Animal
    {
        public Cat(string name, int age) : base(name, age)
        {
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Miyav!");
        }
        
        public void Meow()
        {
            Console.WriteLine($"{name} is meowing");
        }
    }
    
    class Bird : Animal
    {
        public Bird(string name, int age) : base(name, age)
        {
        }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Cik cik!");
        }
    }
    
    // ========================================================================
    // ABSTRACTION EXAMPLE
    // ========================================================================
    
    // Abstract class: cannot be instantiated
    abstract class Shape
    {
        protected string name;
        
        public Shape(string name)
        {
            this.name = name;
        }
        
        // Abstract method: must be implemented by derived classes
        public abstract double CalculateArea();
        
        // Concrete method: can be used as-is
        public void DisplayInfo()
        {
            Console.WriteLine($"Shape: {name}, Area: {CalculateArea()}");
        }
    }
    
    class Circle : Shape
    {
        private double radius;
        
        public Circle(double radius) : base("Circle")
        {
            this.radius = radius;
        }
        
        public override double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }
    
    class Rectangle : Shape
    {
        private double width;
        private double height;
        
        public Rectangle(double width, double height) : base("Rectangle")
        {
            this.width = width;
            this.height = height;
        }
        
        public override double CalculateArea()
        {
            return width * height;
        }
    }
    
    // ========================================================================
    // INTERFACE EXAMPLE
    // ========================================================================
    
    // Interface: defines contract (what methods must exist)
    interface IPayable
    {
        double CalculatePayment();
    }
    
    class Employee : IPayable
    {
        private string name;
        private double salary;
        
        public Employee(string name, double salary)
        {
            this.name = name;
            this.salary = salary;
        }
        
        public double CalculatePayment()
        {
            return salary;
        }
    }
    
    class Contractor : IPayable
    {
        private string name;
        private double hourlyRate;
        
        public Contractor(string name, double hourlyRate)
        {
            this.name = name;
            this.hourlyRate = hourlyRate;
        }
        
        public double CalculatePayment()
        {
            return hourlyRate * 160; // 160 hours per month
        }
    }
    
    class Invoice : IPayable
    {
        private double amount;
        
        public Invoice(double amount)
        {
            this.amount = amount;
        }
        
        public double CalculatePayment()
        {
            return amount;
        }
    }
    
    // ========================================================================
    // PROPERTIES EXAMPLE (Modern C# way)
    // ========================================================================
    class Student
    {
        // Auto-implemented properties
        public string Name { get; set; }
        public int Age { get; set; }
        
        // Property with backing field
        private double _gpa;
        public double GPA
        {
            get { return _gpa; }
            set
            {
                if (value >= 0 && value <= 4.0)
                    _gpa = value;
                else
                    Console.WriteLine("Invalid GPA!");
            }
        }
        
        // Read-only property
        public string StudentInfo
        {
            get { return $"{Name} - Age: {Age}, GPA: {GPA}"; }
        }
        
        // Constructor
        public Student(string name, int age, double gpa)
        {
            Name = name;
            Age = age;
            GPA = gpa;
        }
    }
}

// ============================================================================
// KEY OOP CONCEPTS FOR EXAM:
// ============================================================================
// 1. ENCAPSULATION: Hide data using private/protected, expose using public methods
//    - Use properties (get/set) instead of fields
//
// 2. INHERITANCE: 'class Dog : Animal' (Dog inherits from Animal)
//    - Use 'base' keyword to call parent constructor/methods
//    - Only single inheritance in C# (one parent class)
//
// 3. POLYMORPHISM: Same method, different behavior
//    - Method Overriding: use 'virtual' in parent, 'override' in child
//    - Method Overloading: same name, different parameters
//
// 4. ABSTRACTION: Hide complexity, show only essentials
//    - Abstract class: can have abstract and concrete methods
//    - Cannot create instance of abstract class
//    - Use 'abstract' keyword for class and methods
//
// 5. INTERFACES: Contract that classes must follow
//    - Only method signatures (no implementation)
//    - A class can implement multiple interfaces
//    - Use 'interface' keyword, name starts with 'I'
//
// 6. ACCESS MODIFIERS:
//    - public: accessible everywhere
//    - private: accessible only within same class
//    - protected: accessible in same class and derived classes
//    - internal: accessible within same assembly
//
// 7. CONSTRUCTORS: Special method to initialize objects
//    - Same name as class, no return type
//    - Can be overloaded (multiple constructors)
//
// 8. PROPERTIES vs FIELDS:
//    - Fields: private data (e.g., private string name;)
//    - Properties: controlled access (e.g., public string Name { get; set; })
