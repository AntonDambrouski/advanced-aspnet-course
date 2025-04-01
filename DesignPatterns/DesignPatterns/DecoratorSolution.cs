namespace DesignPatterns;

internal class DecoratorSolution
{
    public interface IIcecream
    {
        string GetName();

        double GetCost();
    }

    public class Icecream : IIcecream
    {

        public virtual string GetName()
        {
            return "Icecream ";
        }

        public virtual double GetCost()
        {
            return 2;
        }
    }

    public class IcecreamDecorator : IIcecream
    {
        private readonly Icecream _icecream;

        private double _extraCost;

        public IcecreamDecorator()
        {
            _icecream = new Icecream();
            _extraCost = 1;
        }

        public string GetName()
        {
            return _icecream.GetName() + "Additives";
        }

        public double GetCost()
        {
            return _icecream.GetCost() + _extraCost;
        }
    }

    public class IcecreamWithNuts : Icecream
    {
        public override string GetName()
        {
            return base.GetName() + "with nuts";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1;
        }
    }

    public class IcecreamWithNutsAndChocolate : IcecreamWithNuts
    {
        public override string GetName()
        {
            return base.GetName() + " with chocolate";
        }

        public override double GetCost()
        {
            return base.GetCost() + 1;
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nDecorator Solution:");
        Icecream icecream = new IcecreamWithNutsAndChocolate();
        Console.WriteLine($"Icecream  name: {icecream.GetName()}, icecream cost: {icecream.GetCost()}");
    }
}

