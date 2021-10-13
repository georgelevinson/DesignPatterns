using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Singleton
{
    sealed class PerThreadSingleton
    {
        public int Id;
        private static ThreadLocal<PerThreadSingleton> threadInstance = new ThreadLocal<PerThreadSingleton>(() => new PerThreadSingleton());
        public static PerThreadSingleton Instance => threadInstance.Value;

        private PerThreadSingleton()
        {
            Id = Thread.CurrentThread.ManagedThreadId;
        }
    }
}
