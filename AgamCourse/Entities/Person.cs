using System;
using System.Collections.Generic;
using System.Text;
using AgamCourse.Entities;

namespace AgamCourse
{
    public class Person : Identifiable
    {
        public string Name { get; set; }
        public float BodyTemperature { get; set; }
        public bool Masked { get; set; }
        public bool Quarantined { get; set; }

        public string ID { get => ID; }

        public Person(string name)
        {
            Name = name;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj) && obj is Person && string.Equals(Name, (obj as Person).Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
