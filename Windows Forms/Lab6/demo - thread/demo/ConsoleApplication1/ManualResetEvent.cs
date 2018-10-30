using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class ManualResetEvent
    {
        static EventWaitHandle wait = new EventWaitHandle(false, EventResetMode.ManualReset);

        static void Metoda()
        {
            wait.WaitOne();
            Console.WriteLine("checkpoint");
        }
        public static void Main(string[] args)
        {
            Thread thr1, thr2;
            thr1 = new Thread(Metoda);
            thr1.Start();
            thr2 = new Thread(Metoda);
            thr2.Start();

            Thread.Sleep(50);
            Console.WriteLine(thr1.ThreadState);
            wait.Set();
            // e posibil sa nu apuce sa schimbe starea, va afisa fie ca este in "Waiting", fie ca este in "Running"
            Console.WriteLine(thr1.ThreadState);
            // asteptam putin pentru ca el sa isi schimbe starea
            Thread.Sleep(50);
            Console.WriteLine(thr1.ThreadState);

            Console.ReadKey();
        }
    }
}
