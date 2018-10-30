using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Manager : Employee
    {
        private int bonus;
        private IList<Employee> subordinates = new List<Employee>();

        public int Bonus
        {
            get { return bonus; }
        }


        public override void Work()
        {
            Console.WriteLine(this.Name + " is managing");
            foreach (Employee e in subordinates)
                e.Work();
        }

        public override void AddSubordinate(Employee e)
        {
            if (!subordinates.Contains(e))
            {
                subordinates.Add(e);
            }
        }

        public override void RemoveSubordinate(Employee e)
        {
            if (subordinates.Contains(e))
                subordinates.Remove(e);
        }

        public override IList<Employee> Subordinates
        {
            get { return subordinates; }
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public Manager(String name, DateTime hireDate, int salary, int bonus) : base(name, hireDate, salary) 
        {
            this.bonus = bonus;
        }
    }
}
