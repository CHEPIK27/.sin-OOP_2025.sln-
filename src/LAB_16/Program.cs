using System;
using System.Threading;
using System.Threading.Tasks;

class BankAccount
{
    private int _balance = 0;
    private readonly SemaphoreSlim _semaphore = new SemaphoreSlim(1, 1);

    public async Task DepositAsync(int amount)
    {
        await _semaphore.WaitAsync();
        try
        {
            await Task.Delay(500); 
            _balance += amount;
            Console.WriteLine($"Поповнення +{amount}");
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public async Task WithdrawAsync(int amount)
    {
        await _semaphore.WaitAsync();
        try
        {
            await Task.Delay(500); // імітація затримки
            if (_balance >= amount)
            {
                _balance -= amount;
                Console.WriteLine($"Зняття -{amount}");
            }
            else
            {
                Console.WriteLine($"Недостатньо коштів для зняття -{amount}");
            }
        }
        finally
        {
            _semaphore.Release();
        }
    }

    public int GetBalance() => _balance;
}

class Program
{
    static async Task Main()
    {
        var account = new BankAccount();

        Task t1 = account.DepositAsync(200);
        Task t2 = account.WithdrawAsync(100);
        Task t3 = account.DepositAsync(300);
        Task t4 = account.WithdrawAsync(50);

        await Task.WhenAll(t1, t2, t3, t4);

        Console.WriteLine($"Фінальний баланс: {account.GetBalance()}");
    }
}
