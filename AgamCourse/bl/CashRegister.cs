using System.Collections.Generic;
using System;

namespace AgamCourse
{
    public delegate void ShiftStartListener(CashRegisterShift shift);
    class CashRegister
    {
        CashRegisterShift _shift;

        ShiftStartListener _onShiftStart;
        public event ShiftStartListener OnShiftStart
        {
            add { _onShiftStart += value; }
            remove { _onShiftStart -= value; }
        }
        public Employee Operator
        {
            get => _shift.Employee;
            set
            {
                if (_shift != null)
                {
                    _shift.End();
                }
                _shift = new CashRegisterShift(value);
                if (_onShiftStart != null) _onShiftStart(_shift);
            }
        }

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

        public bool Available { get => Costumer == null && Operator != null; }

        public void RegisterPurchase(Product[] products)
        {
            if (_shift == null) throw new UnoperatedCashRegisterException();
            _shift.AddPurchase(Costumer, products);
        }
    }

    public class CashRegisterShift
    {
        public Employee Employee { get; }
        public DateTime StartDate { get; }
        public DateTime? EndDate { get; private set; }

        List<Purchase> _purchases = new List<Purchase>();
        public Purchase[] Purchases { get => _purchases.ToArray(); }
        public bool Ended { get => EndDate != null; }

        public CashRegisterShift(Employee employee)
        {
            Employee = employee;
            StartDate = DateTime.Now;
        }

        public void End()
        {
            EndDate = DateTime.Now;
        }

        public void AddPurchase(Costumer costumer, Product[] products)
        {
            if (Ended) throw new Exception("Can't add a purchase to ended shift.");
            _purchases.Add(new Purchase(costumer, Employee, products));
        }
    }

    class UnoperatedCashRegisterException : System.Exception { }
}
