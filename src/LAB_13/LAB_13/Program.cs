using System;
using System.Collections.Generic;
//завдання №1


class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Predicate<int> isEven = n => n % 2 == 0;
        var evenNumbers = Filter(numbers, isEven);

        Console.WriteLine("Парні числа:");
        foreach (var num in evenNumbers)
        {
            Console.WriteLine(num);
        }
    }

    static int[] Filter(int[] numbers, Predicate<int> predicate)
    {
        var result = new List<int>();
        foreach (var number in numbers)
        {
            if (predicate(number))
                result.Add(number);
        }
        return result.ToArray();
    }
}


