using DesignPatterns.Creational_patterns.Interfaces;


namespace DesignPatterns.Creational_patterns.Implementations
{
    public class KamazBuilder : ICarBuilder
    {
        private Kamaz _kamaz = new Kamaz();

        public KamazBuilder()
        {
            this.Reset();
        }
        public void Reset()
        {
            this._kamaz = new Kamaz();
        }

        public ICarBuilder BuildBody()
        {
            this._kamaz.Body = "Cargo";
            return this;
        }

        public ICarBuilder BuildChassis()
        {
            this._kamaz.Chassis = "6 wheels";
            return this;
        }

        public ICarBuilder BuildInterior()
        {
            this._kamaz.Interior = "Interior";
            return this;
        }
        public ICar Build()
        {
            Kamaz kamaz = this._kamaz;
            this.Reset();
            return kamaz;
        }
    }

    public class BusBuilder : ICarBuilder
    {
        private Bus _bus = new Bus();
        public BusBuilder()
        {
            this.Reset();
        }

        public void Reset()
        {
            this._bus = new Bus();
        }


        public ICarBuilder BuildBody()
        {
            this._bus.Body = "Bus";
            return this;
        }

        public ICarBuilder BuildChassis()
        {
            this._bus.Chassis = "4 wheels";
            return this;
        }

        public ICarBuilder BuildInterior()
        {
            this._bus.Interior = "12 seats";
            return this;
        }
        public ICar Build()
        {
            Bus bus = this._bus;
            this.Reset();
            return bus;
        }
    }
    public class Kamaz : ICar
    {
        private string? _body;
        private string? _chassis;
        private string? _interior;
        public string? Chassis { get => _chassis; set => _chassis = value; }
        public string? Body { get => _body; set => _body = value; }
        public string? Interior { get => _interior; set => _interior = value; }

        public void Show()
        {
            Console.WriteLine($"Kamaz: Body - {this.Body}, Chassies - {this.Chassis}, Interior - {this.Interior}");
        }
    }
    public class Bus : ICar
    {
        private string? _body;
        private string? _chassis;
        private string? _interior;
        public string? Chassis { get => _chassis; set => _chassis = value; }
        public string? Body { get => _body; set => _body = value; }
        public string? Interior { get => _interior; set => _interior = value; }

        public void Show()
        {
            Console.WriteLine($"Bus: Body - {this.Body}, Chassies - {this.Chassis}, Interior - {this.Interior}");
        }
    }


}
