using System.Collections.Generic;
using System;

namespace AgamCourse
{
    class Shop
    {
        CovidQueue<Costumer> queue = new CovidQueue<Costumer>();
        List<Costumer> consumers = new List<Costumer>();

        public Costumer[] QueuedCostumers { get => queue.ToArray(); }

        public void Enqueue(Costumer consumer)
        {
            queue.Enqueue(consumer);
        }

        /// <returns>The amount of consumers that were proceeded</returns>
        public int ProceedCostumers(int desiredAmount)
        {
            int amount = Math.Min(desiredAmount, queue.Count);
            for(int i = 0; i < amount; i++)
            {
                consumers.Add(queue.Dequeue());
            }
            return amount;
        }
    }
}
