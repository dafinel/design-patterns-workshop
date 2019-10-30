using System;
using System.Threading.Tasks;

namespace Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            President president = null;
            Parallel.For(0, 6, (index) =>
            {
                president = President.GetPresident($"Iohanis{index}", "Romania");
            });
           
            Console.WriteLine(president.ToString());

            president = President.GetPresident("Dancila", "Romania");

            Console.WriteLine(president.ToString());
        
        }
    }
}
