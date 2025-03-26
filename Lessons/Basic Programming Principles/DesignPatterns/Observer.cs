namespace Basic_Programming_Principles.DesignPatterns;

public interface IInvestor
{
    void Update(double price);
}

public class Investor : IInvestor
{
    private readonly string _name;

    public Investor(string name)
    {
        _name = name;
    }

    public void Update(double price)
    {
        Console.WriteLine($"{_name}: Price update! Current Price: {price}");
    }
}

public class Stock
{
    private readonly List<IInvestor> _investors = new List<IInvestor>();

    public void Attach(IInvestor investor)
    {
        _investors.Add(investor);
    }

    public void Detach(IInvestor investor)
    {
        _investors.Remove(investor);
    }

    public double Price { get; private set; }

    public void SetPrice(double price)
    {
        Price = price;
        Notify();
    }

    public void Notify()
    {
        foreach (var investor in _investors)
        {
            investor.Update(Price);
        }
    }
}

class ObserverDemo
{
    public static void Execute()
    {
        var investor1 = new Investor("Bob");
        var investor2 = new Investor("Alice");
        Stock stock = new Stock();
        stock.Attach(investor1);
        stock.Attach(investor2);

        stock.SetPrice(100);
        stock.SetPrice(105);
    }
}
