﻿// See https://aka.ms/new-console-template for more information
using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Creational.Factory;
using DesignPatterns.Structural.Decorator.MultipleDecorators;
using DesignPatterns.Structural.Decorator.TheFirstExample;
using static DesignPatterns.Behavioral.Strategy.Strategy;

Console.WriteLine("Hello, World!");

Console.WriteLine("Choose a design pattern to demonstrate:");
Console.WriteLine("1. Factory Pattern");
Console.WriteLine("Press '1' to demonstrate the Factory Pattern...");
Console.WriteLine("Press '2' to demonstrate Strategy Pattern ...");
Console.WriteLine("Press '3' to demonstrate the Decorator Pattern...");
ConsoleKeyInfo keyInfo = Console.ReadKey();
Console.WriteLine(); // Move to the next line after key press

switch(keyInfo.KeyChar)
{
    case '1':
        Console.WriteLine("You chose Factory Pattern.");
        FactoryExample();
        break;
    case '2':
        Console.WriteLine("You chose Strategy Pattern.");
        StrategyExample();
        break;
    case '3':
        Console.WriteLine("You chose Decorator Pattern.");
        // Implement Decorator pattern example here
        DecoratorExample();
        Console.WriteLine("Demonstrating multiple decorators...");
        MultipleDecoratorExample();
        break;
    default:
        Console.WriteLine("Invalid choice. Exiting...");
        return;
}


static void FactoryExample()
{
    // Example usage of the Factory pattern
    Console.WriteLine("Creating products using the Factory pattern...");
    Console.WriteLine("--------------------------------------------------");
    Console.WriteLine("Choosing product type to create: ProductA and ProductB");
    var productOption = Console.ReadKey();

    Console.WriteLine(); // Move to the next line after key press

    string type = string.Empty;
    if (productOption.KeyChar == 'A')
    {
        type = "ProductA";
    }
    else if (productOption.KeyChar == 'B')
    {
        type = "ProductB";
    }

    IProduct product = Factory.CreateProduct(type);
    product.Use();
}

static void StrategyExample()
{
    // Example usage of the Strategy pattern
    Console.WriteLine("Creating products using the Strategy pattern...");
    Console.WriteLine("--------------------------------------------------");
    // Implement Strategy pattern example here
    Console.WriteLine("Insert this price");
    var price = Console.ReadLine();

    Console.WriteLine("Choose a discount strategy:");
    Console.WriteLine("1. No Discount");
    Console.WriteLine("2. Employee Discount (55% off)");
    Console.WriteLine("3. VIP Discount (30% off)");
    Console.WriteLine("4. Super Discount (5% off)");
    Console.WriteLine("5. Age Discount (10% off for minors)");
    Console.WriteLine("Press '1', '2', '3', '4', or '5' to choose a discount strategy...");
    ConsoleKeyInfo discountKeyInfo = Console.ReadKey();
    Console.WriteLine(); // Move to the next line after key press
    IDiscountStrategy discountStrategy;
    switch (discountKeyInfo.KeyChar)
    {
        case '1':
            discountStrategy = new NoDiscountStrategy();
            break;
        case '2':
            discountStrategy = new EmployeeDiscountStrategy();
            break;
        case '3':
            discountStrategy = new VipDiscountStrategy();
            break;
        case '4':
            discountStrategy = new SuperDiscountStrategy();
            break;
        case '5':
            Console.WriteLine("Enter your age:");
            int age = int.Parse(Console.ReadLine() ?? "0");
            discountStrategy = new AgeDiscountStrategy(age);
            break;
        default:
            Console.WriteLine("Invalid choice. Using No Discount strategy.");
            discountStrategy = new NoDiscountStrategy();
            break;
    }       

    var discountedAmount = discountStrategy.ApplyDiscount(decimal.Parse(price));

    Console.WriteLine($"Original Price: {price}");
    Console.WriteLine($"Discounted Price: {discountedAmount}");


    
}

static void DecoratorExample()
{
    // Example usage of the Decorator pattern
    Console.WriteLine("Creating products using the Decorator pattern...");
    Console.WriteLine("--------------------------------------------------");
    // Implement Decorator pattern example here
    MyOldComponentThatICantChange myOldComponentThatICantChange = new MyOldComponentThatICantChange();
    Console.WriteLine(myOldComponentThatICantChange.GetDescription());

    MyDecorator myDecorator = new MyDecorator(myOldComponentThatICantChange);
    Console.WriteLine(myDecorator.GetDescription());

    var mySuperDecorator = new MyDecorator(myDecorator);
    Console.WriteLine(mySuperDecorator.GetDescription());
}

static void MultipleDecoratorExample()
{
    LogComponent logComponent = new LogComponent();
    logComponent.LogMessage("This is a simple log message.");
    logComponent.LogWarning("This is a warning message.");
    logComponent.LogError("This is an error message.");
    Console.WriteLine("Using multiple decorators:");

    OutroMultipleDecoratorMethod();
    AnotherMultipleDecoratorMethod();

    Console.WriteLine("Now for the next method we need to Log it including different behaviour");
    DifferentMultipleDecoratorMethod();
    Console.WriteLine("End of multiple decorators example.");
}

static void OutroMultipleDecoratorMethod()
{
    var outroLog = new LogComponent("Outro");
    outroLog.LogMessage("This is a message from the outro log component.");
}


static void AnotherMultipleDecoratorMethod()
{
    Console.WriteLine("Bla bla bla");
    var log = new LogComponent("Another bla bla");
    log.LogWarning("ANOTHER log component.");
}

///This need to use a decorator to log the message differently
static void DifferentMultipleDecoratorMethod()
{
    Console.WriteLine("Bla bla bla");
    var log = new LogComponent("Different");
    //In this case when Warning we need to write notify by email. All the other methods and classes don't need this, just in this case.
    var emailWarningLogger = new EmailNotificationDecorator(log);
    // Here we are using the decorator to log the message with email notification
    emailWarningLogger.LogWarning("ANOTHER log component with email notification.");
    emailWarningLogger.LogError("This is an error message.");
}
