using System;

class Program
{
    static void Main()
    {
        // Завдання №1: Виведення парних чисел (for)
        Console.WriteLine("Парні числа від 2 до 20:");
        for (int i = 2; i <= 20; i += 2)
        {
            Console.Write(i + " ");
        }
        Console.WriteLine("\n");

        // Завдання №2: Підрахунок суми (while)
        int sum = 0, num;
        Console.WriteLine("Введіть числа для підрахунку суми (0 - завершити):");
        while (true)
        {
            Console.Write("Введіть число: ");
            num = Convert.ToInt32(Console.ReadLine());
            if (num == 0) break;
            sum += num;
        }
        Console.WriteLine("Сума: " + sum);
        Console.WriteLine("\n");

        // Завдання №3: Введення пароля (do-while)
        string correctPassword = "0211";
        string inputPassword;
        do
        {
            Console.Write("Введіть пароль: ");
            inputPassword = Console.ReadLine();
            if (inputPassword != correctPassword)
            {
                Console.WriteLine("Неправильний пароль!");
            }
        } while (inputPassword != correctPassword);

        Console.WriteLine("Доступ дозволено!");
    }
}
