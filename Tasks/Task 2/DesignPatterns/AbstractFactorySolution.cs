using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbtractFactorySolution
{
    internal class AbstractFactorySolutionDemo: IDemo
    {
        public void Execute()
        {
            ITransportFactory mazFactory = new MazFactory();
            mazFactory.CreateShip().Deliver();
            mazFactory.CreateAirplane().Deliver();
            mazFactory.CreateTruck().Deliver();

            ITransportFactory belazFactory = new BelazFactory();
            belazFactory.CreateShip().Deliver();
            belazFactory.CreateAirplane().Deliver();
            belazFactory.CreateTruck().Deliver();
        }

        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }


    public interface ITruck
    {
        void Deliver();

    }
    public interface IShip
    {
        void Deliver();
    }

    public interface IAirplane
    {
        void Deliver();
    }


    public class MazTruck: ITruck
    {
        public void Deliver()
        {
            Console.WriteLine("MazTruck deliver");
        }
    }


    public class MazShip : IShip
    {
        public void Deliver()
        {
            Console.WriteLine("MazShip deliver");
        }
    }

    public class MazAirplane : IAirplane
    {
        public void Deliver()
        {
            Console.WriteLine("MazAirplane deliver");
        }
    }


    public class BelazTruck : ITruck
    {
        public void Deliver()
        {
            Console.WriteLine("BelazTruck deliver");
        }
    }


    public class BelazShip : IShip
    {
        public void Deliver()
        {
            Console.WriteLine("BelazShip deliver");
        }
    }

    public class BelazAirplane : IAirplane
    {
        public void Deliver()
        {
            Console.WriteLine("BelazAirplane deliver");
        }
    }

    public interface ITransportFactory
    {
        public ITruck CreateTruck();
        public IShip CreateShip();
        public IAirplane CreateAirplane();
    }


    public class MazFactory : ITransportFactory
    {
        public ITruck CreateTruck()
        {
            return new MazTruck();
        }
        public IShip CreateShip()
        {
            return new MazShip();
        }
        public IAirplane CreateAirplane()
        {
            return new MazAirplane();
        }
    }

    public class BelazFactory : ITransportFactory
    {
        public ITruck CreateTruck()
        {
            return new BelazTruck();
        }
        public IShip CreateShip()
        {
            return new BelazShip();
        }
        public IAirplane CreateAirplane()
        {
            return new BelazAirplane();
        }
    }
}
