using System;
using System.Collections.Generic;
using AgamCourse.bl;

namespace AgamCourse
{
    class CovidQueue<T> : Queue<T> where T : Person
    {
        const float MinBodyTemperature = 38f;

        public new void Enqueue(T person)
        {
            CovidCriteria.Validate(person);
            base.Enqueue(person);
        }
    }
}
