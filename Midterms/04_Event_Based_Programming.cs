// ============================================================================
// EVENT-BASED PROGRAMMING IN C#
// ============================================================================
// Events allow objects to notify other objects when something happens
// Publisher-Subscriber pattern (also called Observer pattern)
// Publisher raises event → Subscribers respond to event

using System;
using System.Collections.Generic;

namespace EventBasedProgramming
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EVENT-BASED PROGRAMMING ===\n");
            
            BasicEventDemo();
            DelegateDemo();
            EventHandlerDemo();
            CustomEventArgsDemo();
            MulticastDelegateDemo();
            
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
        
        // ====================================================================
        // 1. BASIC EVENT EXAMPLE
        // ====================================================================
        static void BasicEventDemo()
        {
            Console.WriteLine("--- BASIC EVENT EXAMPLE ---");
            
            // Create publisher
            Button button = new Button();
            
            // Subscribe to event
            button.Clicked += Button_Clicked;
            button.Clicked += Button_ClickedAgain;
            
            // Trigger event
            button.Click();
            
            // Unsubscribe
            button.Clicked -= Button_ClickedAgain;
            
            Console.WriteLine("\nClicking again after unsubscribe:");
            button.Click();
            
            Console.WriteLine();
        }
        
        // Event handler methods
        static void Button_Clicked(object sender, EventArgs e)
        {
            Console.WriteLine("Button was clicked! (Handler 1)");
        }
        
        static void Button_ClickedAgain(object sender, EventArgs e)
        {
            Console.WriteLine("Button was clicked! (Handler 2)");
        }
        
        // ====================================================================
        // 2. DELEGATES - Foundation of Events
        // ====================================================================
        static void DelegateDemo()
        {
            Console.WriteLine("--- DELEGATES ---");
            
            // Delegates are type-safe function pointers
            Calculator calc = new Calculator();
            
            // Using delegate
            MathOperation operation = calc.Add;
            int result1 = operation(10, 5);
            Console.WriteLine($"10 + 5 = {result1}");
            
            // Change delegate to point to different method
            operation = calc.Multiply;
            int result2 = operation(10, 5);
            Console.WriteLine($"10 * 5 = {result2}");
            
            // Using Func and Action (built-in delegates)
            Func<int, int, int> addFunc = calc.Add;
            Console.WriteLine($"Using Func: 3 + 7 = {addFunc(3, 7)}");
            
            Action<string> printAction = Console.WriteLine;
            printAction("Using Action delegate!");
            
            Console.WriteLine();
        }
        
        // ====================================================================
        // 3. EVENT HANDLER PATTERN
        // ====================================================================
        static void EventHandlerDemo()
        {
            Console.WriteLine("--- EVENT HANDLER PATTERN ---");
            
            ProcessManager manager = new ProcessManager();
            
            // Subscribe to events
            manager.ProcessStarted += Manager_ProcessStarted;
            manager.ProcessCompleted += Manager_ProcessCompleted;
            
            // Run process
            manager.RunProcess("Data Analysis");
            
            Console.WriteLine();
        }
        
        static void Manager_ProcessStarted(object sender, EventArgs e)
        {
            Console.WriteLine("Event: Process has started!");
        }
        
        static void Manager_ProcessCompleted(object sender, EventArgs e)
        {
            Console.WriteLine("Event: Process has completed!");
        }
        
        // ====================================================================
        // 4. CUSTOM EVENT ARGS
        // ====================================================================
        static void CustomEventArgsDemo()
        {
            Console.WriteLine("--- CUSTOM EVENT ARGS ---");
            
            BankAccount account = new BankAccount("Kaan", 1000);
            
            // Subscribe to events with custom data
            account.MoneyDeposited += Account_MoneyDeposited;
            account.MoneyWithdrawn += Account_MoneyWithdrawn;
            account.LowBalanceWarning += Account_LowBalanceWarning;
            
            account.Deposit(500);
            account.Withdraw(1200);
            account.Withdraw(200);
            
            Console.WriteLine();
        }
        
        static void Account_MoneyDeposited(object sender, MoneyEventArgs e)
        {
            Console.WriteLine($"💰 Deposited: {e.Amount} TL. New balance: {e.NewBalance} TL");
        }
        
        static void Account_MoneyWithdrawn(object sender, MoneyEventArgs e)
        {
            Console.WriteLine($"💸 Withdrawn: {e.Amount} TL. New balance: {e.NewBalance} TL");
        }
        
        static void Account_LowBalanceWarning(object sender, MoneyEventArgs e)
        {
            Console.WriteLine($"⚠️ WARNING: Low balance! Current: {e.NewBalance} TL");
        }
        
        // ====================================================================
        // 5. MULTICAST DELEGATES
        // ====================================================================
        static void MulticastDelegateDemo()
        {
            Console.WriteLine("--- MULTICAST DELEGATES ---");
            
            NotificationService service = new NotificationService();
            
            // Multiple methods can be called by single delegate
            NotifyDelegate notifyAll = service.SendEmail;
            notifyAll += service.SendSMS;
            notifyAll += service.SendPushNotification;
            
            // Call all methods at once
            notifyAll("System maintenance at 2 AM");
            
            Console.WriteLine();
        }
    }
    
    // ========================================================================
    // 1. BASIC EVENT EXAMPLE
    // ========================================================================
    
    class Button
    {
        // Define event using EventHandler delegate
        public event EventHandler Clicked;
        
        // Method to raise the event
        public void Click()
        {
            Console.WriteLine("Button is being clicked...");
            
            // Raise event if there are subscribers
            // '?' is null-conditional operator (safe way to call event)
            Clicked?.Invoke(this, EventArgs.Empty);
        }
    }
    
    // ========================================================================
    // 2. DELEGATES
    // ========================================================================
    
    // Declare delegate (defines method signature)
    delegate int MathOperation(int a, int b);
    
    class Calculator
    {
        public int Add(int a, int b)
        {
            return a + b;
        }
        
        public int Subtract(int a, int b)
        {
            return a - b;
        }
        
        public int Multiply(int a, int b)
        {
            return a * b;
        }
        
        public int Divide(int a, int b)
        {
            return a / b;
        }
    }
    
    // ========================================================================
    // 3. EVENT HANDLER PATTERN
    // ========================================================================
    
    class ProcessManager
    {
        // Define events
        public event EventHandler ProcessStarted;
        public event EventHandler ProcessCompleted;
        
        public void RunProcess(string processName)
        {
            Console.WriteLine($"Starting process: {processName}");
            
            // Raise ProcessStarted event
            OnProcessStarted();
            
            // Simulate work
            Console.WriteLine("Processing...");
            System.Threading.Thread.Sleep(1000);
            
            // Raise ProcessCompleted event
            OnProcessCompleted();
        }
        
        // Protected virtual methods to raise events (best practice)
        protected virtual void OnProcessStarted()
        {
            ProcessStarted?.Invoke(this, EventArgs.Empty);
        }
        
        protected virtual void OnProcessCompleted()
        {
            ProcessCompleted?.Invoke(this, EventArgs.Empty);
        }
    }
    
    // ========================================================================
    // 4. CUSTOM EVENT ARGS
    // ========================================================================
    
    // Custom EventArgs class to pass data with events
    class MoneyEventArgs : EventArgs
    {
        public double Amount { get; set; }
        public double NewBalance { get; set; }
        
        public MoneyEventArgs(double amount, double newBalance)
        {
            Amount = amount;
            NewBalance = newBalance;
        }
    }
    
    class BankAccount
    {
        private string ownerName;
        private double balance;
        
        // Define events with custom EventArgs
        public event EventHandler<MoneyEventArgs> MoneyDeposited;
        public event EventHandler<MoneyEventArgs> MoneyWithdrawn;
        public event EventHandler<MoneyEventArgs> LowBalanceWarning;
        
        public BankAccount(string name, double initialBalance)
        {
            ownerName = name;
            balance = initialBalance;
        }
        
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                
                // Raise event with custom data
                OnMoneyDeposited(new MoneyEventArgs(amount, balance));
            }
        }
        
        public void Withdraw(double amount)
        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                
                // Raise event
                OnMoneyWithdrawn(new MoneyEventArgs(amount, balance));
                
                // Check for low balance
                if (balance < 300)
                {
                    OnLowBalanceWarning(new MoneyEventArgs(0, balance));
                }
            }
            else
            {
                Console.WriteLine("❌ Insufficient funds!");
            }
        }
        
        // Methods to raise events
        protected virtual void OnMoneyDeposited(MoneyEventArgs e)
        {
            MoneyDeposited?.Invoke(this, e);
        }
        
        protected virtual void OnMoneyWithdrawn(MoneyEventArgs e)
        {
            MoneyWithdrawn?.Invoke(this, e);
        }
        
        protected virtual void OnLowBalanceWarning(MoneyEventArgs e)
        {
            LowBalanceWarning?.Invoke(this, e);
        }
    }
    
    // ========================================================================
    // 5. MULTICAST DELEGATES
    // ========================================================================
    
    delegate void NotifyDelegate(string message);
    
    class NotificationService
    {
        public void SendEmail(string message)
        {
            Console.WriteLine($"📧 Email sent: {message}");
        }
        
        public void SendSMS(string message)
        {
            Console.WriteLine($"📱 SMS sent: {message}");
        }
        
        public void SendPushNotification(string message)
        {
            Console.WriteLine($"🔔 Push notification sent: {message}");
        }
    }
    
    // ========================================================================
    // REAL-WORLD EXAMPLE: STOCK PRICE MONITOR
    // ========================================================================
    
    class StockPriceChangedEventArgs : EventArgs
    {
        public string StockSymbol { get; set; }
        public double OldPrice { get; set; }
        public double NewPrice { get; set; }
        public double ChangePercent { get; set; }
        
        public StockPriceChangedEventArgs(string symbol, double oldPrice, double newPrice)
        {
            StockSymbol = symbol;
            OldPrice = oldPrice;
            NewPrice = newPrice;
            ChangePercent = ((newPrice - oldPrice) / oldPrice) * 100;
        }
    }
    
    class StockMonitor
    {
        private Dictionary<string, double> stockPrices = new Dictionary<string, double>();
        
        // Define event
        public event EventHandler<StockPriceChangedEventArgs> PriceChanged;
        
        public void UpdatePrice(string symbol, double newPrice)
        {
            double oldPrice = stockPrices.ContainsKey(symbol) ? stockPrices[symbol] : newPrice;
            stockPrices[symbol] = newPrice;
            
            // Raise event if price changed
            if (oldPrice != newPrice)
            {
                OnPriceChanged(new StockPriceChangedEventArgs(symbol, oldPrice, newPrice));
            }
        }
        
        protected virtual void OnPriceChanged(StockPriceChangedEventArgs e)
        {
            PriceChanged?.Invoke(this, e);
        }
    }
    
    class StockTrader
    {
        private string name;
        
        public StockTrader(string name)
        {
            this.name = name;
        }
        
        public void OnPriceChanged(object sender, StockPriceChangedEventArgs e)
        {
            Console.WriteLine($"{name} notified: {e.StockSymbol} changed from " +
                            $"{e.OldPrice:C} to {e.NewPrice:C} ({e.ChangePercent:F2}%)");
            
            if (e.ChangePercent > 5)
            {
                Console.WriteLine($"{name} is buying {e.StockSymbol}!");
            }
            else if (e.ChangePercent < -5)
            {
                Console.WriteLine($"{name} is selling {e.StockSymbol}!");
            }
        }
    }
    
    // ========================================================================
    // LAMBDA EXPRESSIONS WITH EVENTS (Modern C#)
    // ========================================================================
    
    class ModernEventExample
    {
        public static void Demo()
        {
            Button button = new Button();
            
            // Old way: create separate method
            // button.Clicked += Button_Clicked;
            
            // Modern way: use lambda expression
            button.Clicked += (sender, e) => Console.WriteLine("Button clicked (Lambda)!");
            
            // Can capture variables
            int clickCount = 0;
            button.Clicked += (sender, e) =>
            {
                clickCount++;
                Console.WriteLine($"Button clicked {clickCount} times");
            };
            
            button.Click();
            button.Click();
        }
    }
}

// ============================================================================
// EVENT-BASED PROGRAMMING SUMMARY FOR EXAM:
// ============================================================================
//
// 1. DELEGATES
//    - Type-safe function pointers
//    - Define: delegate void MyDelegate(string message);
//    - Built-in: Action (no return), Func (has return), Predicate (returns bool)
//
// 2. EVENTS
//    - Based on delegates
//    - Publisher-Subscriber pattern
//    - Define: public event EventHandler MyEvent;
//    - Subscribe: object.MyEvent += MethodName;
//    - Unsubscribe: object.MyEvent -= MethodName;
//    - Raise: MyEvent?.Invoke(this, EventArgs.Empty);
//
// 3. EVENT HANDLER SIGNATURE
//    - void MethodName(object sender, EventArgs e)
//    - sender: object that raised the event
//    - e: event data (EventArgs or custom)
//
// 4. CUSTOM EVENT ARGS
//    - Inherit from EventArgs
//    - Add properties for custom data
//    - Pass data from publisher to subscribers
//
// 5. BEST PRACTICES
//    - Use 'event' keyword (not just delegate)
//    - Check for null before invoking: MyEvent?.Invoke(...)
//    - Use protected virtual On... methods to raise events
//    - Name events with verbs (Clicked, Changed, Completed)
//    - Name event handlers with EventName_EventHandler pattern
//
// 6. MULTICAST DELEGATES
//    - Can reference multiple methods
//    - Use += to add methods
//    - Use -= to remove methods
//    - All methods called in order when invoked
//
// 7. LAMBDA EXPRESSIONS WITH EVENTS
//    - Inline event handlers
//    - Syntax: (sender, e) => { code }
//    - Can capture local variables (closure)
//
// ============================================================================
// KEY DIFFERENCES:
// ============================================================================
// DELEGATE vs EVENT:
//    - Delegate: can be invoked from anywhere
//    - Event: can only be invoked from within class (encapsulation)
//    - Always use 'event' keyword for publisher-subscriber pattern
//
// EventHandler vs EventHandler<T>:
//    - EventHandler: uses EventArgs
//    - EventHandler<T>: uses custom EventArgs class
//
// ============================================================================
// COMMON EXAM QUESTIONS:
// ============================================================================
// Q: What is the difference between delegate and event?
// A: Event is a wrapper around delegate that adds encapsulation
//
// Q: How to pass custom data with events?
// A: Create class inheriting EventArgs, use EventHandler<CustomEventArgs>
//
// Q: What is multicast delegate?
// A: Delegate that can reference multiple methods, called using +=
//
// Q: What is lambda expression?
// A: Anonymous function: (parameters) => expression or statement
//
// Q: Why check for null before invoking event?
// A: Event might have no subscribers (null), which would cause exception
//    Use: MyEvent?.Invoke(...) or if (MyEvent != null) MyEvent(...)
