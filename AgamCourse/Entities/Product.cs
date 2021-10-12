using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class Product
    {
        public string Name { get; }
        public float Price { get; }

        public Product(string name, float price)
        {
            Name = name;
            Price = price;
        }
    }
}
