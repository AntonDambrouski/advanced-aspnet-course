namespace DesignPatterns;
public class BuilderProblem
{
    public class Chair
    {
        public string SeatMaterial { get; set; }

        public string LegsMaterial { get; set; }

        public string BackRestMaterial { get; set; }

        public Chair(string seatMaterial, string legsMaterial, string backRestMaterial)
        {
            SeatMaterial = seatMaterial;
            LegsMaterial = legsMaterial;
            BackRestMaterial = backRestMaterial;
        }

        public void ShowInfo()
        {
            Console.WriteLine("\nInformation about chair:");
            Console.WriteLine($"Chair seat material: {SeatMaterial}");
            Console.WriteLine($"Chair legs material: {LegsMaterial}");
            Console.WriteLine($"Chair backrest material: {BackRestMaterial}");
        }
    }

    public void Execute()
    {
        Console.WriteLine("BuliderProblem:");
        Chair chairWithBackrest = new Chair("Leather", "Wood", "Wood");
        chairWithBackrest.ShowInfo();
        Chair chairWithoutBackrest = new Chair("Cotton", "Iron", "No backrest");
        chairWithoutBackrest.ShowInfo();
    }
}
