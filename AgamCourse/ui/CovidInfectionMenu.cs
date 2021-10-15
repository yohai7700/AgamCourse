using System.Linq;
using System;
using AgamCourse.bl;

namespace AgamCourse.ui
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
            var infectedPerson = ReadInfectedPerson(possibleInfectedPeople);
            var infectionTargets = _infectionChecker.FindInfectedPeople(infectedPerson);
            PrintInfectedPeople(infectionTargets);
        }

        private static void PrintInfectedPeople(Person[] infectedPeople)
        {
            Console.WriteLine($"{infectedPeople.Length} people were infected.");
            foreach (var person in infectedPeople)
            {
                Console.WriteLine($"* {FormatPersonString(person)}");
            }
        }

        private static Person ReadInfectedPerson(Person[] options)
        {
            var infectedIndex = new Infra.OptionsDialog(options.Select(FormatPersonString).ToArray()).Render();
            return options[infectedIndex];
        }

        private static string FormatPersonString(Person person)
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

            return $"{person.Name} - {type}";
        }
    }
}
