using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Programming_Principles.SOLID
{
    // high-level modules should not depend on low-level; both should depend on abstractions
    // abstractions should not depend on details; details should depend on abstractions

    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name;
    }

    public interface IFatherFinder
    {
        IEnumerable<Person> FindFathers(string name);
    }

    public class Relationships : IFatherFinder
    {
        private readonly List<(Person, Relationship, Person)> relations =
            new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindFathers(string name)
        {
            // low-level which is incapsulated in the Relationships class
            return relations
                .Where(x => x.Item1.Name == name && x.Item2 == Relationship.Parent)
                .Select(x => x.Item3);
        }

        //  public List<(Person, Relationship, Person)> Relations => relations;
    }

    public class Research
    {
        public Research(Relationships relationships)
        {
            // high-level: find all of John's children
            var johnsFathers = relationships.FindFathers("John");
        }
    }
}