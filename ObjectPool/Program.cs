using System;

namespace ObjectPool
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var iit = new InternalIT();

            for (int i = 0; i < 10; i++)
            {
                var laptop = iit.GetNew(i.ToString());
                Console.WriteLine(laptop.Name);
                iit.Release(laptop);
            }
            
            Console.WriteLine("Stop");
        }
    }
}
