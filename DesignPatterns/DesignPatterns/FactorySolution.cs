namespace DesignPatterns;

public class FactorySolution
{
    public interface IDelivery
    {
        void Delivery(string itemForDelivery);
    }

    public class DeliveryFactory
    {
        public IDelivery GetDeliveryType(string deliveryType)
        {
            switch (deliveryType)
            {
                case "Train":
                    return new DeliveryByTrain();
                case "Plane":
                    return new DeliveryByPlane();
                case "Ship":
                    return new DeliveryByShip();
            }
            return null;
        }
    }

    public class DeliveryByTrain : IDelivery
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by train");
        }
    }

    public class DeliveryByPlane : IDelivery
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by plane");
        }
    }

    public class DeliveryByShip : IDelivery
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by ship");
        }

    }

    public void Execute()
    {
        Console.WriteLine("Factory Solution:");
        string deliveryType = "Train";
        DeliveryFactory factory = new DeliveryFactory();
        var delivery = factory.GetDeliveryType(deliveryType);
        delivery.Delivery("Phone");
    }
}
