namespace DesignPatterns;

internal class StrategySolution
{
    public interface IGun
    {
        void Attack();
    }

    public class Pistol : IGun
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking with pistol");
        }
    }

    public class Shotgun : IGun
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking with shotgun");
        }
    }

    public class Knife : IGun
    {
        public void Attack()
        {
            Console.WriteLine($"Attacking with knife");
        }
    }

    public class Hero
    {
        public string Name { get; set; }
        private IGun _gun;

        public void SetGun(IGun gun)
        {
            _gun = gun;
        }

        public void Attack()
        {
            Console.WriteLine($"{Name} starts attacking");
            _gun.Attack();
            Console.WriteLine($"{Name} finished attacking");
        }
    }

    public void Execute()
    {
        Console.WriteLine("Strategy solution:");
        Hero hero = new Hero()
        {
            Name = "jack"
        };
        hero.SetGun(new Pistol());
        hero.Attack();
        Console.WriteLine();
    }
}
