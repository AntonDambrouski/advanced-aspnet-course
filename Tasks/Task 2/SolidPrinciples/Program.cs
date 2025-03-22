﻿using SolidPrinciples.OCP;

namespace SolidPrinciples
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--------------SRP problem------------");
            SRPProblem animal = new SRPProblem("Vasily", "safari", 10, true);
            animal.MultipleResponsibilityMethod();

            Console.WriteLine("--------------SRP Solution------------");
            SRPSolution newAnimal = new SRPSolution("Vasily", "safari", 10, true);
            newAnimal.ScanAnimal();
            newAnimal.SendAnimalToZoo();
            newAnimal.speciesCounter();

            Console.WriteLine("--------------OCP problem------------");
            OCPProblem person = new OCPProblem("Anton");
            person.Read();

            Console.WriteLine("--------------OCP Solution------------");
            OCPSolution person2 = new OCPSolution("Aston");
            person2.Read(new Journals());
            person2.Read(new Magazines());
            person2.Read(new Books());
            Console.ReadKey();
        }
    }
}
