using System;

public class SRPProblem {
    public string AnimalName { get; set; }
    public string Area { get; set; }
    public int AnimalAge { get; set; }
    public bool IsDangerous { get; set; }
    public bool SendToZoo { get; set; }
    private static int speciesCatched = 0;
    public SRPProblem(string animalName, string area, int animalAge, bool isDangerous)
    {
        AnimalName = animalName;
        AnimalAge = animalAge;
        IsDangerous = isDangerous;
        SendToZoo = true;
    }

    public void MultipleResponsibilityMethod()
    {
        Console.WriteLine($"Animal's Name is {AnimalName} and it is {AnimalAge} years old");
        Console.WriteLine($"Checking if it is dangerous - {IsDangerous}");
        Console.WriteLine($"Send to the Zoo? - {SendToZoo}");
        Console.WriteLine($"Speaces catched {++speciesCatched}");
    }
}
