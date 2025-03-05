using System;
using System.Linq;

// Завдання 1: Фільтрація чисел, що діляться на 3 або 5
int[] numbers = { 12, 15, 7, 20, 33, 50, 8, 11, 90, 45 };
var filteredNumbers = numbers.Where(n => n % 3 == 0 || n % 5 == 0).ToList();
int sum = filteredNumbers.Sum();

Console.WriteLine("Числа, що діляться на 3 або 5: " + string.Join(", ", filteredNumbers));
Console.WriteLine("Сума цих чисел: " + sum);

// Завдання 2: Аналіз цін товарів у магазині
        string[] productNames = { "Хліб", "Молоко", "Яблука", "Сир", "Шоколад", "Кава", "Чай" };
double[] productPrices = { 25.5, 32.0, 45.3, 120.0, 80.0, 150.0, 75.5 };
double averagePrice = productPrices.Average();
Console.WriteLine("Середня ціна товарів: " + averagePrice);
var expensiveProducts = productNames.Zip(productPrices, (name, price) => new { name, price })
                                    .Where(p => p.price > averagePrice)
                                    .ToList();

Console.WriteLine("Товари дорожчі за середню ціну:");
expensiveProducts.ForEach(p => Console.WriteLine(p.name + " - " + p.price));

var cheapestProduct = productNames.Zip(productPrices, (name, price) => new { name, price })
                                  .OrderBy(p => p.price)
                                  .First();

var mostExpensiveProduct = productNames.Zip(productPrices, (name, price) => new { name, price })
                                       .OrderByDescending(p => p.price)
                                       .First();

Console.WriteLine("Найдешевший товар: " + cheapestProduct.name + " - " + cheapestProduct.price);
Console.WriteLine("Найдорожчий товар: " + mostExpensiveProduct.name + " - " + mostExpensiveProduct.price);
