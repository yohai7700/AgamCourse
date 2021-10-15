using System.Collections.Generic;
using System;
using AgamCourse.bl;

namespace AgamCourse
{
    public class Shop
    {
        CovidQueue<Costumer> _queue = new CovidQueue<Costumer>();
        List<Costumer> _costumers = new List<Costumer>();
        List<CashRegister> _registers = new List<CashRegister>();
        EmployeeManager EmployeeManager { get; }

        public Costumer[] QueuedCostumers { get => _queue.ToArray(); }
        public Costumer[] Costumers { get => _costumers.ToArray(); }

        List<CashRegisterShift> _shifts = new List<CashRegisterShift>();
        public CashRegisterShift[] CashRegisterShifts { get => _shifts.ToArray(); }

        public Shop()
        {
            EmployeeManager = new EmployeeManager();
            var register = new CashRegister();
            register.OnShiftStart += (shift) => _shifts.Add(shift);
            register.Operator = new Employee("Some Name");
        }

        public CashRegister FindAvailableCashRegister()
        {
            return _registers.Find((register) => register.Available);
        }

        public void Enqueue(Costumer consumer)
        {
            _queue.Enqueue(consumer);
        }

        /// <returns>The amount of consumers that were proceeded</returns>
        public int ProceedCostumers(int desiredAmount)
        {
            int amount = Math.Min(desiredAmount, _queue.Count);
            for (int i = 0; i < amount; i++)
            {
                _costumers.Add(_queue.Dequeue());
            }
            return amount;
        }
    }
}
