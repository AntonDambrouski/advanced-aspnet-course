using Microsoft.Extensions.Diagnostics.HealthChecks;

public class Worker
{
    public int Id{ get; set; }
    public string Name { get; set; }
    public string Surname{ get; set; }
    public List<Project> WorkProject{get;set;}
}