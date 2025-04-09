using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    // Виконання завдань
    static void Main()
    {
        RunParallelInvokeTask();
        RunRaceConditionTests();
    }

    // Завдання 1: Parallel.Invoke
   

    static void PrintNumbers()
    {
        for (int i = 1; i <= 500; i++)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine();
    }

    static long CalculateFactorial(int n)
    {
        long result = 1;
        for (int i = 2; i <= n; i++)
        {
            result *= i;
        }
        Console.WriteLine($"\nФакторіал {n} = {result}");
        return result;
    }

    static void RunParallelInvokeTask()
    {
        Console.WriteLine("--- Завдання 1: Parallel.Invoke ---\n");

        Stopwatch stopwatch = Stopwatch.StartNew();

        Parallel.Invoke(
            () => PrintNumbers(),
            () => CalculateFactorial(10)
        );

        stopwatch.Stop();
        Console.WriteLine($"\n⏳ Час виконання: {stopwatch.ElapsedMilliseconds} мс\n");
    }

    // Завдання 2: Потокобезпека і гонка потоків
    
    static void TestRaceCondition()
    {
        int counter = 0;
        Parallel.For(0, 1000, i =>
        {
            counter++; 
        });
        Console.WriteLine($"❌ Неправильний результат (без захисту): {counter}");
    }

    
    static void TestWithLock()
    {
        int counter = 0;
        object locker = new object();
        Parallel.For(0, 1000, i =>
        {
            lock (locker)
            {
                counter++;
            }
        });
        Console.WriteLine($"✅ Правильний результат (з lock): {counter}");
    }

    static void TestWithInterlocked()
    {
        int counter = 0;
        Parallel.For(0, 1000, i =>
        {
            Interlocked.Increment(ref counter);
        });
        Console.WriteLine($"✅ Правильний результат (з Interlocked): {counter}");
    }

    static void RunRaceConditionTests()
    {
        Console.WriteLine("--- Завдання 2: Race Condition ---\n");
        TestRaceCondition();
        TestWithLock();
        TestWithInterlocked();
    }
}