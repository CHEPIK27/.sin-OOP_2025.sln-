using System;

// Завдання 1: Координати точки
struct Point
{
    public int X { get; set; }
    public int Y { get; set; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceTo(Point other)
    {
        return Math.Sqrt(Math.Pow(other.X - X, 2) + Math.Pow(other.Y - Y, 2));
    }
}

// Завдання 2: Автомобільний парк
class Car
{
    public string Brand { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string Color { get; set; }

    
    public Car(string brand, string model)
    {
        Brand = brand;
        Model = model;
    }

    
    public Car(string brand, string model, int year) : this(brand, model)
    {
        Year = year;
    }

   
    public Car(string brand, string model, int year, string color) : this(brand, model, year)
    {
        Color = color;
    }

    public void ShowInfo()
    {
        Console.WriteLine($"Авто: {Brand} {Model}, Рік: {Year}, Колір: {Color}");
    }
}

class Program
{
    static void Main()
    {
        // Перевірка завдання 1
        Point p1 = new Point(3, 4);
        Point p2 = new Point(0, 0);
        Console.WriteLine(p1.DistanceTo(p2)); // Виведе: 5

        // Перевірка завдання 2
        Car car1 = new Car("Toyota", "Corolla", 2010);
        Car car2 = new Car("Ford", "Focus", 2018);
        Car car3 = new Car("Tesla", "Model S", 2022, "Червоний");

        car1.ShowInfo();
        car2.ShowInfo();
        car3.ShowInfo();
    }
}
