using System.Collections.Generic;
using System;

namespace AgamCourse
{
    class Shop
    {
        CovidQueue<Consumer> queue = new CovidQueue<Consumer>();
        List<Consumer> consumers = new List<Consumer>();

        public Consumer[] QueuedConsumers { get => queue.ToArray(); }

        public void Enqueue(Consumer consumer)
        {
            queue.Enqueue(consumer);
        }

        /// <returns>The amount of consumers that were proceeded</returns>
        public int ProceedConsumers(int desiredAmount)
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
