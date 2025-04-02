using System;

class Order
{
    public event EventHandler<string> OrderStatusChanged;
    private string status;

    public string Status
    {
        get => status;
        set
        {
            if (status != value)
            {
                status = value;
                OnOrderStatusChanged(status);
            }
        }
    }

    protected virtual void OnOrderStatusChanged(string status)
    {
        OrderStatusChanged?.Invoke(this, status);
    }
}

class Program
{
    static void Main()
    {
        Order order = new Order();
        order.OrderStatusChanged += OrderStatusChangedHandler;

        order.Status = "Замовлення отримано";
        order.Status = "Відправлено";
        order.Status = "Доставлено";
    }

    static void OrderStatusChangedHandler(object sender, string status)
    {
        Console.WriteLine($"Статус замовлення змінено на: {status}");
    }
}
