using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> mortgageRequests = new Queue<string>();
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку");
            Console.WriteLine("2. Обробити першу заявку");
            Console.WriteLine("3. Переглянути першу заявку");
            Console.WriteLine("4. Показати всі заявки");
            Console.WriteLine("5. Розрахувати іпотечний платіж");
            Console.WriteLine("6. Вийти");
            Console.Write("Виберіть дію: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть ім'я заявника: ");
                    string name = Console.ReadLine();
                    mortgageRequests.Enqueue(name);
                    Console.WriteLine($"Заявка від {name} додана в чергу.");
                    break;
                case "2":
                    if (mortgageRequests.Count > 0)
                        Console.WriteLine($"Заявка від {mortgageRequests.Dequeue()} оброблена.");
                    else
                        Console.WriteLine("Черга пуста.");
                    break;
                case "3":
                    if (mortgageRequests.Count > 0)
                        Console.WriteLine($"Перша заявка в черзі: {mortgageRequests.Peek()}");
                    else
                        Console.WriteLine("Черга пуста.");
                    break;
                case "4":
                    if (mortgageRequests.Count > 0)
                        Console.WriteLine("Заявки в черзі: " + string.Join(", ", mortgageRequests));
                    else
                        Console.WriteLine("Черга пуста.");
                    break;
                case "5":
                    CalculateMortgage();
                    break;
                case "6":
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void CalculateMortgage()
    {
        Console.Write("Введіть суму кредиту (P): ");
        decimal P = decimal.Parse(Console.ReadLine());

        Console.Write("Введіть річну відсоткову ставку (%): ");
        decimal annualRate = decimal.Parse(Console.ReadLine());
        decimal r = annualRate / 12 / 100;

        Console.Write("Введіть термін кредиту (роки): ");
        int years = int.Parse(Console.ReadLine());
        int n = years * 12;

        decimal M = P * r * (decimal)Math.Pow((double)(1 + r), n) / (decimal)(Math.Pow((double)(1 + r), n) - 1);
        M = Math.Round(M, 2);

        Console.WriteLine($"Щомісячний платіж: {M} грн");
    }
}
