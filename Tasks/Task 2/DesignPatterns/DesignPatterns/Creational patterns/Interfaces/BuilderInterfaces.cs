

namespace DesignPatterns.Creational_patterns.Interfaces
{
    public interface ICarBuilder
    {
        public ICarBuilder BuildChassis();
        public ICarBuilder BuildBody();
        public ICarBuilder BuildInterior();
        public ICar Build();
        public void Reset();
    }

    public interface ICar
    {
        public string? Chassis { get; set; }
        public string? Body { get; set; }
        public string? Interior { get; set; }

        public void Show();
    }
}
