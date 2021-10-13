using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class SingletonRecordFinder
    {
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            var instance = SingletonDatabase.Instance;
            foreach (var name in names)
                result += instance.GetPopulation(name);
            return result;
        }
    }

    public class ConfigurableRecordFinder
    {
        private IDatabase database;
        public ConfigurableRecordFinder(IDatabase database)
        {
            this.database = database ?? throw new ArgumentNullException(paramName: nameof(database));
        }
        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            var instance = SingletonDatabase.Instance;
            foreach (var name in names)
                result += database.GetPopulation(name);
            return result;
        }
    }
}
