using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    public abstract class InternalMenu : Menu
    {
        public InternalMenu(string[] options) : base(options, true) { }
    }
}
