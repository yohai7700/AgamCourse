using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class Purchase
    {
        public Product[] Products { get; }
        public Employee Operator { get; }
        public Costumer Costumer { get; }
        public DateTime Time { get; }


        public Purchase(Costumer costumer, Employee employee, Product[] products)
        {
            Time = DateTime.Now;
            Costumer = costumer;
            Operator = employee;
            Products = products;
        }

    }
}
