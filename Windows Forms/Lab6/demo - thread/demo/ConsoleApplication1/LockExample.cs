using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class LockExample
    {
        static int[] vector = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };
        static int aux;
        static string str = "abc";

        static void Metoda1a()
        {
            lock (str)
                for (int i = 0; i < vector.Length; i++)
                {
                    aux = vector[i];
                    //int aux = vector[i];
                    Thread.Sleep(10);
                    vector[i] = aux + 1;
                }
        }
        static void Metoda1b()
        {
            lock (new String(str.ToArray()))
                //lock (str)
                for (int i = vector.Length - 1; i >= 0; i--)
                {
                    aux = vector[i];
                    //int aux = vector[i];
                    Thread.Sleep(10);
                    vector[i] = aux + 1;
                }
        }

        public static void Main()
        {
            Thread thr1 = new Thread(Metoda1a);
            Thread thr2 = new Thread(Metoda1b);
            thr1.Start();
            thr2.Start();

            while (thr1.ThreadState != ThreadState.Stopped || thr2.ThreadState != ThreadState.Stopped)
                Thread.Sleep(100);
            foreach (int i in vector)
                Console.Write(i + " ");
            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
