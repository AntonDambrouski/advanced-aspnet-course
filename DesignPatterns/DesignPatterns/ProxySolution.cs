using static DesignPatterns.ProxySolution.Delivery;
namespace DesignPatterns;

public class ProxySolution
{
    public interface IDelivery
    {
        IDictionary<int, string> GetStatuses();
        IEnumerable<Package> GetPackages();
    }

    public class DeliveryProxy : IDelivery
    {
        private readonly Delivery _delivery;

        private IDictionary<int, string> _statuses;

        public DeliveryProxy(Delivery delivery)
        {
            _delivery = delivery;
        }

        public IEnumerable<Package> GetPackages()
        {
            return _delivery.GetPackages();
        }

        public IDictionary<int, string> GetStatuses()
        {
            if (_statuses == null)
            {
                _statuses = _delivery.GetStatuses();
            }
            return _statuses;
        }
    }

    public class Delivery : IDelivery
    {
        public IDictionary<int, string> GetStatuses()
        {
            Dictionary<int, string> status = new Dictionary<int, string>();
            status.Add(1, "Delivered");
            status.Add(2, "Not delivered");
            status.Add(3, "In progress");
            Thread.Sleep(2000); // Simulation of status output with delay
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
        Console.WriteLine("\nProxy Solution:");
        IDelivery delivery = new DeliveryProxy(new Delivery());
        IEnumerable<Package> packages = delivery.GetPackages();
        foreach (Package package in packages)
        {
            int packageId = package.StatusId;
            string status = delivery.GetStatuses()[packageId];
            Console.WriteLine($"Package name: {package.Name}, package status: {status}");
        }
    }
}

