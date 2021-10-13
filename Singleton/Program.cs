using Autofac;
using MoreLinq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Singleton
{
    static class Program
    {
        public static class SingletonTester
        {
            public static bool IsSingleton(Func<object> func)
            {
                return ReferenceEquals(func.Invoke(), func.Invoke());
            }
        }
        static void Main(string[] args)
        {
            //================================================================

            //Exercise

            //Func<object> returnSingleton = () => new OrdinaryDatabase();

            //var output = SingletonTester.IsSingleton(returnSingleton);

            //Console.WriteLine(output);

            //================================================================

            //CEO Example

            //var ceo = new CEO();
            //ceo.Name = "Adam Smith";
            //ceo.Age = 55;

            //var ceo2 = new CEO();
            //Console.WriteLine(ceo2);

            //================================================================

            //PerThreadSingleton Example

            //var taskOne = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("t1: " + PerThreadSingleton.Instance.Id);
            //});
            //var taskTwo = Task.Factory.StartNew(() =>
            //{
            //    Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);
            //    Console.WriteLine("t2: " + PerThreadSingleton.Instance.Id);
            //});

            //Task.WaitAll(taskOne, taskTwo);

            //================================================================

            //Building Example

            //var house = new Building();

            ////gnd floor
            //using(new BuildingContext(3000))
            //{
            //    house.Walls.Add(new Wall(new Point(0, 0), new Point(5000, 0)));
            //    house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));

            //    using(new BuildingContext(3500))
            //    {
            //        //first floor
            //        house.Walls.Add(new Wall(new Point(0, 0), new Point(6000, 0)));
            //        house.Walls.Add(new Wall(new Point(0, 0), new Point(0, 4000)));
            //    }

            //    //ground floor
            //    house.Walls.Add(new Wall(new Point(5000, 0), new Point(5000, 4000)));
            //}

            //Console.WriteLine(house);

            //================================================================
        }
    }
}
