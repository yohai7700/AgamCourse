using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.bl
{
    class CovidCriteria
    {
        const float MinBodyTemperature = 38f;

        /// <summary>
        /// Validates person is not violating covid laws, throws exceptin otherwise.
        /// </summary>
        public static void Validate(Person person)
        {
            if (!person.Masked) throw new Exception("Can't insert an unmasked person to the Queue.");
            if (person.Quarantined) throw new Exception("Can't insert a quarantined person to the Queue.");
            if (person.BodyTemperature > MinBodyTemperature) throw new Exception($"Cant insert a person with a body temperature higher than {MinBodyTemperature}C");
        }
    }
}
