using System;
using System.Collections.Generic;
using System.Text;
using AgamCourse.bl;

namespace AgamCourse.Menus
{
    public class CovidInfectionMenu : InternalMenu
    {
        private enum Option
        {
            CheckInfection = 1,
        }
        private static readonly string[] _options = new string[] { "Check for infection" };

        CovidInfectionChecker _infectionChecker;
        public CovidInfectionMenu(CovidInfectionChecker infectionChecker) : base(_options)
        {
            _infectionChecker = infectionChecker;
        }

        public override void OnOptionSelection(int option)
        {
            switch ((Option)option)
            {
                case Option.CheckInfection:
                    CheckInfection();
                    break;
            }
        }

        private void CheckInfection()
        {
            var possibleInfectedPeople = _infectionChecker.AllPossibleInfectedPeople;
            for (int i = 0; i < possibleInfectedPeople.Length; i++)
            {
                PrintPerson(i + 1, possibleInfectedPeople[i]);
            }
        }

        private static void PrintPerson(int number, Person person)
        {
            string type = "Person";
            if (person is Costumer)
            {
                type = "Costumer";
            }
            else if (person is Employee)
            {
                type = "Employee";
            }

            Console.WriteLine($"{number}. {person.Name} - {type}");
        }
    }
}
