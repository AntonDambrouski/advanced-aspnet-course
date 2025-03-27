using DesignPatterns.Behavioral_patterns.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Behavioral_patterns
{
	// без применения паттерна Наблюдатель, либо клиенту нужно постоянно обращаться
	// к продукту, чтобы узнать изменения, либо продукт должен уведомлять всех клиентов
	// об изменениях, даже если им это не нужно
	public class ObserverProblem : IExecutor
	{
		public void Execute()
		{
			
			ClientAProblem clientA = new ClientAProblem();
			ClientBProblem clientB = new ClientBProblem();
			ProductProblem product = new ProductProblem(clientA, clientB);
			product.SomeBusinessLogic();

		}
	}
}
