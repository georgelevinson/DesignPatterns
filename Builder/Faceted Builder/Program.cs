using System;

namespace Faceted_Builder
{
    class Program
    {
        public class Person
        {
            public string StreetAddress, Postcode, City;

            public string CompanyName, Position;
            public int AnnualIncome;

            public override string ToString()
            {
                return $"Street: {StreetAddress}, Postcode: {Postcode}, City {City}, Company Name: {CompanyName}, Position: {Position}, Income: {AnnualIncome}";
            }
        }
        public class PersonBuilder
        {
            //reference type!
            protected Person person = new Person();
            public static implicit operator Person(PersonBuilder pb) { return pb.person; }
 
            public PersonJobBuilder Works => new PersonJobBuilder(person);
            public PersonAddressBuilder Lives => new PersonAddressBuilder(person);
        }
        public class PersonAddressBuilder : PersonBuilder
        {
            public PersonAddressBuilder(Person person)
            {
                this.person = person;
            }
            public PersonAddressBuilder At(string streetAddress)
            {
                person.StreetAddress = streetAddress;
                return this;
            }
            public PersonAddressBuilder Postcode(string postcode)
            {
                person.Postcode = postcode;
                return this;
            }
            public PersonAddressBuilder In(string city)
            {
                person.City = city;
                return this;
            }
        }
        public class PersonJobBuilder : PersonBuilder
        {
            public PersonJobBuilder(Person person)
            {
                this.person = person;
            }

            public PersonJobBuilder At(string companyName)
            {
                person.CompanyName = companyName;
                return this;
            }
            public PersonJobBuilder AsA(string position)
            {
                person.Position = position;
                return this;
            }
            public PersonJobBuilder Earning(int amount)
            {
                person.AnnualIncome = amount;
                return this;
            }
        }
        static void Main(string[] args)
        {
            var pb = new PersonBuilder();
            var person = pb
                .Works.At("Google")
                      .AsA("Engineer")
                      .Earning(12500)
                .Lives.At("212 Greenwich Road")
                      .In("London")
                      .Postcode("34252");
            Console.WriteLine(person);
        }
    }
}
