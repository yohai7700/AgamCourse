using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    class Person
    {
        public string Name { get; set; }
        public float BodyTemperature { get; set; }
        public bool Masked { get; set; }
        public bool Quarantined { get; set; }

        public Person(string name)
        {
            Name = name;
        }
    }
}
