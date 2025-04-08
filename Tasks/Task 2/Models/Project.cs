public class Project
{
    public int Id { get; set; }
    public DateTime DateOfConclusion{ get; set; }
    public int NumberContract{ get; set; }
    public string Name { get; set; }
    public List<Construction> ListConstruction{get;set;}
    public List<Worker> workers { get; set;}
}