using DesignPatterns.Structural_patterns.Interfaces;
using DesignPatterns.Structural_patterns.Implementations;

namespace DesignPatterns.Structural_patterns
{
	// Чтобы не менять реализацию класса при необходимости добавления нового поведенияб
	// обернём интерфейс ICar, который реализует класс Bus в декоратор с новым методом Stop(),
	// так же можно обернуть декоратор в новый декоратор
	class DecoratorSolution : IExecutor
	{
		public void Execute()
		{
			ICar bus = new Bus();
			bus.Name = "Bus";
			ICar truck = new Truck();
			truck.Name = "Truck";
			CarStoppedDecorator truckStopped = new CarStoppedDecorator(truck);	
			truckStopped.Drive();
			BusPassengersDecorator busPassengers = new BusPassengersDecorator(bus);
			busPassengers.CountPassangers = 6;
			busPassengers.Drive();
		}
	}

}
