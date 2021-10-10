using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class CovidQueue
    {
        private const float MinBodyTemperature = 30f;
        Queue<Person> queue;

        public void Enqueue(Person person)
        {
            ValidateEnqueue(person);
            queue.Enqueue(person);
        }

        public Person Dequeue()
        {
            return queue.Dequeue();
        }
        private void ValidateEnqueue(Person person)
        {
            if (!person.Masked) throw new Exception("Can't insert an unmasked person to the Queue.");
            if (person.Quarantined) throw new Exception("Can't insert a quarantined person to the Queue.");
            if (person.BodyTemperature > MinBodyTemperature) throw new Exception($"Cant insert a person with a body temperature higher than {person.BodyTemperature}C");
        }
    }
}
