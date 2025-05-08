using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("=== Adapter Pattern ===");
        INewPrinter printer = new PrinterAdapter(new OldPrinter());
        printer.Print("Hello from adapter!");

        Console.WriteLine("\n=== Facade Pattern ===");
        CarFacade car = new CarFacade();
        car.StartCar();

        Console.WriteLine("\n=== Decorator Pattern ===");
        IWriter writer = new TimestampWriter(new ConsoleWriter());
        writer.Write("Привіт, світ!");
    }
}

// Завдання №1:

public interface INewPrinter
{
    void Print(string message);
}

public class OldPrinter
{
    public void OldPrint()
    {
        Console.WriteLine("Старий принтер друкує повідомлення.");
    }
}

public class PrinterAdapter : INewPrinter
{
    private readonly OldPrinter _oldPrinter;

    public PrinterAdapter(OldPrinter oldPrinter)
    {
        _oldPrinter = oldPrinter;
    }

    public void Print(string message)
    {
        Console.WriteLine($"Адаптер отримав повідомлення: {message}");
        _oldPrinter.OldPrint();
    }
}

// Завдання №2:

public class Engine
{
    public void Start() => Console.WriteLine("Двигун запущено.");
}

public class Battery
{
    public void Start() => Console.WriteLine("Батарея активована.");
}

public class IgnitionSystem
{
    public void Start() => Console.WriteLine("Система запалювання активована.");
}

public class CarFacade
{
    private readonly Engine _engine = new();
    private readonly Battery _battery = new();
    private readonly IgnitionSystem _ignition = new();

    public void StartCar()
    {
        _battery.Start();
        _ignition.Start();
        _engine.Start();
    }
}

// Завдання №3:

public interface IWriter
{
    void Write(string text);
}

public class ConsoleWriter : IWriter
{
    public void Write(string text)
    {
        Console.WriteLine(text);
    }
}

public class TimestampWriter : IWriter
{
    private readonly IWriter _inner;

    public TimestampWriter(IWriter inner)
    {
        _inner = inner;
    }

    public void Write(string text)
    {
        string stamped = $"[{DateTime.Now:HH:mm:ss}] {text}";
        _inner.Write(stamped);
    }
}
