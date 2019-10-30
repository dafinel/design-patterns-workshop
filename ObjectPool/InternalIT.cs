using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace ObjectPool
{
    public class InternalIT
    {
        private ConcurrentBag<Laptop> container;

        public InternalIT()
        {
            container = new ConcurrentBag<Laptop>();
        }

        public Laptop GetNew(string name)
        {
            if (container.TryTake(out var laptop))
            {
                laptop.Name = name;
                return laptop;
            }

            var newLaptop = new Laptop(name);
            return newLaptop;
        }

        public void Release(Laptop laptop)
        {
            container.Add(laptop);
        }
    }
}
