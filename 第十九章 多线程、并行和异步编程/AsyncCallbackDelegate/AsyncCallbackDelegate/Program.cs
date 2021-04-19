using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncCallbackDelegate
{
    public delegate int BinaryOp(int x, int y);
    class Program
    {
        private static bool isDone = false;

        static void Main(string[] args)
        {
            Console.WriteLine("******AsyncCallbackDelegate example ***********");
            Console.WriteLine("Main() invoked on thread:{0}", Thread.CurrentThread.ManagedThreadId);

            BinaryOp b = new BinaryOp(Add);

            b.BeginInvoke(10, 10, AddComplete, "Main() thanks you for adding these numbers");

            while (!isDone)
            {
                Thread.Sleep(1000);
                Console.WriteLine("Working......");
            }

            Console.ReadLine();
        }
        static int Add(int x, int y)
        {
            Console.WriteLine("Add() invoked on Thread:{0}", Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(5000);

            return x + y;
        }

        //在回调方法中获取BinaryOp的引用
        static void AddComplete(IAsyncResult asyncResult)
        {
            Console.WriteLine("AddComplete() invoked on thread:{0}", Thread.CurrentThread.ManagedThreadId);
            Console.WriteLine("Your addition is complete");
            
            
            AsyncResult ar = (AsyncResult)asyncResult;
            string msg = (string)ar.AsyncState;

            Console.WriteLine(msg);
     
            BinaryOp b = (BinaryOp)ar.AsyncDelegate;
            Console.WriteLine("10 + 10 is {0}", b.EndInvoke(ar));
            isDone = true;
        }
        
    }
    
}
