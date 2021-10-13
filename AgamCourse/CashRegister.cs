using System.Collections.Generic;

namespace AgamCourse
{
    class CashRegister
    {
        public Employee Operator { get; set; }

        Costumer _costumer;
        public Costumer Costumer
        {
            get { return _costumer; }
            set
            {
                if (Operator == null) throw new UnoperatedCashRegisterException();
                _costumer = value;
            }
        }

        public IList<Purchase> _purchases = new List<Purchase>();

        public bool Available { get => Costumer == null && Operator != null; }

        public void RegisterPurchase(Costumer consumer, Product[] products)
        {
            _purchases.Add(new Purchase(consumer, Operator, products));
        }
    
    }
    
    class UnoperatedCashRegisterException : System.Exception { }
}
