

using DesignPatterns.Structural_patterns.Implementations;
using DesignPatterns.Structural_patterns.Interfaces;

namespace DesignPatterns.Structural_patterns
{
	// Чтобы добавить классу Bus новое поведени
	// придётся залазить в реализацию класса, что не всегда возможно 
	public class DecoratorProblem : IExecutor
	{
		public void Execute()
		{
			ICar bus = new Bus();
			bus.Name = "My bus";
			bus.Drive();
		}
	}
}
