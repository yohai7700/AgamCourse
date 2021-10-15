using System;
using System.Linq;
using AgamCourse.bl;

namespace AgamCourse.ui
{
    class EmployeeManagementMenu : InternalMenu
    {
        private static readonly string[] _options = new string[]
        {
            "Register",
            "Unregister",
        };
        EmployeeManager _manager;

        public EmployeeManagementMenu(EmployeeManager manager) : base(_options)
        {
            _manager = manager;
        }

        public override void OnOptionSelection(int option)
        {
            switch ((Option)option)
            {
                case Option.Register:
                    RunRegisterDialog();
                    break;
                case Option.Unregister:
                    RunUnregisterDialog();
                    break;
            }
        }

        private void RunRegisterDialog()
        {
            Console.Write("Please insert the employee's name: ");
            Employee employee = new Employee(Console.ReadLine().Trim());
            CovidSurvery.Update(employee);
            try
            {
                _manager.Register(employee);
                Console.WriteLine($"{employee.Name} was registered successfuly");
            }
            catch (CovidCriteriaException)
            {
                Console.WriteLine("The employee couldn't be registered due to COVID laws violation, a fine was registered.");
            }
        }

        private void RunUnregisterDialog()
        {
            var employees = _manager.Employees;
            if (employees.Length == 0)
            {
                Console.WriteLine("No employees are curretly registred.");
                return;
            }
            Console.WriteLine("Please choose an employee to register.");
            var employeeIndex = new Infra.OptionsDialog(employees.Select(employee => employee.Name).ToArray()).Render();
            var employee = employees[employeeIndex];
            _manager.Unregister(employee);
            Console.WriteLine("The employee was registered sucessfully");
        }

        private enum Option
        {
            Register = 1,
            Unregister,
        }
    }
}
