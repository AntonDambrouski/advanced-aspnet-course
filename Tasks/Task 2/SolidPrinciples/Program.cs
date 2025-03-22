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
            Console.ReadKey();
        }
    }
}
