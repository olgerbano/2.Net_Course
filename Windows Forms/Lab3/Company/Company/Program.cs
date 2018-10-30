using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company
{
    class Program
    {
        static void Main(string[] args)
        {
            Employee director = new Manager("Ionescu Matei", new DateTime(2000, 5, 20), 5000, 500);
            Employee smallManager = new Manager("Popescu Mihai", new DateTime(2005, 6, 14), 3000, 200);
            director.AddSubordinate(smallManager);
            smallManager.AddSubordinate(new Programmer("Dinescu Cristian", new DateTime(2010, 10, 10), 2500));
            smallManager.AddSubordinate(new Programmer("Mircea Elena", new DateTime(2010, 8, 15), 2500));
            director.AddSubordinate(new Programmer("Marcu Silvia", new DateTime(2008, 3, 20), 2600));

            Console.WriteLine("Work day begins!");
            director.Work();

            Console.WriteLine();
            MediumSalary computeMediumSalary = new MediumSalary();
            director.Accept(computeMediumSalary);

            Console.WriteLine("The average salary in the company is: " + computeMediumSalary.Salary);
            Console.ReadKey();
        }
    }
}
