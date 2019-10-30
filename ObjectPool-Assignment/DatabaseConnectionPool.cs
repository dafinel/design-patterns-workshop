using System;
using System.Collections.Concurrent;
using System.Threading;

namespace ObjectPool_Assignment
{
    public class DatabaseConnectionPool
    {
        private ConcurrentBag<DatabaseConnection> _container;
        private static readonly object Lock = new object();

        public DatabaseConnectionPool(int maxSize)
        {
            _container = new ConcurrentBag<DatabaseConnection>();

            for (int i = 0; i < maxSize; i++)
            {
                _container.Add(new DatabaseConnection());
            }
        }

        public DatabaseConnection GetNew(string name)
        {
            lock (Lock)
            {
                if (_container.TryTake(out var connection))
                {
                    Console.WriteLine($"Thread {name} aquired a new connection");
                    connection.Name = name;
                }
                return connection;
            }
        }

        public void Release(DatabaseConnection connection)
        {
            Console.WriteLine($"Thread {connection.Name} released a new connection");
            lock (Lock)
            {
                _container.Add(connection);
            }
        }
    }
}