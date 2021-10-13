using MoreLinq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }
    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        private static int instanceCount;
        public static int Count => instanceCount;
        private static Lazy<SingletonDatabase> instance = new Lazy<SingletonDatabase>(() => new SingletonDatabase());
        public static SingletonDatabase Instance => instance.Value;
        private SingletonDatabase()
        {
            instanceCount++;
            Console.WriteLine("Init db");
            capitals = File.ReadAllLines(Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                               .Batch(2)
                               .ToDictionary(list => list.ElementAt(0).Trim(),
                                             list => int.Parse(list.ElementAt(1)));
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }

    public class DummyDatabase : IDatabase
    {
        public int GetPopulation(string name)
        {
            return new Dictionary<string, int>
            {
                ["alpha"] = 1,
                ["beta"] = 2,
                ["gamma"] = 3
            }[name];
        }
    }

    public class OrdinaryDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;

        public OrdinaryDatabase()
        {
            Console.WriteLine("Init db");
            capitals = File.ReadAllLines(Path.Combine(new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "capitals.txt"))
                               .Batch(2)
                               .ToDictionary(list => list.ElementAt(0).Trim(),
                                             list => int.Parse(list.ElementAt(1)));
        }
        public int GetPopulation(string name)
        {
            return capitals[name];
        }
    }
}
