using DesignPatterns.FlyweightProblem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.VisitorSolution
{
    internal class VisitorSolutionDemo : IDemo
    {
        public void Execute()
        {
            List<IPatients> patients = new List<IPatients>();
            patients.Add(new Car());
            patients.Add(new Ship());
            patients.Add(new Plane());
            patients.Add(new House());
            patients.Add(new Window());
            Visitor visitor = new Visitor();
            foreach(var patient in patients)
            {
                patient.Accept(visitor);
            }

        }
        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }


    }


    public interface IPatients
    {
        public void Accept(IVisitor visitor);
    }

    public interface IVisitor
    {
        public void Visit(Car car);
        public void Visit(Ship ship);

        public void Visit(Plane plane);

        public void Visit(House house);

        public void Visit(Window window);
    }


    public class Car : IPatients
    {
        public void Drive()
        {
            Console.WriteLine("The Car is driving");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public class Ship : IPatients
    {
        public void Sail()
        {
            Console.WriteLine("The Ship is sailing");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public class Plane : IPatients
    {
        public void Fly()
        {
            Console.WriteLine("The Plane is flying");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }


    public class House : IPatients
    {
        public void Rent()
        {
            Console.WriteLine("The House is rented");
        }

        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

    }

    public class Window : IPatients
    {
        public void Open()
        {
            Console.WriteLine("The Window is opened");
        }
        public void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }




    public class Visitor : IVisitor
    {
        public void Visit(Car car)
        {
            car.Drive();
        }

        public void Visit(Ship ship)
        {
            ship.Sail();
        }
        public void Visit(Plane plane)
        {
            plane.Fly();
        }
        public void Visit(House house)
        {
            house.Rent();
        }
        public void Visit(Window window)
        {
            window.Open();
        }

    }



}
