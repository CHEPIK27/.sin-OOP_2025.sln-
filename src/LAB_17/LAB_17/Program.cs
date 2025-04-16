using System;


class Program
{
    static void Main()
    {
        Console.WriteLine("=== Тестування класу Student ===");
        Student student = new Student();
        student.Name = "Іван";
        student.Age = 21;

        Console.WriteLine($"Ім'я: {student.Name}, Вік: {student.Age}");

       
        student.Age = -5;

        Console.WriteLine();

        Console.WriteLine("=== Тестування класу Car ===");
        Car car = new Car();

        car.Accelerate(60);   
        car.Brake(30);        
        car.Brake(50);        

        Console.WriteLine($"Кінцева швидкість: {car.Speed}");
    }
}

//Завдання 1:
public class Student
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 120)
                age = value;
            else
                Console.WriteLine("Некоректний вік. Вік має бути від 0 до 120.");
        }
    }
}

//Завдання 2: 
public class Car
{
    private int speed;

    public int Speed
    {
        get { return speed; }
    }

    public void Accelerate(int amount)
    {
        if (amount > 0)
        {
            speed += amount;
            Console.WriteLine($"Прискорення на {amount}. Поточна швидкість: {speed}");
        }
    }

    public void Brake(int amount)
    {
        if (amount > 0)
        {
            speed -= amount;
            if (speed < 0)
                speed = 0;

            Console.WriteLine($"Гальмування на {amount}. Поточна швидкість: {speed}");
        }
    }
}
