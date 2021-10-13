using Autofac;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    [TestFixture]
    public class SingletonTests
    {
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            var finder = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int total = finder.GetTotalPopulation(names);

            Assert.That(total, Is.EqualTo(17500000 + 17400000));
        }

        [Test]
        public void ConfigurableTotalPopulationTest()
        {
            var finder = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gamma" };
            int total = finder.GetTotalPopulation(names);

            Assert.That(total, Is.EqualTo(4));
        }
        [Test]
        public void DIPopulationTest()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<OrdinaryDatabase>()
                .As<IDatabase>()
                .SingleInstance();
            builder.RegisterType<ConfigurableRecordFinder>();

            int total;
            using (var c = builder.Build())
            {
                var finder = c.Resolve<ConfigurableRecordFinder>();
                var names = new[] { "Seoul", "Mexico City" };
                total = finder.GetTotalPopulation(names);
            }

            Assert.That(total, Is.EqualTo(17500000 + 17400000));
        }
    }
}
