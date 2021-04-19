using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace SyncDelegateReview
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******* Synch Delegate Review******");

            Console.WriteLine("Main() Invoked on thread:{0}", Thread.CurrentThread.ManagedThreadId);
            BinaryOp b = new BinaryOp(Add);

            IAsyncResult iftAR = b.BeginInvoke(10, 10, null, null);

            while (!iftAR.AsyncWaitHandle.WaitOne(1000, true))
            {
                Console.WriteLine("Doing more work in main()!");
            }
            int answer = b.EndInvoke(iftAR);
            Console.WriteLine("10 + 10 is {0}", answer);
            Console.ReadLine();


        }
        static int Add(int x, int y)
        {
            Console.WriteLine("Add() Invoked on thread: {0}.", Thread.CurrentThread.ManagedThreadId);

            Thread.Sleep(5000);
            return x + y;

        }
    }
}
