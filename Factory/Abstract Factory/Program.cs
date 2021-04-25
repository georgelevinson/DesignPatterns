﻿using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

namespace Abstract_Factory
{
    public interface IHotDrink
    {
        void Consume();
    }
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This tea is nice but I'd prefer it with milk.");
        }
    }
    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("This coffe is sensational!");
        }
    }
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Put in a teabag, boil water, pour {amount} ml, add lemon and enjoy!");
            return new Tea();
        }
    }
    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"Grind some beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> factories =
            new List<Tuple<string, IHotDrinkFactory>>();

        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(type) && !type.IsInterface)
                {
                    factories.Add(Tuple.Create(
                        type.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(type)
                        ));
                }
            }
        }
        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks");
            for (int index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }
            while(true)
            {
                string s;
                if((s = Console.ReadLine()) != null
                    && int.TryParse(s,out int i)
                    && i >=0
                    && i < factories.Count)
                {
                    Console.WriteLine("Specify amount");
                    s = Console.ReadLine();
                    if(s != null
                       && int.TryParse(s, out int amount)
                       && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again!");
            }
        }
    }
    //open-closed principle violated by using enum within the HDM class (has to be changed when adding a new drink)

    //public class HotDrinkMachine
    //{
    //    public enum AvailableDrink
    //    {
    //        Coffee, Tea
    //    }

    //    private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
    //        new Dictionary<AvailableDrink, IHotDrinkFactory>();

    //    public IHotDrink MakeDrink(AvailableDrink drink, int amount)
    //    {
    //        return factories[drink].Prepare(amount);
    //    }

    //    public HotDrinkMachine()
    //    {
    //        foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
    //        {
    //            var factory = (IHotDrinkFactory)Activator.CreateInstance(
    //                 Type.GetType("Abstract_Factory." + Enum.GetName(typeof(AvailableDrink), drink) + "Factory")
    //                );
    //            factories.Add(drink, factory);
    //        }
    //    }
    //}
    class Program
    {
        static void Main(string[] args)
        {
            //var machine = new HotDrinkMachine();
            //var drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            //drink.Consume();

            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink();
            drink.Consume();
        }
    }
}
