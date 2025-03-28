using DesignPatterns.Behavioral_patterns.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral_patterns.Implementations
{
	public class ProductProblem
	{
		private ClientAProblem clientA = new ClientAProblem();
		private ClientBProblem clientB = new ClientBProblem();
		public int State { get; set; } = 0;
		public ProductProblem(ClientAProblem clientA, ClientBProblem clientB)
		{
			this.clientA = clientA;
			this.clientB = clientB;
		}
		public void Notify()
		{
			Console.WriteLine("Product: Notifying observers...");
			clientA.Update(this);
			clientB.Update(this);
		}
		public void SomeBusinessLogic()
		{
			Console.WriteLine("\nSome logic");
			for (this.State = 0; this.State < 5; this.State++)
			{
				this.Notify();
			}
		}

	}

	public class ClientAProblem
	{
		public void Update(ProductProblem product)
		{
			if (product.State % 2 == 0)
			{
				Console.WriteLine("ClientA: Reacted to the event, even number");
			}
		}
	}

	public class ClientBProblem
	{
		public void Update(ProductProblem product)
		{
			if (product.State % 2 != 0)
			{
				Console.WriteLine("ClientB: Reacted to the event, odd number");
			}
		}
	}




	public class Product : IObservable
	{
		public int State { get; set; } = 0;
		private List<IObserver> _observers = new List<IObserver>();

		public void Attach(IObserver observer)
		{
			Console.WriteLine("Product:" + observer.ToString() + " Attached an observer.");
			this._observers.Add(observer);
		}

		public void Detach(IObserver observer)
		{
			this._observers.Remove(observer);
			Console.WriteLine("Product:" + observer.ToString() + " Detached an observer.");
		}

		public void Notify()
		{
			Console.WriteLine("Product: Notifying observers...");

			foreach (var observer in _observers)
			{
				observer.Update(this);
			}
		}

		public void SomeBusinessLogic()
		{
			Console.WriteLine("\nSome logic");
			for (this.State = 0; this.State < 5; this.State++)
			{
				this.Notify();
			}
		}
	}

	class ClientA : IObserver
	{
		public void Update(IObservable product)
		{
			if ((product as Product).State % 2 == 0)
			{
				Console.WriteLine("ClientA: Reacted to the event, even number");
			}
		}
	}

	class ClientB : IObserver
	{
		public void Update(IObservable product)
		{
			if ((product as Product).State % 2 != 0)
			{
				Console.WriteLine("ClientB: Reacted to the event, odd number");
			}
		}
	}
}
