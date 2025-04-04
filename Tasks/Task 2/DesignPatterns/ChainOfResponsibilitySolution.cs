using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.ChainOfResponsibilitySolution
{
    internal class ChainOfResponsibilitySolutionDemo: IDemo
    {
        public void Execute()
        {
            Order order = new Order();
            IOrderService acceptService = new AcceptService();
            IOrderService collectService = new CollectService();
            IOrderService shipService = new ShipService();

            acceptService.SetNext(collectService);
            collectService.SetNext(shipService);
            List<IOrderService> orderServices = new List<IOrderService>()
            {
                acceptService, collectService, shipService
            };          
                acceptService.Process(order);            
        }

        public void Accept(IMainVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    public interface IOrderService
    {
        void SetNext(IOrderService service);
        void Process(Order order);
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


    public class AcceptService : IOrderService
    {
        private IOrderService? _nextService;

        public void SetNext(IOrderService service)
        {
            _nextService = service;
        }

        public void Process(Order order) 
        {
            if (order.State.Equals(OrderState.Created))
            {
                order.ChangeState(OrderState.Accepted);
                Console.WriteLine("Order is Accepted");
            } 
            if (_nextService != null)
            {
                _nextService.Process(order);
            }
        }
    }

    public class CollectService : IOrderService
    {
        private IOrderService? _nextService;

        public void SetNext(IOrderService service)
        {
            _nextService = service;
        }

        public void Process(Order order)
        {
            if (order.State.Equals(OrderState.Accepted))
            {
                order.ChangeState(OrderState.Collected);
                Console.WriteLine("Order is Collected");
            }
            if (_nextService != null)
            {
                _nextService.Process(order);
            }
        }
    }


    public class ShipService : IOrderService
    {
        private IOrderService? _nextService;

        public void SetNext(IOrderService service)
        {
            _nextService = service;
        }

        public void Process(Order order)
        {
            if (order.State.Equals(OrderState.Collected))
            {
                order.ChangeState(OrderState.Shipped);
                Console.WriteLine("Order is Shipped");
            }
            if (_nextService != null)
            {
                _nextService.Process(order);
            }
        }
    }
}
