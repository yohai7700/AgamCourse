using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.ui
{
    class CovidSurvery
    {
        public static void Update(Person person)
        {
            Console.WriteLine("Is the costumer masked?(Y/N)");
            person.Masked = Menu.ReadBool();
            Console.WriteLine("Is the costumer in quarantine?(Y/N)");
            person.Quarantined = Menu.ReadBool();
            Console.WriteLine("What's the costumer's body temperature (C)?");
            person.BodyTemperature = Menu.ReadFloat();
        }
    }
}
