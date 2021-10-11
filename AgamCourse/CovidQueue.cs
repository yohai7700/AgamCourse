using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class CovidQueue<T> : Queue<T> where T : Person 
    {
        const float MinBodyTemperature = 38f;

        public new void Enqueue(T person)
        {
            ValidateEnqueue(person);
            base.Enqueue(person);
        }

        private void ValidateEnqueue(T person)
        {
            if (!person.Masked) throw new Exception("Can't insert an unmasked person to the Queue.");
            if (person.Quarantined) throw new Exception("Can't insert a quarantined person to the Queue.");
            if (person.BodyTemperature > MinBodyTemperature) throw new Exception($"Cant insert a person with a body temperature higher than {MinBodyTemperature}C");
        }
    }
}
