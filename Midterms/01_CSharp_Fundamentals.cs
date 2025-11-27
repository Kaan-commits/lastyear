// ============================================================================
// C# FUNDAMENTALS - INTRO TO C#
// ============================================================================
// C# (C Sharp) is a modern, object-oriented programming language developed by Microsoft
// It's type-safe, runs on .NET, and used for web, desktop, mobile, and game development

using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpFundamentals
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== C# FUNDAMENTALS ===\n");
            
            // Call all demo methods
            DataTypesDemo();
            VariablesDemo();
            OperatorsDemo();
            ControlFlowDemo();
            ArraysDemo();
            CollectionsDemo();
            MethodsDemo();
            StringOperationsDemo();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // ====================================================================
        // 1. DATA TYPES
        // ====================================================================
        static void DataTypesDemo()
        {
            Console.WriteLine("--- DATA TYPES ---");
            
            // Value Types (stored in stack)
            int age = 25;                    // Integer: -2,147,483,648 to 2,147,483,647
            long bigNumber = 1000000000L;    // Long: larger integer
            float price = 19.99f;            // Float: 32-bit floating point
            double salary = 50000.50;        // Double: 64-bit floating point (more precise)
            decimal money = 100.99m;         // Decimal: 128-bit (best for money)
            char grade = 'A';                // Character: single character
            bool isStudent = true;           // Boolean: true or false
            
            // Reference Types (stored in heap)
            string name = "Kaan";            // String: text
            object anything = 42;            // Object: can hold any type
            
            Console.WriteLine($"Age: {age}, Name: {name}, Grade: {grade}");
            Console.WriteLine($"Price: {price}, Is Student: {isStudent}\n");
        }
        
        // ====================================================================
        // 2. VARIABLES & CONSTANTS
        // ====================================================================
        static void VariablesDemo()
        {
            Console.WriteLine("--- VARIABLES & CONSTANTS ---");
            
            // Variable declaration
            int x;              // Declaration
            x = 10;             // Assignment
            int y = 20;         // Declaration + Assignment
            
            // Type inference with 'var'
            var z = 30;         // Compiler infers type as int
            var text = "Hello"; // Compiler infers type as string
            
            // Constants (cannot be changed)
            const double PI = 3.14159;
            const int MAX_STUDENTS = 100;
            
            // Nullable types (can hold null)
            int? nullableAge = null;
            nullableAge = 25;
            
            Console.WriteLine($"x: {x}, y: {y}, z: {z}");
            Console.WriteLine($"PI: {PI}, Nullable Age: {nullableAge}\n");
        }
        
        // ====================================================================
        // 3. OPERATORS
        // ====================================================================
        static void OperatorsDemo()
        {
            Console.WriteLine("--- OPERATORS ---");
            
            // Arithmetic Operators
            int a = 10, b = 3;
            Console.WriteLine($"Addition: {a} + {b} = {a + b}");
            Console.WriteLine($"Subtraction: {a} - {b} = {a - b}");
            Console.WriteLine($"Multiplication: {a} * {b} = {a * b}");
            Console.WriteLine($"Division: {a} / {b} = {a / b}");
            Console.WriteLine($"Modulus: {a} % {b} = {a % b}");
            
            // Comparison Operators
            Console.WriteLine($"{a} == {b}: {a == b}");  // Equal
            Console.WriteLine($"{a} != {b}: {a != b}");  // Not equal
            Console.WriteLine($"{a} > {b}: {a > b}");    // Greater than
            Console.WriteLine($"{a} < {b}: {a < b}");    // Less than
            
            // Logical Operators
            bool x = true, y = false;
            Console.WriteLine($"x && y: {x && y}");  // AND
            Console.WriteLine($"x || y: {x || y}");  // OR
            Console.WriteLine($"!x: {!x}");          // NOT
            
            // Increment/Decrement
            int counter = 5;
            counter++;  // counter = counter + 1
            Console.WriteLine($"After increment: {counter}");
            counter--;  // counter = counter - 1
            Console.WriteLine($"After decrement: {counter}\n");
        }
        
        // ====================================================================
        // 4. CONTROL FLOW
        // ====================================================================
        static void ControlFlowDemo()
        {
            Console.WriteLine("--- CONTROL FLOW ---");
            
            // If-Else Statement
            int score = 85;
            if (score >= 90)
                Console.WriteLine("Grade: A");
            else if (score >= 80)
                Console.WriteLine("Grade: B");
            else if (score >= 70)
                Console.WriteLine("Grade: C");
            else
                Console.WriteLine("Grade: F");
            
            // Switch Statement
            int day = 3;
            switch (day)
            {
                case 1:
                    Console.WriteLine("Monday");
                    break;
                case 2:
                    Console.WriteLine("Tuesday");
                    break;
                case 3:
                    Console.WriteLine("Wednesday");
                    break;
                default:
                    Console.WriteLine("Other day");
                    break;
            }
            
            // For Loop
            Console.Write("For loop: ");
            for (int i = 1; i <= 5; i++)
            {
                Console.Write($"{i} ");
            }
            Console.WriteLine();
            
            // While Loop
            Console.Write("While loop: ");
            int count = 1;
            while (count <= 5)
            {
                Console.Write($"{count} ");
                count++;
            }
            Console.WriteLine();
            
            // Do-While Loop
            Console.Write("Do-While loop: ");
            int num = 1;
            do
            {
                Console.Write($"{num} ");
                num++;
            } while (num <= 5);
            Console.WriteLine("\n");
        }
        
        // ====================================================================
        // 5. ARRAYS
        // ====================================================================
        static void ArraysDemo()
        {
            Console.WriteLine("--- ARRAYS ---");
            
            // Array declaration and initialization
            int[] numbers = new int[5];  // Size 5, all elements 0
            numbers[0] = 10;
            numbers[1] = 20;
            
            // Array with initializer
            string[] names = { "Ali", "Ayşe", "Mehmet", "Fatma" };
            
            // Accessing array elements
            Console.WriteLine($"First name: {names[0]}");
            Console.WriteLine($"Array length: {names.Length}");
            
            // Iterating through array
            Console.Write("All names: ");
            foreach (string name in names)
            {
                Console.Write($"{name} ");
            }
            Console.WriteLine();
            
            // Multi-dimensional array
            int[,] matrix = new int[2, 3] { { 1, 2, 3 }, { 4, 5, 6 } };
            Console.WriteLine($"Matrix[0,0]: {matrix[0, 0]}");
            Console.WriteLine($"Matrix[1,2]: {matrix[1, 2]}\n");
        }
        
        // ====================================================================
        // 6. COLLECTIONS (List, Dictionary)
        // ====================================================================
        static void CollectionsDemo()
        {
            Console.WriteLine("--- COLLECTIONS ---");
            
            // List (dynamic array)
            List<int> scores = new List<int>();
            scores.Add(90);
            scores.Add(85);
            scores.Add(95);
            scores.Remove(85);
            
            Console.WriteLine($"Scores count: {scores.Count}");
            Console.Write("Scores: ");
            foreach (int score in scores)
            {
                Console.Write($"{score} ");
            }
            Console.WriteLine();
            
            // Dictionary (key-value pairs)
            Dictionary<string, int> ages = new Dictionary<string, int>();
            ages["Ali"] = 20;
            ages["Ayşe"] = 22;
            ages["Mehmet"] = 21;
            
            Console.WriteLine($"Ali's age: {ages["Ali"]}");
            Console.WriteLine($"Dictionary contains 'Ali': {ages.ContainsKey("Ali")}");
            
            Console.Write("All people: ");
            foreach (var person in ages)
            {
                Console.Write($"{person.Key}={person.Value} ");
            }
            Console.WriteLine("\n");
        }
        
        // ====================================================================
        // 7. METHODS (FUNCTIONS)
        // ====================================================================
        static void MethodsDemo()
        {
            Console.WriteLine("--- METHODS ---");
            
            // Call methods
            SayHello();
            SayHelloTo("Kaan");
            
            int sum = Add(5, 3);
            Console.WriteLine($"Sum: {sum}");
            
            int result = Multiply(4, 5);
            Console.WriteLine($"Multiply: {result}");
            
            // Out parameter
            int quotient, remainder;
            Divide(17, 5, out quotient, out remainder);
            Console.WriteLine($"17 / 5 = {quotient} remainder {remainder}");
            
            // Ref parameter
            int value = 10;
            Console.WriteLine($"Before: {value}");
            DoubleValue(ref value);
            Console.WriteLine($"After: {value}\n");
        }
        
        // Method without parameters or return
        static void SayHello()
        {
            Console.WriteLine("Hello!");
        }
        
        // Method with parameter
        static void SayHelloTo(string name)
        {
            Console.WriteLine($"Hello, {name}!");
        }
        
        // Method with return value
        static int Add(int a, int b)
        {
            return a + b;
        }
        
        // Method with expression body (shorthand)
        static int Multiply(int a, int b) => a * b;
        
        // Out parameter (returns multiple values)
        static void Divide(int dividend, int divisor, out int quotient, out int remainder)
        {
            quotient = dividend / divisor;
            remainder = dividend % divisor;
        }
        
        // Ref parameter (modifies original variable)
        static void DoubleValue(ref int value)
        {
            value *= 2;
        }
        
        // ====================================================================
        // 8. STRING OPERATIONS
        // ====================================================================
        static void StringOperationsDemo()
        {
            Console.WriteLine("--- STRING OPERATIONS ---");
            
            string text = "Hello World";
            
            // String properties and methods
            Console.WriteLine($"Length: {text.Length}");
            Console.WriteLine($"Uppercase: {text.ToUpper()}");
            Console.WriteLine($"Lowercase: {text.ToLower()}");
            Console.WriteLine($"Contains 'World': {text.Contains("World")}");
            Console.WriteLine($"Starts with 'Hello': {text.StartsWith("Hello")}");
            Console.WriteLine($"Substring: {text.Substring(0, 5)}");
            Console.WriteLine($"Replace: {text.Replace("World", "C#")}");
            
            // String concatenation
            string firstName = "Kaan";
            string lastName = "Kara";
            string fullName = firstName + " " + lastName;
            Console.WriteLine($"Full name: {fullName}");
            
            // String interpolation
            int age = 22;
            string message = $"My name is {fullName} and I am {age} years old.";
            Console.WriteLine(message);
            
            // String splitting
            string csv = "apple,banana,orange";
            string[] fruits = csv.Split(',');
            Console.Write("Fruits: ");
            foreach (string fruit in fruits)
            {
                Console.Write($"{fruit} ");
            }
            Console.WriteLine();
        }
    }
}

// ============================================================================
// KEY CONCEPTS TO REMEMBER FOR EXAM:
// ============================================================================
// 1. C# is strongly-typed (must declare types)
// 2. Value types (int, bool, etc.) vs Reference types (string, objects)
// 3. Strings are immutable (cannot be changed after creation)
// 4. Arrays have fixed size, Lists are dynamic
// 5. Use 'var' for type inference (compiler determines type)
// 6. Methods can return one value or use 'out' for multiple values
// 7. 'ref' passes by reference, allowing method to modify original variable
// 8. Always use 'break' in switch statements to avoid fall-through
