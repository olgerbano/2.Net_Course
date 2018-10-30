using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Store s = new Store();
            Client c1 = new Client("Ana");
            Client c2 = new Client("Maria");
            Client c3 = new Client("Razvan");

            Magazine m1 = new Magazine("New York Times", 100);
            Magazine m2 = new Magazine("Tech Preview", 5);
            Magazine m3 = new Magazine("A long time ago", 20);

            c1.addWantedMagazine(m1);
            c1.addWantedMagazine(m2);
            c3.addWantedMagazine(m3);
            c2.addWantedMagazine(m3);
            c2.addWantedMagazine(m1);

            c1.Subscribe(s);
            c2.Subscribe(s);
            c3.Subscribe(s);

            s.Receive(m1, 1);
            s.Receive(m2, 10);
            s.Receive(m3, 3);

            Console.ReadKey();
        }
    }
}
