using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class CovidQueue<T> where T : Person
    {
        const float MinBodyTemperature = 30f;
        Queue<T> queue = new Queue<T>();

        public int Count { get => queue.Count; }

        public void Enqueue(T person)
        {
            ValidateEnqueue(person);
            queue.Enqueue(person);
        }

        public T Dequeue()
        {
            return queue.Dequeue();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return queue.GetEnumerator();
        }

        public T[] ToArray()
        {
            return queue.ToArray();
        }
        private void ValidateEnqueue(T person)
        {
            if (!person.Masked) throw new Exception("Can't insert an unmasked person to the Queue.");
            if (person.Quarantined) throw new Exception("Can't insert a quarantined person to the Queue.");
            if (person.BodyTemperature > MinBodyTemperature) throw new Exception($"Cant insert a person with a body temperature higher than {person.BodyTemperature}C");
        }
    }
}
