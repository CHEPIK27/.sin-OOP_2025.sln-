using System;

class Program
{
    // Завдання 1: Перевірка парності числа
    static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // Завдання 2: Перевантаження функції (Overloading)
    static int Sum(int a, int b)
    {
        return a + b;
    }

    static int Sum(int a, int b, int c)
    {
        return a + b + c;
    }

    static double Sum(double a, double b)
    {
        return a + b;
    }

    // Завдання 3: Функція з ref
    static void Swap(ref int a, ref int b)
    {
        int temp = a;
        a = b;
        b = temp;
    }

    static void Main()
    {
        // Перевірка IsEven
        Console.WriteLine(IsEven(8)); 
        Console.WriteLine(IsEven(7)); 

        // Перевірка Sum
        Console.WriteLine(Sum(5, 10)); 
        Console.WriteLine(Sum(2, 3, 4)); 
        Console.WriteLine(Sum(2.5, 3.1)); 

        // Перевірка Swap
        int a = 5, b = 10;
        Swap(ref a, ref b);
        Console.WriteLine($"a = {a}, b = {b}"); // Очікуваний результат: a = 10, b = 5
    }
}