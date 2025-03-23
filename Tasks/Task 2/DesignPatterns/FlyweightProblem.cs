using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FlyweightProblem
{
    internal class FlyweightProblemDemo: IDemo
    {
        public void Execute()
        {
         
  
            List<(int, Car)> carsManufacturedByDate = new List<(int, Car)>();

            long memoryStart = Process.GetCurrentProcess().WorkingSet64;
            for (int i = 1; i < 1000000; i++)
            {
                carsManufacturedByDate.Add((i, new Car("Lada Vesta", new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))));
            }
            
 
            long memoryEnd = Process.GetCurrentProcess().WorkingSet64;   
            long memoryUsed = memoryEnd - memoryStart;
            Console.WriteLine($"Count of cars in list: {carsManufacturedByDate.Count}");
            Console.WriteLine($"Memory used: {memoryUsed} bytes");
        }
        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }


    internal class Car: ICar 
    {
        public string Brand { get; set; }
        public DateOnly ManufactureDate { get; set; }
    
        public Car(string brand, DateOnly dateManufacture)
        {
            Brand = brand;
            ManufactureDate = dateManufacture;
        }

        public void Display()
        {
            Console.WriteLine($"Car: {Brand} manufactured: {ManufactureDate}");
        }
    }

    public interface ICar
    {
        public void Display();
    }



}
