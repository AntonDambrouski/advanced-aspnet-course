namespace SolidPrinciples;

public class OpenClosedProblem
{
    public class Worker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            this.Name = name;
        }

        public void MakeDetail()
        {
            Console.WriteLine("Make a bolt on the machine");
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nOpen/Closed problem:");
        Worker worker = new Worker("Jack");
        worker.MakeDetail();
    }
}
