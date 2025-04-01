namespace SolidPrinciples;

public class OpenClosedSolution
{
    public class Worker
    {
        public string Name { get; set; }

        public Worker(string name)
        {
            this.Name = name;
        }

        public void MakeDetail(IDetail detail)
        {
            detail.Make();
        }
    }
    public interface IDetail
    {
        void Make();
    }

    class BoltDetail : IDetail
    {
        public void Make()
        {
            Console.WriteLine("Make a bolt on the machine");
        }
    }

    class ScrewDetail : IDetail
    {
        public void Make()
        {
            Console.WriteLine("Make a screw on the machine");
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nOpen/Closed solution:");
        Worker worker = new Worker("Jack");
        worker.MakeDetail(new BoltDetail());
        worker.MakeDetail(new ScrewDetail());   
    }
}
