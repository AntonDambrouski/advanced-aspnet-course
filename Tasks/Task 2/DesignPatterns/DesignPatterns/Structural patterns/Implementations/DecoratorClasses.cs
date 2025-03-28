using DesignPatterns.Structural_patterns.Interfaces;

namespace DesignPatterns.Structural_patterns.Implementations
{
	public class Truck : ICar
	{
		public string Name { get; set; }

		public void Drive()
		{
			Console.WriteLine($"{this.Name} is driving");
		}
	}

	public class Bus : ICar
	{
		public string Name { get; set; }

		public void Drive()
		{
			Console.WriteLine($"{this.Name} is driving");
		}
	}
	public class CarDecoratorBase : ICar
	{
		protected readonly ICar _car;
		public CarDecoratorBase(ICar car)
		{
			this._car = car;
		}

		public virtual string Name
		{
			get => this._car.Name;
			set => this._car.Name = value;
		}

		public virtual void Drive()
		{
			this._car.Drive();
		}
	}

	public class CarStoppedDecorator : CarDecoratorBase
	{
		public CarStoppedDecorator(ICar car) : base(car)
		{

		}

		public override void Drive()
		{
			this._car.Drive();
			this.Stop();
		}
		private void Stop()
		{
			Console.WriteLine($"{this._car.Name} is stopped");
		}
	}

	public class BusPassengersDecorator : CarStoppedDecorator
	{
		private readonly CarStoppedDecorator _carStoppedDecorator;
		public int CountPassangers { get; set; }
		public BusPassengersDecorator(ICar car) : base(car)
		{
			_carStoppedDecorator = new CarStoppedDecorator(car);
		}
		public override void Drive()
		{
			this.ShowPassangers();
			this._carStoppedDecorator.Drive();

		}
		private void ShowPassangers()
		{
			Console.WriteLine($"Count passangers: {this.CountPassangers}");
		}
	}

}
