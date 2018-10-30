using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ConsoleApplication1
{
    class TimerExample
    {
        static void Method(object state)
        {
            Console.WriteLine("Hello");
        }
        static void Main()
        {
            Timer timer = new Timer(new TimerCallback(Method),null,0,200);

            Thread.Sleep(2000);
            timer.Change(0, 500);
            Console.WriteLine();
            Thread.Sleep(2000);
            timer.Change(Timeout.Infinite, Timeout.Infinite);
            timer.Dispose();

            Console.ReadKey();
        }
    }
}
