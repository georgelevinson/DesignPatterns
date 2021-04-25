using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace SOLID_D
{
    public enum Relationship
    {
        Parent, Child, Sibling
    }
    public class Person
    {
        public string Name;
    }
    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> _relations
            = new List<(Person, Relationship, Person)>();
        //public List<(Person, Relationship, Person)> Relations => _relations;

        public void AddParentAndChild(Person parent,Person child)
        {
            _relations.Add((parent, Relationship.Parent, child));
            _relations.Add(( child, Relationship.Child, parent));
        }

        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in _relations.Where(
                x => x.Item1.Name == name &&
                     x.Item2 == Relationship.Parent))
            {
                yield return r.Item3;
            }
        }
    }
    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //var relations = relationships.Relations;
        //foreach(var r in relations.Where(
        //    x => x.Item1.Name == "John"&&
        //         x.Item2 == Relationship.Parent))
        //{
        //    Console.WriteLine($"John has a child called {r.Item3.Name}");
        //}
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach (var p in browser.FindAllChildrenOf("John"))
                Console.WriteLine($"Jonhn has a child called {p.Name}");
        }
        static void Main(string[] args)
        {
            var parent = new Person { Name = "John" };
            var child1 = new Person { Name = "Shris" };
            var child2 = new Person { Name = "Mary" };

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
