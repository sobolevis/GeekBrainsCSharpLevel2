using System.Collections.Generic;

namespace Lesson5
{
    class Department
    {
        public List<Employee> Employees;
        public string Name { get; }

        public Department(string name)
        {
            Name = name;
            Employees = new List<Employee>();
        }
    }
}
