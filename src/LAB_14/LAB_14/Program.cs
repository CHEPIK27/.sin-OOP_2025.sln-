using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

class Program
{
    static async Task Main()
    {
        string[] files = { "log1.txt", "log2.txt", "log3.txt" };
        var tasks = files.Select(f => Task.Run(() => ProcessFile(f))).ToArray();
        await Task.WhenAll(tasks);
        Console.WriteLine("Обробка завершена!");
    }

    static void ProcessFile(string file)
    {
        int errors = File.ReadAllLines(file).Count(line => line.Contains("ERROR"));
        Console.WriteLine($"{file}: знайдено {errors} помилок.");
    }
}