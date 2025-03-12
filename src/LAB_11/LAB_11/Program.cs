using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Виберіть завдання:");
            Console.WriteLine("1. Система обробки заявок");
            Console.WriteLine("2. Аналіз тексту");
            Console.WriteLine("3. Вийти");

            string choice = Console.ReadLine();
            if (choice == "1")
                SupportTicketSystem();
            else if (choice == "2")
                TextAnalysis();
            else if (choice == "3")
                break;
            else
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
        }
    }

    static void SupportTicketSystem()
    {
        Queue<string> tickets = new Queue<string>();
        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати заявку");
            Console.WriteLine("2. Обробити заявку");
            Console.WriteLine("3. Подивитися першу заявку");
            Console.WriteLine("4. Показати всі заявки");
            Console.WriteLine("5. Вийти");

            string option = Console.ReadLine();
            switch (option)
            {
                case "1":
                    Console.Write("Введіть текст заявки: ");
                    string ticket = Console.ReadLine();
                    tickets.Enqueue(ticket);
                    Console.WriteLine("Заявку додано!");
                    break;
                case "2":
                    if (tickets.Count > 0)
                        Console.WriteLine("Заявка \"" + tickets.Dequeue() + "\" оброблена!");
                    else
                        Console.WriteLine("Черга порожня.");
                    break;
                case "3":
                    if (tickets.Count > 0)
                        Console.WriteLine("Перша заявка в черзі: \"" + tickets.Peek() + "\"");
                    else
                        Console.WriteLine("Черга порожня.");
                    break;
                case "4":
                    if (tickets.Count > 0)
                        Console.WriteLine("Усі заявки: " + string.Join(", ", tickets));
                    else
                        Console.WriteLine("Черга порожня.");
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Невірний вибір, спробуйте ще раз.");
                    break;
            }
        }
    }

    static void TextAnalysis()
    {
        Console.WriteLine("Введіть текст для аналізу:");
        string input = Console.ReadLine().ToLower();

        string[] words = Regex.Split(input, "\W+").Where(w => !string.IsNullOrEmpty(w)).ToArray();
        Dictionary<string, int> wordCount = new Dictionary<string, int>();

        foreach (string word in words)
        {
            if (wordCount.ContainsKey(word))
                wordCount[word]++;
            else
                wordCount[word] = 1;
        }

        Console.WriteLine("\nСтатистика частоти слів:");
        foreach (var kvp in wordCount.OrderByDescending(k => k.Value))
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value}");
        }
    }
}