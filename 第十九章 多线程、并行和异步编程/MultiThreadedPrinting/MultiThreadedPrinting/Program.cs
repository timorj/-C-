using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MultiThreadedPrinting
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Synchronizing Threads *****\n");

            Printer p = new Printer();

            /*Thread[] threads = new Thread[10];
            for (int i = 0; i < threads.Length; i++)
            {
                threads[i] = new Thread(p.PrintNumbers);
                threads[i].Name = string.Format("Worker thread #{0}", i);
            }
            foreach (var item in threads)
            {
                item.Start();
            }*/

            WaitCallback workItem = new WaitCallback(PrintNumbers);

            for (int i = 0; i < 10; i++)
            {
                ThreadPool.QueueUserWorkItem(workItem, p);
            }
            Console.WriteLine("All tasks queued");
            Console.ReadLine();
            Console.ReadLine();
        }
        //使用线程池来创建线程
        static void PrintNumbers(object state)
        {
            Printer printer = (Printer) state;
            printer.PrintNumbers();
        }
    }
    class Printer
    {
        private object threadLock = new object();
        public void PrintNumbers()
        {
            lock (threadLock)
            {
                Console.WriteLine("->{0} is executing PrintNumbers()", Thread.CurrentThread.Name);

                Console.WriteLine("Your numbers:");

                for (int i = 0; i < 10; i++)
                {
                    Random r = new Random();
                    Thread.Sleep(1000 * r.Next(5));
                    Console.Write("{0},", i);
                }
                Console.WriteLine();
            }
        }
    }
}
