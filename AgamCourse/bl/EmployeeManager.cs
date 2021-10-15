using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.bl
{
    public class EmployeeManager
    {
        List<Employee> _employees = new List<Employee>();
        List<EmployeeFine> _fines = new List<EmployeeFine>();

        public Employee[] Employees { get => _employees.ToArray(); }
        public EmployeeFine[] EmployeeFines { get => _fines.ToArray(); }

        public void RegisterEmployee(Employee employee)
        {
            try
            {
                CovidCriteria.Validate(employee);
                _employees.Add(employee);
            }
            catch (CovidCriteriaException exception)
            {
                _fines.Add(new EmployeeFine(employee));
                throw exception;
            }
        }

        public void UnregisterEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }
    }

    public class EmployeeFine
    {
        Employee Employee { get; }

        public EmployeeFine(Employee employee)
        {
            Employee = employee;
        }
    }
}
