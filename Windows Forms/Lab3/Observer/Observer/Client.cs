using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer
{
    class Client : IObserver<Magazine>
    {
        IDisposable unsubscriber = null;
        Store store = null;
        IList<Magazine> wantedMagazines = new List<Magazine>();
        private string name;

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }


        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(Magazine m)
        {
            //Am fost informat ca magazinul a primit reviste
            if (wantedMagazines.Contains(m) && store != null && store.Buy(m, 1))
            {
                Console.WriteLine(this.Name + ": Am cumparat revista " + m.Name + " numarul " + m.No);
            }
        }

        public void addWantedMagazine(Magazine m)
        {
            wantedMagazines.Add(m);
        }

        public void Subscribe(Store s)
        {
            //Daca suntem abonati la un alt magazin, intai ne dezabonam de la acesta
            if (store != null)
            {
                Unsubscribe();
            }

            //Ne abonam la noul magazin
            unsubscriber = s.Subscribe(this);
            if (unsubscriber != null)
            {
                store = s;
            }
        }

        public void Unsubscribe()
        {
            if (store != null)
            {
                unsubscriber.Dispose();
            }
            store = null;
            unsubscriber = null;
        }

        public Client(String name)
        {
            this.name = name;
        }

        public String Name
        {
            get { return name; }
        }
    }
}
