namespace DesignPatterns;

internal class FactoryProblem
{
    public class DeliveryByTrain
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by train");
        }
    }

    public class DeliveryByPlane
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by plane");
        }
    }

    public class DeliveryByShip
    {
        public void Delivery(string itemForDelivery)
        {
            Console.WriteLine($"Delivery {itemForDelivery} by ship");
        }

    }

    public void Execute()
    {
        Console.WriteLine("Factory Problem:");
        string deliveryType = "Train";
        switch (deliveryType)
        {
            case "Train":
                DeliveryByTrain train = new DeliveryByTrain();
                train.Delivery("Phone");
                break;
            case "Plane":
                DeliveryByPlane plane = new DeliveryByPlane();
                plane.Delivery("Phone");
                break;
            case "Ship":
                DeliveryByShip ship = new DeliveryByShip();
                ship.Delivery("Phone");
                break;
        }
    }
}
