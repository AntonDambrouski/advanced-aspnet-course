using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.FlyweightSolution
{
    internal class FlyweightSolutionDemo: IDemo
    {
        public void Execute()
        {
            List<(int, ICar)> carsManufacturedByDate = new List<(int, ICar)>();
            long memoryStart = Process.GetCurrentProcess().WorkingSet64;
            var carsFactory = new CarsFactory();
            for (int i = 1; i < 1000000; i++) 
            {
                carsManufacturedByDate.Add((i, carsFactory.GetCar("Lada Vesta", new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day))));
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


    public interface ICar
    {
        void Display();
    }

    public class Car : ICar 
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

    public class CarsFactory
    {
        private readonly Dictionary<(string, DateOnly), ICar> carsManufacturedByDate = new();
        public ICar GetCar(string brand, DateOnly dateManufacture) 
        {
            if(!carsManufacturedByDate.ContainsKey((brand, dateManufacture))) 
            {
                carsManufacturedByDate[(brand, dateManufacture)] = new Car(brand, dateManufacture);
            }
            return carsManufacturedByDate[(brand, dateManufacture)];
        }
    }
}