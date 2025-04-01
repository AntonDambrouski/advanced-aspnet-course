using static DesignPatterns.ProxyProblem.Delivery;
namespace DesignPatterns;

public class ProxyProblem
{
    public class Delivery
    {
        public IDictionary<int, string> GetStatuses()
        {
            Dictionary<int, string> status = new Dictionary<int, string>();
            status.Add(1, "Delivered");
            status.Add(2, "Not delivered");
            status.Add(3, "In progress");
            Thread.Sleep(1000); // Simulation of status output with delay
            return status;
        }

        public class Package
        {
            public string Name { get; set; }

            public int StatusId { get; set; }
        }

        public IEnumerable<Package> GetPackages()
        {
            List<Package> packages = new List<Package>();
            packages.Add(new Package { Name = "Phone", StatusId = RandomizeStatus() });
            packages.Add(new Package { Name = "Headphones", StatusId = RandomizeStatus() });
            packages.Add(new Package { Name = "Loptop", StatusId = RandomizeStatus() });
            return packages;
        }

        private static int RandomizeStatus()
        {
            var rnd = new Random();
            return rnd.Next(1, 4);
        }
    }

    public void Execute()
    {
        Console.WriteLine("\nProxy Problem:");
        Delivery delivery = new Delivery();
        IEnumerable<Package> packages = delivery.GetPackages();
        foreach (Package package in packages)
        {
            int packageId = package.StatusId;
            string status = delivery.GetStatuses()[packageId];
            Console.WriteLine($"Package name: {package.Name}, package status: {status}");
        }
    }
}
