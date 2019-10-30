using System;
using System.Threading;
using System.Threading.Tasks;

namespace ObjectPool_Assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");
            var pool = new DatabaseConnectionPool(2);

            Parallel.For(0, 6, (index) =>
            {
                var connection = pool.GetNew(index.ToString());
                while (connection == null)
                {
                    Console.WriteLine($"Thread {index.ToString()} waits for a new connection");
                    Thread.Sleep(new TimeSpan(0, 0, 1));
                    connection = pool.GetNew(index.ToString());
                }
                
                Thread.Sleep(new TimeSpan(0,0, 2));

                pool.Release(connection);
            });

            Console.WriteLine("Stop");
        }
    }
}
