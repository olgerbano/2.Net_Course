using System;
using System.Collections.Generic;

namespace Company
{
    abstract class Employee
    {
        private String name;
        private DateTime hireDate;
        private int salary;

        public abstract void Work();
        public abstract void AddSubordinate(Employee e);
        public abstract void RemoveSubordinate(Employee e);
        public abstract IList<Employee> Subordinates { get; }
        public abstract void Accept(IVisitor v);

        public String Name
        {
            get { return name; }
        }

        public DateTime HireDate
        {
            get { return hireDate; }
        }

        public int Salary
        {
            get { return salary; }
        }

        public Employee(String name, DateTime hireDate, int salary)
        {
            this.name = name;
            this.hireDate = hireDate;
            this.salary = salary;
        }
    }
}
