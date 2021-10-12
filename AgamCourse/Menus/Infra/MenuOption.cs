using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    public delegate void IOnSelect();

    class MenuOption
    {
        public string Message { get; }
        public IOnSelect OnSelect { get; }

        public MenuOption(string message, IOnSelect onSelect)
        {
            Message = message;
            OnSelect = onSelect;
        }
    }
}