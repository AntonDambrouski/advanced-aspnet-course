using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FactoryMethodProblem
{
      internal class Truck
    {
        public void Deliver()
        {
            Console.WriteLine("Truck deliver");
        }
    }



    internal class Ship
    {
        public void Deliver()
        {
            Console.WriteLine("Ship deliver");
        }

    }


    internal class Airplane
    {
        public void Deliver()
        {
            Console.WriteLine("Airplane deliver");
        }
    }


    internal class FactoryMethodProblemDemo: IDemo
    {
        public void Execute()
        {
            Truck truck = new Truck();
            truck.Deliver();
            Ship ship = new Ship();
            ship.Deliver();
            Airplane airplane = new Airplane();
            airplane.Deliver();

        }

        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }

}
