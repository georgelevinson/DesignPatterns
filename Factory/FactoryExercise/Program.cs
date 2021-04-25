using System;

namespace FactoryExercise
{
    class Program
    {
        public class Person
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override string ToString()
            {
                return $"This person's name is {Name}, their Id is {Id}";
            }
        }

        public class PersonFactory
        {
            private int _currentPerson = 0;

            public Person CreatePerson(string name)
            {
                var person = new Person();
                person.Id = _currentPerson;
                person.Name = name;
                _currentPerson++;
                return person;
            }
        }

        static void Main(string[] args)
        {
            var factory = new PersonFactory();
            var p1 = factory.CreatePerson("First");
            var p2 = factory.CreatePerson("Second");
            var p3 = factory.CreatePerson("Third");
            Console.WriteLine(p1);
            Console.WriteLine(p2);
            Console.WriteLine(p3);
        }
    }
}
