using System;
using System.Threading;

namespace lab2netprog
{
    class Program
    {
        static AutoResetEvent waitHandler = new AutoResetEvent(false);
        static AutoResetEvent waitMainHandler = new AutoResetEvent(false);

        static Thread secondTh;
        static Thread thirdTh;
         public static void SecondThread()
         {
            Console.WriteLine("Second thread starts");
            waitHandler.WaitOne();
            Console.WriteLine("Third thread joined to the second");
            Thread.Sleep(5000);
            Thread fifthTh = new Thread((() => Console.WriteLine("Fifth thread starts")));
            Thread sixthTH = new Thread((() => Console.WriteLine("Sixth thread starts" )));
            fifthTh.Start();
            sixthTH.Start();
        }
        public static void ThirdThread()
        {
            Console.WriteLine("Third thread starts");
            waitHandler.Set();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------");
            Thread th = Thread.CurrentThread;
            th.Name = "first thread";
            Console.WriteLine("This is {0}", th.Name);
            Thread.Sleep(5000);
            secondTh = new Thread(() => SecondThread());
            thirdTh = new Thread(() => ThirdThread());
            secondTh.Start();
            thirdTh.Start();
        }
    }
}
