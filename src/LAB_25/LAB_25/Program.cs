using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Завдання №1:
        var calculator = new Calculator(new AddStrategy());
        Console.WriteLine("Add: " + calculator.Calculate(3, 5));
        calculator.SetStrategy(new SubtractStrategy());
        Console.WriteLine("Subtract: " + calculator.Calculate(10, 4));
        calculator.SetStrategy(new MultiplyStrategy());
        Console.WriteLine("Multiply: " + calculator.Calculate(2, 6));

        Console.WriteLine();

        // Завдання №2:
        var editor = new Editor();
        editor.Submit(new OpenFileCommand());
        editor.Submit(new SaveFileCommand());
        editor.Submit(new CloseFileCommand());

        Console.WriteLine();

        // Завдання №3:
        var chat = new ChatRoom();
        var user1 = new User("Андрій", chat);
        var user2 = new User("Марія", chat);
        var user3 = new User("Микита", chat);
        chat.Register(user1);
        chat.Register(user2);
        chat.Register(user3);
        user1.Send("Привіт усім!");

        Console.WriteLine();

        // Завдання %4:
        var station = new WeatherStation();
        var phone = new PhoneApp("UA001");
        var billboard = new Billboard();
        station.Subscribe(phone);
        station.Subscribe(billboard);
        station.Notify("Зміна погоди: +22°C, без опадів.");
    }
}

// Завдання №1:
public interface ICalculationStrategy
{
    int Calculate(int a, int b);
}

public class AddStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a + b;
}

public class SubtractStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a - b;
}

public class MultiplyStrategy : ICalculationStrategy
{
    public int Calculate(int a, int b) => a * b;
}

public class Calculator
{
    private ICalculationStrategy _strategy;

    public Calculator(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(ICalculationStrategy strategy)
    {
        _strategy = strategy;
    }

    public int Calculate(int a, int b)
    {
        return _strategy.Calculate(a, b);
    }
}

// Завдання №2:
public interface ICommand
{
    void Execute();
}

public class OpenFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл відкрито.");
}

public class SaveFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл збережено.");
}

public class CloseFileCommand : ICommand
{
    public void Execute() => Console.WriteLine("Файл закрито.");
}

public class Editor
{
    public void Submit(ICommand command)
    {
        command.Execute();
    }
}

// Завдання №3:
public interface IChatMediator
{
    void Send(string message, User user);
}

public class ChatRoom : IChatMediator
{
    private List<User> _users = new();

    public void Register(User user)
    {
        _users.Add(user);
    }

    public void Send(string message, User sender)
    {
        foreach (var user in _users)
        {
            if (user != sender)
            {
                user.Receive(message);
            }
        }
    }
}

public class User
{
    public string Name { get; }
    private IChatMediator _mediator;

    public User(string name, IChatMediator mediator)
    {
        Name = name;
        _mediator = mediator;
    }

    public void Send(string msg)
    {
        _mediator.Send(msg, this);
    }

    public void Receive(string msg)
    {
        Console.WriteLine($"{Name} отримав: {msg}");
    }
}

// Завдання №4:
public interface IObserver
{
    void Update(string message);
}

public class PhoneApp : IObserver
{
    private string _id;
    public PhoneApp(string id) => _id = id;

    public void Update(string message)
    {
        Console.WriteLine($"App {_id}: {message}");
    }
}

public class Billboard : IObserver
{
    public void Update(string message)
    {
        Console.WriteLine($"Billboard показує: {message}");
    }
}

public class WeatherStation
{
    private List<IObserver> _observers = new();

    public void Subscribe(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void Notify(string message)
    {
        foreach (var observer in _observers)
        {
            observer.Update(message);
        }
    }
}