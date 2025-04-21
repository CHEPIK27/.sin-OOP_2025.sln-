
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //Завдання №1:
        Container<int> intBox = new Container<int> { Value = 42 };
        Container<string> strBox = new Container<string> { Value = "Hello" };

        intBox.ShowInfo();
        strBox.ShowInfo();

        Console.WriteLine();

        //Завдання №2:
        int[] intArray = { 1, 5, 3 };
        double[] doubleArray = { 2.5, 3.7, 1.2 };
        string[] stringArray = { "Pen Pineapple Apple Pen", "banana", "kiwi" ,"pomelo"};

        Console.WriteLine($"Максимум (int): {FindMax(intArray)}");
        Console.WriteLine($"Максимум (double): {FindMax(doubleArray)}");
        Console.WriteLine($"Максимум (string): {FindMax(stringArray)}");
    }

   
    public static T FindMax<T>(T[] array) where T : IComparable<T>
    {
        T max = array[0];
        foreach (T item in array)
        {
            if (item.CompareTo(max) > 0)
                max = item;
        }
        return max;
    }
}


public class Container<T>
{
    public T Value { get; set; }

    public void ShowInfo()
    {
        Console.WriteLine($"Значення: {Value}, Тип: {Value.GetType().Name}");
    }
}