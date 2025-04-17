using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Завдання №1:
        List<IAnimal> animals = new List<IAnimal>
        {
            new Dog(),
            new Cat()
        };

        foreach (var animal in animals)
        {
            animal.Speak();
            animal.Eat();
            Console.WriteLine();
        }

        // Завдання №2:
        Order order1 = new Order(new CreditCard());
        order1.ProcessPayment(500);

        Order order2 = new Order(new PayPal());
        order2.ProcessPayment(250);

        Order order3 = new Order(new ApplePay());
        order3.ProcessPayment(300);

        Order order4 = new Order(new GooglePay());
        order4.ProcessPayment(270);
    }
}

// Завдання №1:
public interface IAnimal
{
    void Speak();
    void Eat();
}

public class Dog : IAnimal
{
    public void Speak() => Console.WriteLine("Гав-гав!");
    public void Eat() => Console.WriteLine("Собака їсть кістку.");
}

public class Cat : IAnimal
{
    public void Speak() => Console.WriteLine("Мяу!");
    public void Eat() => Console.WriteLine("Кішка їсть рибу.");
}

// Завдання №2:
public interface IPaymentMethod
{
    void Pay(decimal amount);
}

public class CreditCard : IPaymentMethod
{
    public void Pay(decimal amount) =>
        Console.WriteLine($"Оплата кредитною карткою: {amount} грн");
}

public class PayPal : IPaymentMethod
{
    public void Pay(decimal amount) =>
        Console.WriteLine($"Оплата через PayPal: {amount} грн");
}

public class ApplePay : IPaymentMethod
{
    public void Pay(decimal amount) =>
        Console.WriteLine($"Оплата через ApplePay: {amount} грн");
}

public class GooglePay : IPaymentMethod
{
    public void Pay(decimal amount) =>
        Console.WriteLine($"Оплата через GooglePay: {amount} грн");
}

public class Order
{
    public IPaymentMethod PaymentMethod { get; set; }

    public Order(IPaymentMethod paymentMethod)
    {
        PaymentMethod = paymentMethod;
    }

    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Обробка платежу...");
        PaymentMethod.Pay(amount);
        Console.WriteLine("Платіж завершено.\n");
    }
}