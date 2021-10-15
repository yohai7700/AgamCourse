using System;
using System.Collections.Generic;
using System.Text;

namespace AgamCourse.bl
{
    class EmployeeManager
    {
        List<Employee> _employees = new List<Employee>();

        public Employee[] Employees { get => _employees.ToArray(); }

        public void RegisterEmployee(Employee employee)
        {
            CovidCriteria.Validate(employee);
            _employees.Add(employee);
        }

        public void UnregisterEmployee(Employee employee)
        {
            _employees.Remove(employee);
        }
    }
}
