using DesignPatterns.Creational_patterns.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational_patterns
{
    public class PrototypeSolution : IExecutor
    {
        public void Execute()
        {
            Person p1 = new Person();
            p1.Age = 11;
            p1.Name = "Oliver";
            p1.IdInfo = new IdInfo(666);

            Person p2 = p1.ShallowCopy();
            Person p3 = p1.DeepCopy();

            Console.WriteLine("Original values of p1, p2, p3:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values:");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values:");
            DisplayValues(p3);

            p1.Age = 77;
            p1.Name = "Bob";
            p1.IdInfo.IdNumber = 3434;
            Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
            Console.WriteLine("   p1 instance values: ");
            DisplayValues(p1);
            Console.WriteLine("   p2 instance values (reference values have changed):");
            DisplayValues(p2);
            Console.WriteLine("   p3 instance values (everything was kept the same):");
            DisplayValues(p3);
        }

        public static void DisplayValues(Person p)
        {
            Console.WriteLine($"      Name: {p.Name}, Age: {p.Age}");
            Console.WriteLine($"      ID#: {p.IdInfo.IdNumber}");
        }
    }

}
