namespace DesignPatterns;

internal class StrategyProblem
{
    class Hero()
    {
        public string Name { get; set; }

        public enum GunType
        {
            pistol,
            shotgun,
            knife
        }

        public void Attack(GunType gunType)
        {
            Console.WriteLine($"{Name} starts attacking");
            switch (gunType)
            {
                case GunType.pistol:
                    Console.WriteLine($"Attacking with pistol");
                    break;
                case GunType.shotgun:
                    Console.WriteLine($"Attacking with shotgun");
                    break;
                case GunType.knife:
                    Console.WriteLine($"Attaking with knife");
                    break;
            }
            Console.WriteLine($"{Name} finished attacking");
        }
    }

    public void Execute()
    {
        Console.WriteLine("\n Strategy problem:");
        Hero hero = new Hero()
        {
            Name = "Jack"
        };
        hero.Attack(Hero.GunType.pistol);
        Console.WriteLine();
    }
}
