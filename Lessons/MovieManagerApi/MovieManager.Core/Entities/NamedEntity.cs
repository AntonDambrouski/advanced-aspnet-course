namespace MovieManager.Core.Entities;
public abstract class NamedEntity : Entity
{
    public string Name { get; set; } = string.Empty;
}
