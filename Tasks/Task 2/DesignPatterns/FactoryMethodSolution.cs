using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethodSolution
{
    internal class FactoryMethodSolutionDemo: IDemo
    {

       public void Execute()
        {
            CreatorFactoryMethod truckCreator = new TruckCreator();
            ITransport truck = truckCreator.FactoryMethod();
            truck.Deliver();

            CreatorFactoryMethod shipCreator = new ShipCreator();
            ITransport ship = shipCreator.FactoryMethod();
            ship.Deliver();

            CreatorFactoryMethod airplaneCreator = new AirplaneCreator();
            ITransport airplane = airplaneCreator.FactoryMethod();
            airplane.Deliver();

         
        }
        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }


    interface ITransport
    {
        public void Deliver();
    }

    internal abstract class CreatorFactoryMethod
    {
        internal abstract ITransport FactoryMethod(); 
    }

    internal class TruckCreator: CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new Truck();
        }
    }

    internal class ShipCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new Ship();
        }
    }
    internal class AirplaneCreator : CreatorFactoryMethod
    {
        internal override ITransport FactoryMethod()
        {
            return new Airplane();
        }
    }

    internal class Truck: ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Truck deliver");
        }
    }

    internal class Ship : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Ship deliver");
        }
    }

    internal class Airplane : ITransport
    {
        public void Deliver()
        {
            Console.WriteLine("Airplane deliver");
        }
    }




}
