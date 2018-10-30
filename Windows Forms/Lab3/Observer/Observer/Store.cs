using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Observer
{
    internal class Store : IObservable<Magazine>
    {
        private delegate void MagazineReceived(Magazine m);
        private event MagazineReceived receiving;
        private IDictionary<Magazine, int> stock = new Dictionary<Magazine, int>();


        public IDisposable Subscribe(IObserver<Magazine> observer)
        {

            MagazineReceived m = new MagazineReceived(observer.OnNext);
            if ((receiving == null) ||
                (receiving != null &&
                 !receiving.GetInvocationList().Any((Delegate x) => x.Target == m.Target)))
            {
                receiving += m;
                return new Unsubscriber(this, m);
            }

            return null;
        }

        private class Unsubscriber : IDisposable
        {
            private Store store;
            private MagazineReceived handler;

            public Unsubscriber(Store store, MagazineReceived handler)
            {
                this.store = store;
                this.handler = handler;
            }
            public void Dispose()
            {
                if (store.receiving != null && store.receiving.GetInvocationList().Any((Delegate x) => handler.Target == x.Target)) {
                    store.receiving -= handler;
                }
            }
        }

        public void Receive(Magazine m, int quantity)
        {
            // Add "quantity" m Magazines to stock
            Console.WriteLine("Receiving" + quantity + " magazine(s) " + m.Name + " number " + m.No);
            if (stock.Keys.Contains(m))
            {
                stock[m] = stock[m] + quantity;
            }
            else
            {
                stock.Add(m, quantity);
            }

            receiving?.Invoke(m);
        }

        public bool Buy(Magazine m, int quantity)
        {
            if(stock.Keys.Contains(m) && stock[m] >= quantity) {
                stock[m] = stock[m] - quantity;
                return true;
            }
            return false;
        }

    }
}
