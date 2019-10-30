using System;
using System.Threading;

namespace ObjectPool
{
    public class Laptop
    {
        public Laptop(string name)
        {
            Name = name;
            Thread.Sleep(new TimeSpan(0,0,0,2));
        }

        public string Name { get; set; }
    }
}