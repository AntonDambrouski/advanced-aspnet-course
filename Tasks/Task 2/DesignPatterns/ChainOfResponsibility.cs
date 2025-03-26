using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibility
{
    internal class ChainOfResponsibilityDemo: IDemo
    {
        public void Execute()
        {
            Order order = new Order();
            if (order.State == OrderState.Created) 
            {
                new AcceptService(order).Process();
            }
            if (order.State == OrderState.Accepted)
            {
                new CollectService(order).Process();
            }
            if (order.State == OrderState.Collected)
            {
                new ShipService(order).Process();
            }

        }


        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }

    }

    public interface IOrderService
    {
        public void Process();
    }

    public class Order
    {
        public OrderState State { get; private set; } = OrderState.Created;
        public Order() 
        {
            Console.WriteLine("Order is Created");
        }
        public void ChangeState(OrderState state)
        {
            State = state;
        }
    
    }


    public enum OrderState
    {
        Created, 
        Accepted,
        Collected,
        Shipped
    }

    public class AcceptService: IOrderService
    {
        private Order _order;
        public AcceptService(Order order) 
        { 
            _order = order;
        }
        public void Process()
        {
            _order.ChangeState(OrderState.Accepted);
            Console.WriteLine("Order is Accepted");
        }
    }


    public class CollectService
    {
        private Order _order;
        public CollectService(Order order)
        {
            _order = order;
        }
        public void Process()
        {
            _order.ChangeState(OrderState.Collected);
            Console.WriteLine("Order is Collected");
        }

    }

    public class ShipService
    {
        private Order _order;
        public ShipService(Order order)
        {
            _order = order;
        }
        public void Process()
        {                       
            _order.ChangeState(OrderState.Shipped);
            Console.WriteLine("Order is Shipped");
        }
    }


    







}
