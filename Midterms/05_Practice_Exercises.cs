// ============================================================================
// C# MIDTERM EXAM - PRACTICE EXERCISES
// ============================================================================
// Practice questions covering all topics: Fundamentals, OOP, SOLID, Events
// Try to solve these without looking at answers first!

using System;
using System.Collections.Generic;

namespace MidtermPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# MIDTERM PRACTICE EXERCISES ===\n");
            Console.WriteLine("Choose an exercise to run (1-10) or 0 to run all:\n");
            
            Console.WriteLine("1. Exercise 1: Calculator with OOP");
            Console.WriteLine("2. Exercise 2: Student Management System");
            Console.WriteLine("3. Exercise 3: Shape Area Calculator (OCP)");
            Console.WriteLine("4. Exercise 4: Animal Hierarchy (LSP)");
            Console.WriteLine("5. Exercise 5: Worker Interfaces (ISP)");
            Console.WriteLine("6. Exercise 6: Notification System (Events)");
            Console.WriteLine("7. Exercise 7: Temperature Monitor (Events + Custom EventArgs)");
            Console.WriteLine("8. Exercise 8: E-commerce System (SRP)");
            Console.WriteLine("9. Exercise 9: Payment Processing (DIP)");
            Console.WriteLine("10. Exercise 10: Complete Application (All SOLID + Events)");
            
            Console.Write("\nYour choice: ");
            string choice = Console.ReadLine();
            
            Console.WriteLine("\n" + new string('=', 70) + "\n");
            
            switch (choice)
            {
                case "1":
                    Exercise1.Run();
                    break;
                case "2":
                    Exercise2.Run();
                    break;
                case "3":
                    Exercise3.Run();
                    break;
                case "4":
                    Exercise4.Run();
                    break;
                case "5":
                    Exercise5.Run();
                    break;
                case "6":
                    Exercise6.Run();
                    break;
                case "7":
                    Exercise7.Run();
                    break;
                case "8":
                    Exercise8.Run();
                    break;
                case "9":
                    Exercise9.Run();
                    break;
                case "10":
                    Exercise10.Run();
                    break;
                case "0":
                    RunAllExercises();
                    break;
                default:
                    Console.WriteLine("Invalid choice!");
                    break;
            }
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        static void RunAllExercises()
        {
            Exercise1.Run();
            Exercise2.Run();
            Exercise3.Run();
            Exercise4.Run();
            Exercise5.Run();
            Exercise6.Run();
            Exercise7.Run();
            Exercise8.Run();
            Exercise9.Run();
            Exercise10.Run();
        }
    }
    
    // ========================================================================
    // EXERCISE 1: Calculator with OOP
    // ========================================================================
    // Topic: Classes, Methods, Encapsulation
    // Task: Create a Calculator class with Add, Subtract, Multiply, Divide
    //       Add error handling for division by zero
    class Exercise1
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 1: Calculator with OOP");
            Console.WriteLine(new string('-', 70));
            
            SimpleCalculator calc = new SimpleCalculator();
            
            Console.WriteLine($"10 + 5 = {calc.Add(10, 5)}");
            Console.WriteLine($"10 - 5 = {calc.Subtract(10, 5)}");
            Console.WriteLine($"10 * 5 = {calc.Multiply(10, 5)}");
            Console.WriteLine($"10 / 5 = {calc.Divide(10, 5)}");
            Console.WriteLine($"10 / 0 = {calc.Divide(10, 0)}");
            
            Console.WriteLine();
        }
    }
    
    class SimpleCalculator
    {
        public double Add(double a, double b)
        {
            return a + b;
        }
        
        public double Subtract(double a, double b)
        {
            return a - b;
        }
        
        public double Multiply(double a, double b)
        {
            return a * b;
        }
        
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                return 0;
            }
            return a / b;
        }
    }
    
    // ========================================================================
    // EXERCISE 2: Student Management System
    // ========================================================================
    // Topic: Classes, Properties, Collections, Methods
    // Task: Create Student class with properties (Name, ID, GPA)
    //       Create StudentManager class to add, remove, and find students
    class Exercise2
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 2: Student Management System");
            Console.WriteLine(new string('-', 70));
            
            StudentManager manager = new StudentManager();
            
            manager.AddStudent(new Student("Kaan", 220404046, 3.5));
            manager.AddStudent(new Student("Ayşe", 220404047, 3.8));
            manager.AddStudent(new Student("Mehmet", 220404048, 3.2));
            
            manager.DisplayAllStudents();
            
            Student found = manager.FindStudent(220404047);
            if (found != null)
                Console.WriteLine($"\nFound: {found.GetInfo()}");
            
            Console.WriteLine();
        }
    }
    
    class Student
    {
        public string Name { get; set; }
        public int ID { get; set; }
        public double GPA { get; set; }
        
        public Student(string name, int id, double gpa)
        {
            Name = name;
            ID = id;
            GPA = gpa;
        }
        
        public string GetInfo()
        {
            return $"Student: {Name}, ID: {ID}, GPA: {GPA}";
        }
    }
    
    class StudentManager
    {
        private List<Student> students = new List<Student>();
        
        public void AddStudent(Student student)
        {
            students.Add(student);
            Console.WriteLine($"Added: {student.Name}");
        }
        
        public void RemoveStudent(int id)
        {
            Student student = FindStudent(id);
            if (student != null)
            {
                students.Remove(student);
                Console.WriteLine($"Removed: {student.Name}");
            }
        }
        
        public Student FindStudent(int id)
        {
            foreach (Student student in students)
            {
                if (student.ID == id)
                    return student;
            }
            return null;
        }
        
        public void DisplayAllStudents()
        {
            Console.WriteLine($"\nTotal students: {students.Count}");
            foreach (Student student in students)
            {
                Console.WriteLine(student.GetInfo());
            }
        }
    }
    
    // ========================================================================
    // EXERCISE 3: Shape Area Calculator (OCP)
    // ========================================================================
    // Topic: Open/Closed Principle, Polymorphism, Abstract Classes
    // Task: Create abstract Shape class with CalculateArea method
    //       Implement Circle, Rectangle, Triangle
    //       Show how to add new shapes without modifying existing code
    class Exercise3
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 3: Shape Area Calculator (OCP)");
            Console.WriteLine(new string('-', 70));
            
            List<Shape> shapes = new List<Shape>
            {
                new Circle(5),
                new Rectangle(4, 6),
                new Triangle(3, 8)
            };
            
            foreach (Shape shape in shapes)
            {
                Console.WriteLine($"{shape.GetType().Name} area: {shape.CalculateArea():F2}");
            }
            
            Console.WriteLine();
        }
    }
    
    abstract class Shape
    {
        public abstract double CalculateArea();
    }
    
    class Circle : Shape
    {
        private double radius;
        
        public Circle(double radius)
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
        private double width, height;
        
        public Rectangle(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        
        public override double CalculateArea()
        {
            return width * height;
        }
    }
    
    class Triangle : Shape
    {
        private double baseLength, height;
        
        public Triangle(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }
        
        public override double CalculateArea()
        {
            return 0.5 * baseLength * height;
        }
    }
    
    // ========================================================================
    // EXERCISE 4: Animal Hierarchy (LSP)
    // ========================================================================
    // Topic: Liskov Substitution Principle, Inheritance
    // Task: Create proper animal hierarchy where derived classes
    //       don't break base class behavior
    class Exercise4
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 4: Animal Hierarchy (LSP)");
            Console.WriteLine(new string('-', 70));
            
            List<Animal> animals = new List<Animal>
            {
                new Dog("Max"),
                new Cat("Whiskers"),
                new Bird("Tweety")
            };
            
            foreach (Animal animal in animals)
            {
                animal.MakeSound();
                animal.Move();
            }
            
            Console.WriteLine();
        }
    }
    
    abstract class Animal
    {
        protected string name;
        
        public Animal(string name)
        {
            this.name = name;
        }
        
        public abstract void MakeSound();
        public abstract void Move();
    }
    
    class Dog : Animal
    {
        public Dog(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Hav hav!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{name} is running");
        }
    }
    
    class Cat : Animal
    {
        public Cat(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Miyav!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{name} is walking");
        }
    }
    
    class Bird : Animal
    {
        public Bird(string name) : base(name) { }
        
        public override void MakeSound()
        {
            Console.WriteLine($"{name} says: Cik cik!");
        }
        
        public override void Move()
        {
            Console.WriteLine($"{name} is flying");
        }
    }
    
    // ========================================================================
    // EXERCISE 5: Worker Interfaces (ISP)
    // ========================================================================
    // Topic: Interface Segregation Principle
    // Task: Create small, specific interfaces instead of large general ones
    class Exercise5
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 5: Worker Interfaces (ISP)");
            Console.WriteLine(new string('-', 70));
            
            Human human = new Human("Ali");
            Robot robot = new Robot("R2D2");
            
            Console.WriteLine("Human:");
            human.Work();
            human.Eat();
            human.Sleep();
            
            Console.WriteLine("\nRobot:");
            robot.Work();
            
            Console.WriteLine();
        }
    }
    
    interface IWorkable
    {
        void Work();
    }
    
    interface IEatable
    {
        void Eat();
    }
    
    interface ISleepable
    {
        void Sleep();
    }
    
    class Human : IWorkable, IEatable, ISleepable
    {
        private string name;
        
        public Human(string name)
        {
            this.name = name;
        }
        
        public void Work()
        {
            Console.WriteLine($"{name} is working");
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
    
    class Robot : IWorkable
    {
        private string name;
        
        public Robot(string name)
        {
            this.name = name;
        }
        
        public void Work()
        {
            Console.WriteLine($"{name} is working 24/7");
        }
    }
    
    // ========================================================================
    // EXERCISE 6: Notification System (Events)
    // ========================================================================
    // Topic: Events, Delegates, Event Handlers
    // Task: Create notification system with events for different notification types
    class Exercise6
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 6: Notification System (Events)");
            Console.WriteLine(new string('-', 70));
            
            OrderProcessor processor = new OrderProcessor();
            
            processor.OrderPlaced += (sender, e) => 
                Console.WriteLine("Event: Order placed notification sent");
            
            processor.OrderShipped += (sender, e) => 
                Console.WriteLine("Event: Order shipped notification sent");
            
            processor.PlaceOrder(12345);
            processor.ShipOrder(12345);
            
            Console.WriteLine();
        }
    }
    
    class OrderProcessor
    {
        public event EventHandler OrderPlaced;
        public event EventHandler OrderShipped;
        
        public void PlaceOrder(int orderId)
        {
            Console.WriteLine($"Placing order {orderId}...");
            OnOrderPlaced();
        }
        
        public void ShipOrder(int orderId)
        {
            Console.WriteLine($"Shipping order {orderId}...");
            OnOrderShipped();
        }
        
        protected virtual void OnOrderPlaced()
        {
            OrderPlaced?.Invoke(this, EventArgs.Empty);
        }
        
        protected virtual void OnOrderShipped()
        {
            OrderShipped?.Invoke(this, EventArgs.Empty);
        }
    }
    
    // ========================================================================
    // EXERCISE 7: Temperature Monitor (Events + Custom EventArgs)
    // ========================================================================
    // Topic: Events, Custom EventArgs, Event Handlers
    // Task: Create temperature monitoring system that raises events
    //       when temperature goes above/below thresholds
    class Exercise7
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 7: Temperature Monitor (Events + Custom EventArgs)");
            Console.WriteLine(new string('-', 70));
            
            TemperatureMonitor monitor = new TemperatureMonitor();
            
            monitor.TemperatureChanged += (sender, e) =>
                Console.WriteLine($"Temperature: {e.Temperature}°C");
            
            monitor.HighTemperatureAlert += (sender, e) =>
                Console.WriteLine($"⚠️ HIGH TEMP ALERT: {e.Temperature}°C!");
            
            monitor.LowTemperatureAlert += (sender, e) =>
                Console.WriteLine($"❄️ LOW TEMP ALERT: {e.Temperature}°C!");
            
            monitor.SetTemperature(22);
            monitor.SetTemperature(35);
            monitor.SetTemperature(-5);
            
            Console.WriteLine();
        }
    }
    
    class TemperatureEventArgs : EventArgs
    {
        public double Temperature { get; set; }
        
        public TemperatureEventArgs(double temperature)
        {
            Temperature = temperature;
        }
    }
    
    class TemperatureMonitor
    {
        private double currentTemperature;
        
        public event EventHandler<TemperatureEventArgs> TemperatureChanged;
        public event EventHandler<TemperatureEventArgs> HighTemperatureAlert;
        public event EventHandler<TemperatureEventArgs> LowTemperatureAlert;
        
        public void SetTemperature(double temperature)
        {
            currentTemperature = temperature;
            
            OnTemperatureChanged(new TemperatureEventArgs(temperature));
            
            if (temperature > 30)
                OnHighTemperatureAlert(new TemperatureEventArgs(temperature));
            else if (temperature < 0)
                OnLowTemperatureAlert(new TemperatureEventArgs(temperature));
        }
        
        protected virtual void OnTemperatureChanged(TemperatureEventArgs e)
        {
            TemperatureChanged?.Invoke(this, e);
        }
        
        protected virtual void OnHighTemperatureAlert(TemperatureEventArgs e)
        {
            HighTemperatureAlert?.Invoke(this, e);
        }
        
        protected virtual void OnLowTemperatureAlert(TemperatureEventArgs e)
        {
            LowTemperatureAlert?.Invoke(this, e);
        }
    }
    
    // ========================================================================
    // EXERCISE 8: E-commerce System (SRP)
    // ========================================================================
    // Topic: Single Responsibility Principle
    // Task: Separate order processing into multiple classes,
    //       each with single responsibility
    class Exercise8
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 8: E-commerce System (SRP)");
            Console.WriteLine(new string('-', 70));
            
            Order order = new Order(1001, "Laptop", 15000);
            
            OrderValidator validator = new OrderValidator();
            OrderRepository repository = new OrderRepository();
            OrderEmailService emailService = new OrderEmailService();
            
            if (validator.Validate(order))
            {
                repository.Save(order);
                emailService.SendConfirmation(order);
            }
            
            Console.WriteLine();
        }
    }
    
    class Order
    {
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public double Amount { get; set; }
        
        public Order(int orderId, string productName, double amount)
        {
            OrderId = orderId;
            ProductName = productName;
            Amount = amount;
        }
    }
    
    class OrderValidator
    {
        public bool Validate(Order order)
        {
            if (order.Amount <= 0)
            {
                Console.WriteLine("Invalid order amount");
                return false;
            }
            Console.WriteLine($"Order {order.OrderId} validated");
            return true;
        }
    }
    
    class OrderRepository
    {
        public void Save(Order order)
        {
            Console.WriteLine($"Order {order.OrderId} saved to database");
        }
    }
    
    class OrderEmailService
    {
        public void SendConfirmation(Order order)
        {
            Console.WriteLine($"Confirmation email sent for order {order.OrderId}");
        }
    }
    
    // ========================================================================
    // EXERCISE 9: Payment Processing (DIP)
    // ========================================================================
    // Topic: Dependency Inversion Principle
    // Task: Use interfaces to decouple high-level and low-level modules
    class Exercise9
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 9: Payment Processing (DIP)");
            Console.WriteLine(new string('-', 70));
            
            IPaymentProcessor creditCard = new CreditCardProcessor();
            PaymentService service1 = new PaymentService(creditCard);
            service1.ProcessPayment(100);
            
            IPaymentProcessor paypal = new PayPalProcessor();
            PaymentService service2 = new PaymentService(paypal);
            service2.ProcessPayment(200);
            
            Console.WriteLine();
        }
    }
    
    interface IPaymentProcessor
    {
        void ProcessPayment(double amount);
    }
    
    class CreditCardProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment: {amount} TL");
        }
    }
    
    class PayPalProcessor : IPaymentProcessor
    {
        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment: {amount} TL");
        }
    }
    
    class PaymentService
    {
        private IPaymentProcessor processor;
        
        public PaymentService(IPaymentProcessor processor)
        {
            this.processor = processor;
        }
        
        public void ProcessPayment(double amount)
        {
            processor.ProcessPayment(amount);
        }
    }
    
    // ========================================================================
    // EXERCISE 10: Complete Application (All SOLID + Events)
    // ========================================================================
    // Topic: All SOLID principles + Event-based programming
    // Task: Build a simple library system that demonstrates all concepts
    class Exercise10
    {
        public static void Run()
        {
            Console.WriteLine("EXERCISE 10: Complete Library System");
            Console.WriteLine(new string('-', 70));
            
            Library library = new Library();
            
            library.BookBorrowed += (sender, e) =>
                Console.WriteLine($"📚 Event: '{e.BookTitle}' borrowed by {e.MemberName}");
            
            library.BookReturned += (sender, e) =>
                Console.WriteLine($"📖 Event: '{e.BookTitle}' returned by {e.MemberName}");
            
            library.BorrowBook("1984", "Kaan");
            library.BorrowBook("Animal Farm", "Ayşe");
            library.ReturnBook("1984", "Kaan");
            
            Console.WriteLine();
        }
    }
    
    class LibraryEventArgs : EventArgs
    {
        public string BookTitle { get; set; }
        public string MemberName { get; set; }
        
        public LibraryEventArgs(string bookTitle, string memberName)
        {
            BookTitle = bookTitle;
            MemberName = memberName;
        }
    }
    
    class Library
    {
        public event EventHandler<LibraryEventArgs> BookBorrowed;
        public event EventHandler<LibraryEventArgs> BookReturned;
        
        public void BorrowBook(string bookTitle, string memberName)
        {
            Console.WriteLine($"{memberName} is borrowing '{bookTitle}'");
            OnBookBorrowed(new LibraryEventArgs(bookTitle, memberName));
        }
        
        public void ReturnBook(string bookTitle, string memberName)
        {
            Console.WriteLine($"{memberName} is returning '{bookTitle}'");
            OnBookReturned(new LibraryEventArgs(bookTitle, memberName));
        }
        
        protected virtual void OnBookBorrowed(LibraryEventArgs e)
        {
            BookBorrowed?.Invoke(this, e);
        }
        
        protected virtual void OnBookReturned(LibraryEventArgs e)
        {
            BookReturned?.Invoke(this, e);
        }
    }
}

// ============================================================================
// EXAM PREPARATION TIPS:
// ============================================================================
// 1. Understand the WHY, not just the HOW
//    - Why do we use SOLID principles?
//    - Why events instead of regular method calls?
//
// 2. Practice writing code by hand (no IDE help in exams!)
//    - Remember syntax exactly
//    - Know common method names (Add, Remove, Contains, etc.)
//
// 3. Common mistakes to avoid:
//    ❌ Forgetting 'event' keyword
//    ❌ Not checking null before invoking events
//    ❌ Breaking LSP by throwing exceptions in overridden methods
//    ❌ Making interfaces too large (ISP violation)
//    ❌ Direct dependency on concrete classes (DIP violation)
//
// 4. Key things professors look for:
//    ✓ Proper use of access modifiers (public, private, protected)
//    ✓ Following naming conventions
//    ✓ Proper event handler signature
//    ✓ Understanding inheritance vs interfaces
//    ✓ Applying SOLID principles correctly
//
// 5. Study these in detail:
//    - Event handler signature: (object sender, EventArgs e)
//    - How to raise events: MyEvent?.Invoke(this, EventArgs.Empty)
//    - Abstract vs Interface differences
//    - When to use each SOLID principle
//    - Inheritance syntax: class Child : Parent
//    - Interface implementation: class MyClass : IMyInterface
//
// Good luck on your midterm! 🎓
