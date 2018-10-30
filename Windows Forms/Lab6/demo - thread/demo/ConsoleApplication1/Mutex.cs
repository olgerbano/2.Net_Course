using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class MutexSemafor
    {
        static Mutex mutex = new Mutex();
        static Semaphore semaphore = new Semaphore(2, 2);
        static int val = 0;
        static void PrintSpace()
        {
            Thread.Sleep(50);
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine();
                Thread.Sleep(1050);
            }
        }
        static void Metoda()
        {
            int thrid = ++val;
            //Thread.Sleep(50);
            Console.WriteLine("Thread {0} in method", thrid);
            mutex.WaitOne();
            //semaphore.WaitOne();
            {
                Console.WriteLine("Metoda{0} lock", thrid);
                Thread.Sleep(1000);
                Console.WriteLine("Metoda{0} release", thrid);
            }
            mutex.ReleaseMutex();
            //semaphore.Release();
        }
        public static void Main()
        {
            //Thread thr1 = new Thread(Metoda);
            Thread thr1 = new Thread(PrintSpace);
            thr1.Start();
            Thread[] thrds = new Thread[4];
            for (int i = 0; i < thrds.Length; i++)
                thrds[i] = new Thread(Metoda);
            foreach (Thread thr in thrds)
                thr.Start();

            Thread.Sleep(50);
            mutex.WaitOne();
            //semaphore.WaitOne();
            {
                Console.WriteLine("Main lock");
                Thread.Sleep(1000);
                Console.WriteLine("Main release");
            }
            mutex.ReleaseMutex();
            //semaphore.Release();

            Console.ReadKey();
        }
    }
}
