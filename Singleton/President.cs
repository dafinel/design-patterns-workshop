using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    public class President
    {
        private static President _instance = null;
        private static object canCreate = new object();
        private President(string name, string country)
        {
            Name = name;
            Country = country;
        }

        public static President GetPresident(string name, string coutry)
        {
            lock (canCreate)
            {
                if (_instance == null)
                {
                    _instance = new President(name, coutry);
                }
            }

            return _instance;
        }

        public string Name { get; set; }
        public string Country { get; set; }

        public override string ToString()
        {
            return $"President of {Country} is {Name}";
        }
    }
}
