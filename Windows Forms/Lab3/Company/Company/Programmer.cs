using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Programmer : Employee
    {

        public override void Work()
        {
            Console.WriteLine(this.Name + " has started coding");
        }

        public override void AddSubordinate(Employee e)
        {
            throw new NotImplementedException();
        }

        public override void RemoveSubordinate(Employee e)
        {
            throw new NotImplementedException();
        }

        public override IList<Employee> Subordinates
        {
            get { return null; }
        }

        public override void Accept(IVisitor v)
        {
            v.Visit(this);
        }

        public Programmer(String name, DateTime hireDate, int salary) : base(name, hireDate, salary) { }
    }
}
