using System;

class Program
{
    static void Main()
    {
        // Завдання 1: Оголошення змінних
        int age = 25;
        double weight = 72.5;
        char grade = 'A';
        bool isStudent = true;
        string name = "Олександр";

        Console.WriteLine($"Вік: {age}\nВага: {weight}\nОцінка: {grade}\nСтудент: {isStudent}\nІм'я: {name}\n");

        // Завдання 2: Перетворення типів
        Console.Write("Введіть число (double): ");
        double inputNumber = Convert.ToDouble(Console.ReadLine());
        int intNumber = (int)inputNumber;
        string strNumber = intNumber.ToString();

        Console.WriteLine($"Double: {inputNumber}");
        Console.WriteLine($"Int: {intNumber}");
        Console.WriteLine($"String: {strNumber}\n");

        // Завдання 3: Консольний ввід/вивід
        Console.Write("Введіть ваше ім'я: ");
        string userName = Console.ReadLine();
        Console.Write("Введіть ваш вік: ");
        int userAge = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Привіт, {userName}! Твій вік: {userAge} років.\n");

        // Завдання 4: Арифметичні операції
        Console.Write("Введіть відстань (км): ");
        double distance = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введіть час (год): ");
        double time = Convert.ToDouble(Console.ReadLine());
        double speed = distance / time;

        Console.WriteLine($"Середня швидкість: {speed} км/год\n");

        // Завдання 5: Робота з рядками
        Console.Write("Введіть речення: ");
        string sentence = Console.ReadLine();

        Console.WriteLine($"Довжина: {sentence.Length} символів");
        Console.WriteLine($"Верхній регістр: {sentence.ToUpper()}");
        Console.WriteLine($"Замінені пробіли: {sentence.Replace(" ", "_")}");
        Console.WriteLine($"Перші 5 символів: {sentence.Substring(0, Math.Min(5, sentence.Length))}");
    }
}
