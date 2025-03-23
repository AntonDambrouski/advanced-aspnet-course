using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciples.SingleResponsibilityProblem
{
    internal class SingleResponsibilityProblem
    {
        public void Execute()
        {
            Order order = new Order(1235);
            order.AddItem("A bottle of water");
            order.AddItem("Apple");
            order.AddItem("Bread");
            order.PrintOrder();
        }
    }

    public class Order
    {
        public int Id { get; private set; }
        public List<string> ItemList { get; private set; } = new List<string>();

        public DateTime Created { get; private set; }

        public Order(int id)
        {
            Id = id;
            Created = DateTime.Now;
            Log($"{DateTime.Now} - Order {id} is created");
        }

        public void AddItem(string item)
        {
            ItemList.Add(item);
            Log($"{DateTime.Now} - Order {Id} item {item} was added");
        }

        public void RemoveItem(string item)
        {
            ItemList.Remove(item);
            Log($"{DateTime.Now} - Order {Id} item {item} was removed");
        }

        public void PrintOrder()
        {
            if (ItemList.Count > 0)
            {
                Console.WriteLine();
                Console.WriteLine($"List of Order {Id} dated {Created}");
                
                Console.WriteLine("=================================================");
                foreach (var item in ItemList)
                {
                    Console.WriteLine(item);
                }
            }
            else
            {
                Console.WriteLine($"Order {Id} dated {Created} is empty");
            }
        }

        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
}
