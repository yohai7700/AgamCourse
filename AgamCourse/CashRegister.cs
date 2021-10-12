using System.Collections.Generic;

namespace AgamCourse
{
    class CashRegister
    {
        public Employee Operator { get; set; }

        public IList<Purchase> _purchases = new List<Purchase>();

        public bool Available { get => Operator != null; }

        public void RegisterPurchase(Costumer consumer, Product[] products)
        {
            _purchases.Add(new Purchase(consumer, Operator, products));
        }
    
    }
}
