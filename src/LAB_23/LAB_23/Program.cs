using System;

// Завдання №1:
public class Logger
{
    private static Logger _instance;
    private static readonly object _lock = new();

    private Logger() { }

    public static Logger Instance
    {
        get
        {
            lock (_lock)
            {
                _instance ??= new Logger();
                return _instance;
            }
        }
    }

    public void Log(string message)
    {
        Console.WriteLine($"[{DateTime.Now}] {message}");
    }
}

// Завдання №2:
public interface INotification
{
    void Send(string message);
}

public class EmailNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Email: {message}");
}

public class SMSNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"SMS: {message}");
}

public class PushNotification : INotification
{
    public void Send(string message) => Console.WriteLine($"Push: {message}");
}

public class NotificationFactory
{
    public static INotification Create(string type)
    {
        return type switch
        {
            "email" => new EmailNotification(),
            "sms" => new SMSNotification(),
            "push" => new PushNotification(),
            _ => throw new ArgumentException("Невідомий тип повідомлення")
        };
    }
}

// Завдання №3:
public class Computer
{
    public string CPU { get; set; }
    public string GPU { get; set; }
    public string RAM { get; set; }
    public string SSD { get; set; }

    public void ShowConfig()
    {
        Console.WriteLine($"Комп'ютер: CPU={CPU}, GPU={GPU}, RAM={RAM}, SSD={SSD}");
    }
}

public class ComputerBuilder
{
    private readonly Computer _computer = new();

    public ComputerBuilder SetCPU(string cpu)
    {
        _computer.CPU = cpu;
        return this;
    }

    public ComputerBuilder SetGPU(string gpu)
    {
        _computer.GPU = gpu;
        return this;
    }

    public ComputerBuilder SetRAM(string ram)
    {
        _computer.RAM = ram;
        return this;
    }

    public ComputerBuilder SetSSD(string ssd)
    {
        _computer.SSD = ssd;
        return this;
    }

    public Computer Build() => _computer;
}


class Program
{
    static void Main()
    {
        // Завдання №1:
        var logger1 = Logger.Instance;
        var logger2 = Logger.Instance;
        logger1.Log("Це лог з першого екземпляру.");
        logger2.Log("Це лог з другого екземпляру.");
        Console.WriteLine($"Один екземпляр: {ReferenceEquals(logger1, logger2)}");

        // Завдання №2:
        Console.WriteLine("\n--- Factory Method ---");
        Console.Write("Тип повідомлення (email/sms/push): ");
        string type = Console.ReadLine();
        var notification = NotificationFactory.Create(type);
        notification.Send("Привіт, користувачу!");

        // Завдання №3:
        Console.WriteLine("\n--- Builder ---");
        var gamerPC = new ComputerBuilder()
            .SetCPU("Intel Core i9")
            .SetGPU("NVIDIA RTX 4080")
            .SetRAM("32GB")
            .SetSSD("2TB")
            .Build();

        var officePC = new ComputerBuilder()
            .SetCPU("Intel Core i5")
            .SetRAM("8GB")
            .SetSSD("512GB")
            .Build();

        Console.WriteLine("Геймерський ПК:");
        gamerPC.ShowConfig();
        Console.WriteLine("Офісний ПК:");
        officePC.ShowConfig();
    }
}