// ============================================================================
// SOLID PRINCIPLES
// ============================================================================
// SOLID is an acronym for 5 design principles for writing maintainable code
// S - Single Responsibility Principle
// O - Open/Closed Principle
// L - Liskov Substitution Principle
// I - Interface Segregation Principle
// D - Dependency Inversion Principle

using System;
using System.Collections.Generic;
using System.IO;

namespace SOLIDPrinciples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== SOLID PRINCIPLES ===\n");
            
            SRPDemo();
            OCPDemo();
            LSPDemo();
            ISPDemo();
            DIPDemo();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // ====================================================================
        // 1. SINGLE RESPONSIBILITY PRINCIPLE (SRP)
        // A class should have only ONE reason to change
        // Each class should do ONE thing and do it well
        // ====================================================================
        static void SRPDemo()
        {
            Console.WriteLine("--- SINGLE RESPONSIBILITY PRINCIPLE ---");
            
            // GOOD: Each class has one responsibility
            User user = new User { Name = "Kaan", Email = "kaan@example.com" };
            
            UserValidator validator = new UserValidator();
            if (validator.IsValid(user))
            {
                UserRepository repository = new UserRepository();
                repository.Save(user);
                
                EmailService emailService = new EmailService();
                emailService.SendWelcomeEmail(user);
            }
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 2. OPEN/CLOSED PRINCIPLE (OCP)
        // Classes should be OPEN for extension but CLOSED for modification
        // Add new functionality by extending, not by changing existing code
        // ====================================================================
        static void OCPDemo()
        {
            Console.WriteLine("--- OPEN/CLOSED PRINCIPLE ---");
            
            // GOOD: Can add new shapes without modifying AreaCalculator
            List<IShape> shapes = new List<IShape>
            {
                new CircleOCP(5),
                new RectangleOCP(4, 6),
                new TriangleOCP(3, 8)
            };
            
            AreaCalculator calculator = new AreaCalculator();
            double totalArea = calculator.CalculateTotalArea(shapes);
            Console.WriteLine($"Total area: {totalArea}");
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 3. LISKOV SUBSTITUTION PRINCIPLE (LSP)
        // Derived classes must be substitutable for their base classes
        // Child class should not break parent class behavior
        // ====================================================================
        static void LSPDemo()
        {
            Console.WriteLine("--- LISKOV SUBSTITUTION PRINCIPLE ---");
            
            // GOOD: All birds can be used as Bird
            List<BirdLSP> birds = new List<BirdLSP>
            {
                new SparrowLSP(),
                new PenguinLSP()
            };
            
            foreach (BirdLSP bird in birds)
            {
                bird.Eat();
                bird.Move();  // Each moves differently, but all can move
            }
            
            // Only flying birds can fly
            FlyingBird sparrow = new SparrowLSP();
            sparrow.Fly();
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 4. INTERFACE SEGREGATION PRINCIPLE (ISP)
        // Don't force classes to implement interfaces they don't use
        // Many specific interfaces are better than one general interface
        // ====================================================================
        static void ISPDemo()
        {
            Console.WriteLine("--- INTERFACE SEGREGATION PRINCIPLE ---");
            
            // GOOD: Each worker implements only what they need
            IWorkable robot = new RobotWorker();
            robot.Work();
            // robot.Eat();  // ERROR! Robot doesn't have Eat method
            
            HumanWorker human = new HumanWorker();
            human.Work();
            human.Eat();
            human.Sleep();
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 5. DEPENDENCY INVERSION PRINCIPLE (DIP)
        // High-level modules should not depend on low-level modules
        // Both should depend on abstractions (interfaces)
        // ====================================================================
        static void DIPDemo()
        {
            Console.WriteLine("--- DEPENDENCY INVERSION PRINCIPLE ---");
            
            // GOOD: Can easily switch database implementation
            IDatabase sqlDatabase = new SQLDatabase();
            DatabaseManager managerSQL = new DatabaseManager(sqlDatabase);
            managerSQL.SaveData("User data");
            
            IDatabase mongoDatabase = new MongoDatabase();
            DatabaseManager managerMongo = new DatabaseManager(mongoDatabase);
            managerMongo.SaveData("Order data");
            
            Console.WriteLine();
        }
    }
    
    // ========================================================================
    // 1. SINGLE RESPONSIBILITY PRINCIPLE - EXAMPLES
    // ========================================================================
    
    // GOOD: User class only handles user data
    class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
    
    // GOOD: UserValidator only handles validation
    class UserValidator
    {
        public bool IsValid(User user)
        {
            if (string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.Email))
            {
                Console.WriteLine("Invalid user data!");
                return false;
            }
            return true;
        }
    }
    
    // GOOD: UserRepository only handles data persistence
    class UserRepository
    {
        public void Save(User user)
        {
            Console.WriteLine($"User {user.Name} saved to database");
        }
    }
    
    // GOOD: EmailService only handles email sending
    class EmailService
    {
        public void SendWelcomeEmail(User user)
        {
            Console.WriteLine($"Welcome email sent to {user.Email}");
        }
    }
    
    // BAD EXAMPLE (Don't do this!):
    class UserManagerBAD
    {
        // This class has TOO MANY responsibilities!
        public void CreateUser(string name, string email)
        {
            // Validation
            if (string.IsNullOrEmpty(name)) return;
            
            // Save to database
            Console.WriteLine("Saving to database...");
            
            // Send email
            Console.WriteLine("Sending email...");
            
            // Log activity
            Console.WriteLine("Logging...");
        }
    }
    
    // ========================================================================
    // 2. OPEN/CLOSED PRINCIPLE - EXAMPLES
    // ========================================================================
    
    interface IShape
    {
        double CalculateArea();
    }
    
    class CircleOCP : IShape
    {
        private double radius;
        
        public CircleOCP(double radius)
        {
            this.radius = radius;
        }
        
        public double CalculateArea()
        {
            return Math.PI * radius * radius;
        }
    }
    
    class RectangleOCP : IShape
    {
        private double width, height;
        
        public RectangleOCP(double width, double height)
        {
            this.width = width;
            this.height = height;
        }
        
        public double CalculateArea()
        {
            return width * height;
        }
    }
    
    class TriangleOCP : IShape
    {
        private double baseLength, height;
        
        public TriangleOCP(double baseLength, double height)
        {
            this.baseLength = baseLength;
            this.height = height;
        }
        
        public double CalculateArea()
        {
            return 0.5 * baseLength * height;
        }
    }
    
    // GOOD: Can add new shapes without modifying this class
    class AreaCalculator
    {
        public double CalculateTotalArea(List<IShape> shapes)
        {
            double total = 0;
            foreach (IShape shape in shapes)
            {
                total += shape.CalculateArea();
            }
            return total;
        }
    }
    
    // BAD EXAMPLE (Don't do this!):
    class AreaCalculatorBAD
    {
        public double CalculateArea(object shape)
        {
            // Need to modify this method every time we add a new shape!
            if (shape is CircleOCP circle)
                return Math.PI * 5 * 5;
            else if (shape is RectangleOCP rectangle)
                return 4 * 6;
            // What if we add Triangle? Must modify this code!
            return 0;
        }
    }
    
    // ========================================================================
    // 3. LISKOV SUBSTITUTION PRINCIPLE - EXAMPLES
    // ========================================================================
    
    // GOOD: Base class for all birds
    abstract class BirdLSP
    {
        public abstract void Eat();
        public abstract void Move();
    }
    
    // GOOD: Separate interface for flying birds
    abstract class FlyingBird : BirdLSP
    {
        public abstract void Fly();
    }
    
    class SparrowLSP : FlyingBird
    {
        public override void Eat()
        {
            Console.WriteLine("Sparrow is eating");
        }
        
        public override void Move()
        {
            Console.WriteLine("Sparrow is flying");
        }
        
        public override void Fly()
        {
            Console.WriteLine("Sparrow flies high!");
        }
    }
    
    class PenguinLSP : BirdLSP
    {
        public override void Eat()
        {
            Console.WriteLine("Penguin is eating fish");
        }
        
        public override void Move()
        {
            Console.WriteLine("Penguin is swimming");
        }
        
        // Penguin doesn't fly, so doesn't inherit from FlyingBird
    }
    
    // BAD EXAMPLE (Don't do this!):
    class BirdBAD
    {
        public virtual void Fly()
        {
            Console.WriteLine("Flying...");
        }
    }
    
    class PenguinBAD : BirdBAD
    {
        public override void Fly()
        {
            // Penguins can't fly! This breaks LSP!
            throw new Exception("Penguins can't fly!");
        }
    }
    
    // ========================================================================
    // 4. INTERFACE SEGREGATION PRINCIPLE - EXAMPLES
    // ========================================================================
    
    // GOOD: Small, specific interfaces
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
    
    // Human needs all three
    class HumanWorker : IWorkable, IEatable, ISleepable
    {
        public void Work()
        {
            Console.WriteLine("Human is working");
        }
        
        public void Eat()
        {
            Console.WriteLine("Human is eating");
        }
        
        public void Sleep()
        {
            Console.WriteLine("Human is sleeping");
        }
    }
    
    // Robot only needs work
    class RobotWorker : IWorkable
    {
        public void Work()
        {
            Console.WriteLine("Robot is working 24/7");
        }
        
        // Robot doesn't need Eat() or Sleep()
    }
    
    // BAD EXAMPLE (Don't do this!):
    interface IWorkerBAD
    {
        void Work();
        void Eat();
        void Sleep();
    }
    
    class RobotWorkerBAD : IWorkerBAD
    {
        public void Work()
        {
            Console.WriteLine("Working...");
        }
        
        public void Eat()
        {
            // Robot doesn't eat! Forced to implement unused method
            throw new NotImplementedException();
        }
        
        public void Sleep()
        {
            // Robot doesn't sleep! Forced to implement unused method
            throw new NotImplementedException();
        }
    }
    
    // ========================================================================
    // 5. DEPENDENCY INVERSION PRINCIPLE - EXAMPLES
    // ========================================================================
    
    // GOOD: Abstraction (interface)
    interface IDatabase
    {
        void Save(string data);
    }
    
    // Low-level modules implement interface
    class SQLDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to SQL Database: {data}");
        }
    }
    
    class MongoDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to MongoDB: {data}");
        }
    }
    
    class OracleDatabase : IDatabase
    {
        public void Save(string data)
        {
            Console.WriteLine($"Saving to Oracle Database: {data}");
        }
    }
    
    // GOOD: High-level module depends on abstraction
    class DatabaseManager
    {
        private IDatabase database;
        
        // Dependency injection through constructor
        public DatabaseManager(IDatabase database)
        {
            this.database = database;
        }
        
        public void SaveData(string data)
        {
            database.Save(data);
        }
    }
    
    // BAD EXAMPLE (Don't do this!):
    class DatabaseManagerBAD
    {
        private SQLDatabase database;  // Tightly coupled to SQLDatabase!
        
        public DatabaseManagerBAD()
        {
            database = new SQLDatabase();  // Hard to change database type
        }
        
        public void SaveData(string data)
        {
            database.Save(data);
            // If we want to use MongoDB, we must modify this class!
        }
    }
}

// ============================================================================
// SOLID PRINCIPLES SUMMARY FOR EXAM:
// ============================================================================
//
// 1. SINGLE RESPONSIBILITY PRINCIPLE (SRP)
//    - One class = One responsibility
//    - Example: Separate validation, database, email into different classes
//
// 2. OPEN/CLOSED PRINCIPLE (OCP)
//    - Open for extension, Closed for modification
//    - Use interfaces/abstract classes to add new functionality
//    - Example: Add new shapes without modifying AreaCalculator
//
// 3. LISKOV SUBSTITUTION PRINCIPLE (LSP)
//    - Child classes must be replaceable with parent classes
//    - Don't break parent class behavior in child
//    - Example: Penguin shouldn't inherit Fly() if it can't fly
//
// 4. INTERFACE SEGREGATION PRINCIPLE (ISP)
//    - Many small interfaces > One large interface
//    - Don't force classes to implement unused methods
//    - Example: IWorkable, IEatable, ISleepable instead of one IWorker
//
// 5. DEPENDENCY INVERSION PRINCIPLE (DIP)
//    - Depend on abstractions (interfaces), not concrete classes
//    - High-level modules independent of low-level modules
//    - Use dependency injection
//    - Example: DatabaseManager depends on IDatabase, not SQLDatabase
//
// ============================================================================
// WHY SOLID MATTERS:
// ============================================================================
// ✓ Easier to maintain and modify code
// ✓ Easier to test (can mock dependencies)
// ✓ More flexible and reusable code
// ✓ Reduces bugs when adding new features
// ✓ Better code organization
//
// REMEMBER: SOLID principles work together to create better software design!
