using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.AbtractFactoryProblem
{
    internal class AbstractFactoryProblemDemo : IDemo
    {
        public void Execute()
        {
            CreatorFactoryMethod mazTruckCreator = new MazTruckCreator();
            ITransport truckMaz = mazTruckCreator.FactoryMethod();
            truckMaz.Deliver();

            CreatorFactoryMethod mazShipCreator = new MazShipCreator();
            ITransport shipMaz = mazShipCreator.FactoryMethod();
            shipMaz.Deliver();

            CreatorFactoryMethod mazAirplaneCreator = new MazAirplaneCreator();
            ITransport airplaneMaz = mazAirplaneCreator.FactoryMethod();
            airplaneMaz.Deliver();


            CreatorFactoryMethod belazTruckCreator = new BelazTruckCreator();
            ITransport truckBelaz = belazTruckCreator.FactoryMethod();
            truckBelaz.Deliver();

            CreatorFactoryMethod belazShipCreator = new BelazShipCreator();
            ITransport shipBelaz = belazShipCreator.FactoryMethod();
            shipBelaz.Deliver();

            CreatorFactoryMethod belazAirplaneCreator = new BelazAirplaneCreator();
            ITransport airplaneBelaz = belazAirplaneCreator.FactoryMethod();
            airplaneBelaz.Deliver();

        }

        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    interface ITransport
    {
        void Deliver();
    }

    internal abstract class CreatorFactoryMethod
    {
        internal abstract ITransport FactoryMethod();
    }

    internal class MazTruckCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new MazTruck();
        }
    }

    internal class MazShipCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new MazShip();
        }
    }
    internal class MazAirplaneCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new MazAirplane();
        }
    }

    internal class BelazTruckCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new BelazTruck();
        }
    }

    internal class BelazShipCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new BelazShip();
        }
    }
    internal class BelazAirplaneCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new BelazAirplane();
        }
    }


    internal class MazTruck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("MazTruck deliver");
        }
    }

    internal class MazShip : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("MazShip deliver");
        }
    }

    internal class MazAirplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("MazAirplane deliver");
        }
    }

    internal class BelazTruck : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("BelazTruck deliver");
        }
    }

    internal class BelazShip : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("BelazShip deliver");
        }
    }

    internal class BelazAirplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("BelazAirplane deliver");
        }
    }
}