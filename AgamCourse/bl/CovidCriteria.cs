using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.bl
{
    class CovidCriteria
    {
        public const float MaxBodyTemperature = 38f;

        /// <summary>
        /// Validates person is not violating covid laws, throws exceptin otherwise.
        /// </summary>
        public static void Validate(Person person)
        {
            if (!person.Masked) throw new UnmaskedPersonException();
            if (person.Quarantined) throw new QuarantinedPersonException();
            if (person.BodyTemperature > MaxBodyTemperature) throw new Exception($"Cant insert a person with a body temperature higher than {MaxBodyTemperature}C");
        }
    }

    public class CovidCriteriaException : Exception { }

    public class UnmaskedPersonException : CovidCriteriaException { }
    public class QuarantinedPersonException : CovidCriteriaException { }
    public class HighBodyTemperatureException : CovidCriteriaException { }
}
