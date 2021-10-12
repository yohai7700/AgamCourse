using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse
{
    abstract class Menu
    {
        public string[] Options { get; }

        private bool _finished = false;
        private bool Internal { get; }

        public Menu(string[] options, bool _internal)
        {
            Options = _internal ? GetOptionsWithBack(options) : options;
            Internal = _internal;
        }

        private static string[] GetOptionsWithBack(string[] options)
        {
            var temp = new string[options.Length + 1];
            options.CopyTo(temp, 0);
            temp[options.Length] = "Back";
            return temp;
        }

        public virtual void Run()
        {
            while (!_finished) Display();
        }

        protected virtual void PrintOptions()
        {
            Console.WriteLine("Hello, please choose one of the following options (enter the option's number): ");
            for (int i = 0; i < Options.Length; i++)
            {
                PrintOption(i + 1, Options[i]);
            }
        }

        private void PrintOption(int index, string message)
        {
            Console.WriteLine($"{index}. {message}.");
        }

        protected void Finish()
        {
            _finished = true;
        }

        public void Display()
        {
            PrintOptions();
            var selectedOption = ReadOptionSelect();
            if(Internal && selectedOption == Options.Length)
            {
                Finish();
            }
            else OnOptionSelection(selectedOption);
        }

        private int ReadOptionSelect()
        {
            int selection;
            do
            {
                selection = ReadNumber();
            } while (!(1 <= selection && selection <= Options.Length));
            return selection;
        }

        public abstract void OnOptionSelection(int option);

        public static int ReadNumber()
        {
            int number;
            bool isValid;
            do
            {
                isValid = Int32.TryParse(Console.ReadLine(), out number);
            } while (!isValid);
            return number;
        }

        public static float ReadFloat()
        {
            float number;
            bool isValid;
            do
            {
                isValid = float.TryParse(Console.ReadLine(), out number);
            } while (!isValid);
            return number;
        }

        public static bool ReadBool()
        {
            string answer;
            do
            {
                answer = Console.ReadLine();
            } while (!("Y".Equals(answer) || "N".Equals(answer)));
            return "Y".Equals(answer);
        }
    }
}
