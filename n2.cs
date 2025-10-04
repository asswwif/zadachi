using System;
using System.Collections.Generic;

namespace CompanyExample
{
    class Employee
    {
        public string Name { get; set; }
        public decimal Salary { get; set; }

        public Employee(string name, decimal salary)
        {
            Name = name;
            Salary = salary;
        }

        public virtual decimal CalculateBonus()
        {
            return Salary * 0.05m;
        }

        public override string ToString()
        {
            return $"{Name}, зарплата: {Salary} грн, бонус: {CalculateBonus()} грн";
        }
    }

    class Manager : Employee
    {
        public Manager(string name, decimal salary) : base(name, salary) { }

        public override decimal CalculateBonus()
        {
            return Salary * 0.15m;
        }
    }

    class Developer : Employee
    {
        public Developer(string name, decimal salary) : base(name, salary) { }

        public override decimal CalculateBonus()
        {
            return Salary * 0.10m;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>
            {
                new Manager("Олена", 30000),
                new Developer("Андрій", 25000),
                new Employee("Тимур (стажер)", 15000)
            };

            foreach (var emp in employees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
