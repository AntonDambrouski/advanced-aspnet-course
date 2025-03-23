using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibilitySolution
{
    internal class SingleResponsibilitySolution
    {
        public void Execute() 
        {
            Order order = new Order(1235);
            order.AddItem("A bottle of water");
            order.AddItem("Apple");
            order.AddItem("Bread");

            PrintService printService = new PrintService(order);
            printService.PrintOrder();
        }
    }

    interface ILogger
    {
        public void Log(string message);
    }
    public class LoggerServiceToConsole : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }


    public class PrintService 
    {
         private Order _order;
        public PrintService(Order order) 
        { 
            _order = order;
        }
        public void PrintOrder()
        {
            if (_order.ItemList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"List of Order {_order.Id} dated {_order.Created}");

                Console.WriteLine("=================================================");
                foreach (var item in _order.ItemList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"Order {_order.Id} dated {_order.Created} is empty");
            }
        }
    }


    public class Order
    {

        private ILogger logger;
        public int Id { get; private set; }
        public List<string> ItemList { get; private set; } = new List<string>();

        public DateTime Created { get; private set; }

        public Order(int id)
        {
            Id = id;
            Created = DateTime.Now;
            logger = new LoggerServiceToConsole();
            logger.Log($"{DateTime.Now} - Order {id} is created");
        }

        public void AddItem(string item)
        {
            ItemList.Add(item);
            logger.Log($"{DateTime.Now} - Order {Id} item {item} was added");
        }

        public void RemoveItem(string item)
        {
            ItemList.Remove(item);
            logger.Log($"{DateTime.Now} - Order {Id} item {item} was removed");
        }

    }
}
