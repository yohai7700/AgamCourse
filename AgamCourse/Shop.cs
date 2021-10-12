using System.Collections.Generic;
using System;

namespace AgamCourse
{
    class Shop
    {
        CovidQueue<Costumer> _queue = new CovidQueue<Costumer>();
        List<Costumer> _consumers = new List<Costumer>();
        List<CashRegister> _registers = new List<CashRegister>();

        public Costumer[] QueuedCostumers { get => _queue.ToArray(); }

        public Shop()
        {
            _registers.Add(new CashRegister());
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
                _consumers.Add(_queue.Dequeue());
            }
            return amount;
        }
    }
}
