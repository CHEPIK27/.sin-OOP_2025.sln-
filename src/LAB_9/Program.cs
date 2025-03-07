using System;

class Program
{
    static int BubbleSortWithCount(int[] arr)
    {
        int n = arr.Length;
        int swapCount = 0;
        bool swapped;

        for (int i = 0; i < n - 1; i++)
        {
            swapped = false;
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]); 
                    swapped = true;
                    swapCount++;
                }
            }
            if (!swapped) break; 
        }
        return swapCount;
    }

    static void Main()
    {
        int[] numbers = { 8, 5, 2, 9, 1, 5, 6 };
        int swapCount = BubbleSortWithCount(numbers);

        Console.WriteLine($"Кількість перестановок: {swapCount}");
        Console.WriteLine("Після сортування: [" + string.Join(", ", numbers) + "]");
    }
}