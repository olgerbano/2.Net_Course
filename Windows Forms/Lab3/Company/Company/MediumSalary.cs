using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class MediumSalary : IVisitor
    {
        private float mediumSalary = 0;
        private int nrEmployess = 0;



        public void Visit(Programmer p)
        {
            mediumSalary += p.Salary;
            nrEmployess++;
        }

        public void Visit(Manager m)
        {

            mediumSalary += m.Salary + m.Bonus;
            nrEmployess++;
            foreach (Employee e in m.Subordinates)
                e.Accept(this);
        }

        public float Salary 
        {
            get
            {
                if (nrEmployess == 0)
                    throw new InvalidOperationException("The visitor wasn't used");
                return mediumSalary / nrEmployess;
            }
        }
    }
}
