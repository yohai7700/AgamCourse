using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.Menus.Infra
{
    class OptionsDialog
    {
        string[] _options;
        public OptionsDialog(string[] options)
        {
            _options = options;
        }

        /// <summary>
        /// Displays the options and reads a selected option.
        /// </summary>
        /// <returns>index of selected option</returns>
        public int Render()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {_options[i]}");
            }
            return ReadOptionSelection() - 1;
        }

        private int ReadOptionSelection()
        {
            int selection;
            do
            {
                selection = Menu.ReadNumber();
            } while (!(1 <= selection && selection <= _options.Length));
            return selection;
        }
    }
}
