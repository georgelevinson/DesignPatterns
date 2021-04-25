using System;
using System.Threading.Tasks;

namespace Async_Factory_Method
{
    public class Foo
    {
        private Foo()
        {
            // constructor 
        }
        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }
        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
    class Program
    {
        public static async void Main(string[] args)
        {
                Foo x = await Foo.CreateAsync();
        }
    }
}
