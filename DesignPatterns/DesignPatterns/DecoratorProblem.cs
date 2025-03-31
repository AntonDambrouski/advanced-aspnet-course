namespace DesignPatterns;

public class DecoratorProblem
{

    public class Icecream
    {

        public string GetName()
        {
            return "Icecream without additives";
        }

        public double GetCost()
        {
            return 2;
        }
    }

    public class IcecreamWithNuts : Icecream
    {
        public string GetName()
        {
            return "Ececream with nuts";
        }

        public double GetCost()
        {
            return 3;
        }
    }

    public class IcecreamWithNutsAndChocolate : IcecreamWithNuts
    {
        public string GetName()
        {
            return "Icecream with nuts and chocolate";
        }

        public double GetCost()
        {
            return 4;
        }

    }

    public void Execute()
    {
        Console.WriteLine("\nDecorator problem:");
        Icecream icecream1 = new Icecream();
        Console.WriteLine($"Icecream name: {icecream1.GetName()}, icecream cost: {icecream1.GetCost()}" );
        IcecreamWithNuts icecream2 = new IcecreamWithNuts();
        Console.WriteLine($"Icecream name: {icecream2.GetName()}, icecream cost: {icecream2.GetCost()}");
        IcecreamWithNutsAndChocolate icecream3 = new IcecreamWithNutsAndChocolate();
        Console.WriteLine($"Icecream name: {icecream3.GetName()}, icecream cost: {icecream3.GetCost()}");
    }
}
