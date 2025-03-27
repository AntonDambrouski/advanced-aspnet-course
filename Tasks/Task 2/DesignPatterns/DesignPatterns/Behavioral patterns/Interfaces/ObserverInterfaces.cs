using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral_patterns.Interfaces
{
	public interface IObservable
	{
		void Attach(IObserver observer);
		void Detach(IObserver observer);
		void Notify();
	}


	public interface IObserver
	{
		void Update(IObservable product);
	}
}
