using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;

namespace AddWithThreads
{
    class Program
    {
        private static AutoResetEvent waitHandle = new AutoResetEvent(false);
        static void Main(string[] args)
        {
            Console.WriteLine("****Adding with Thread objects ******");
            Console.WriteLine("ID of Thread in Main():{0}", Thread.CurrentThread.ManagedThreadId);

            /*AddParams ap = new AddParams(10, 10);

            Thread t = new Thread(new ParameterizedThreadStart(Add));
            t.Start(ap);

           
            waitHandle.WaitOne();
            Console.WriteLine("Other thread is done!");*/

            //不用Await则还是以同步的方式运行程序
             AddAsync();

            Console.ReadLine();

        }
        static void Add(object data)
        {
            if(data is AddParams)
            {
                Console.WriteLine("ID of thread in Add():{0}", Thread.CurrentThread.ManagedThreadId);

                AddParams ap = (AddParams)data;
                Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
                waitHandle.Set();
            }
        }
        static async Task AddAsync()
        {
            Console.WriteLine("********Adding with Thread objects ********");
            Console.WriteLine("ID of thread in main():{0}", Thread.CurrentThread.ManagedThreadId);

            AddParams ap = new AddParams(10, 10);
            await Sum(ap);
            Console.WriteLine("Other thread have done!");

        }
        static async Task Sum(object data)
        {
            await Task.Run(() => 
            {
                if(data is AddParams)
                {
                    Console.WriteLine("ID of thread in Add() :{0}", Thread.CurrentThread.ManagedThreadId);

                    AddParams ap = (AddParams)data;
                    Console.WriteLine("{0} + {1} is {2}", ap.a, ap.b, ap.a + ap.b);
                }
            });
        }
    }
    class AddParams
    {
        public int a, b;
        public AddParams(int num1, int num2)
        {
            a = num1;
            b = num2;
        }
    }
}
