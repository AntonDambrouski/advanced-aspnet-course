using System;

public class SRPSolution {
    public string AnimalName { get; set; }
    public string Area { get; set; }
    public int AnimalAge { get; set; }
    public bool IsDangerous { get; set; }
    public bool SendToZoo { get; set; }
    private static int speciesCatched = 0;
    public SRPSolution(string animalName, string area, int animalAge, bool isDangerous) {
        AnimalName = animalName;
        AnimalAge = animalAge;
        IsDangerous = isDangerous;
        SendToZoo = true;
    }

    public void ScanAnimal()
    {
        Console.WriteLine($"Animal's Name is {AnimalName} and it is {AnimalAge} years old");
        Console.WriteLine($"Checking if it is dangerous - {IsDangerous}");
    }

    public void SendAnimalToZoo()
    {
        Console.WriteLine($"Send to the Zoo? - {SendToZoo}");
    }

    public void speciesCounter()
    {
        Console.WriteLine($"Now we have catched {++speciesCatched} animal(s)");
    }
}
