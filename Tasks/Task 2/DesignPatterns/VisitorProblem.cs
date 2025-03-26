using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.VisitorProblem
{
    internal class VisitorProblemDemo: IDemo
    {
        public void Execute()
        {
            Car car = new Car();
            Ship ship = new Ship();
            Plane plane = new Plane();
            House house = new House();
            Window houseWindow = new Window();  
            car.Drive();
            ship.Sail();
            plane.Fly();
            house.Rent();
            houseWindow.Open(); 
        }
        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }


    public class Car()
    {
        public void Drive()
        {
            Console.WriteLine("The Car is driving");    
        }
    }


    public class Ship 
    {
        public void Sail() 
        {
            Console.WriteLine("The Ship is sailing");
        }
    } 

    public class Plane
    {
        public void Fly()
        {
            Console.WriteLine("The Plane is flying");
        }
    }


    public class House
    {
        public void Rent()
        {
            Console.WriteLine("The House is rented");
        }
    }

    public class Window
    {
        public void Open()
        {
            Console.WriteLine("The Window is opened");
        }
    }


}
