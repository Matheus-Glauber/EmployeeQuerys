using System;
using System.Collections.Generic;
using System.Text;

namespace Modulo17.entities
{
    class Employee
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public double Salary { get; set; }

        public Employee(string name, string email, double salary)
        {
            Name = name;
            Email = email;
            Salary = salary;
        }

        public override bool Equals(object obj)
        {
            return obj is Employee employee &&
                   Name == employee.Name &&
                   Email == employee.Email &&
                   Salary == employee.Salary;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Email, Salary);
        }
    }
}
