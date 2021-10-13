using System.Collections.Generic;
using System;

namespace AgamCourse
{
    class Shop
    {
        CovidQueue<Costumer> _queue = new CovidQueue<Costumer>();
        List<Costumer> _costumers = new List<Costumer>();
        List<CashRegister> _registers = new List<CashRegister>();

        public Costumer[] QueuedCostumers { get => _queue.ToArray(); }
        public Costumer[] Costumers { get => _costumers.ToArray(); }

        public Shop()
        {
            var register = new CashRegister();
            register.Operator = new Employee("Some Name");
            _registers.Add(register);
            _registers.Add(new CashRegister());
            _registers.Add(new CashRegister());
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
            for(int i = 0; i < amount; i++)
            {
                _costumers.Add(_queue.Dequeue());
            }
            return amount;
        }
    }
}
