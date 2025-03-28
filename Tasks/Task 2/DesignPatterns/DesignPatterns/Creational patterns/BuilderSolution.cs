using DesignPatterns.Creational_patterns.Implementations;
using DesignPatterns.Creational_patterns.Interfaces;


namespace DesignPatterns.Creational_patterns
{

    public class BuilderSolution : IExecutor
    {
        public void Execute()
        {
            ICar kamaz = new KamazBuilder().BuildInterior().BuildBody().Build();
            kamaz.Show();
            ICar bus = new BusBuilder().BuildInterior().BuildChassis().Build();
            bus.Show();
        }
    }
}
