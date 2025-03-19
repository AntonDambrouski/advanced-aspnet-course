namespace Basic_Programming_Principles.DesignPatterns
{
    public interface ICoffee
    {
        string GetDescription();
        double GetCost();
    }

    // Base class for coffee
    public class Coffee : ICoffee
    {
        public virtual string GetDescription()
        {
            return "Basic Coffee";
        }

        public virtual double GetCost()
        {
            return 5.0; // Base price for coffee
        }
    }

    public class CoffeeDecorator : ICoffee
    {
        private readonly ICoffee _coffee;
        private double _extraCost;
        public CoffeeDecorator()
        {
            _coffee = new Coffee();
            _extraCost = 0.5;
        }

        public double GetCost()
        {
            return _coffee.GetCost() + _extraCost;
        }

        public string GetDescription()
        {
            return _coffee.GetDescription() + " + Extra";
        }
    }

    // Coffee with Milk (Extended class)
    public class CoffeeWithMilk : Coffee
    {
        public override string GetDescription()
        {
            return base.GetDescription() + " + Milk";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1.5; // Adding milk costs extra
        }
    }

    // Coffee with Milk and Sugar (Another extended class)
    public class CoffeeWithMilkAndSugar : CoffeeWithMilk
    {
        public override string GetDescription()
        {
            return base.GetDescription() + " + Sugar";
        }

        public override double GetCost()
        {
            return base.GetCost() + 0.5; // Adding sugar costs extra
        }
    }

    static class DecoratorDemo
    {
        public static void Execute()
        {
            Coffee coffee = new CoffeeWithMilkAndSugar();
            Console.WriteLine($"{coffee.GetDescription()} - Cost: ${coffee.GetCost()}");
        }
    }

}
