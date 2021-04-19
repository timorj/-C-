using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadStatus
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Primary Thread status ****\n");

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "ThePrimaryThread";

            Console.WriteLine("Name of current Appdomain:{0}", Thread.GetDomain().FriendlyName);
            Console.WriteLine("ID of current Context:{0}", Thread.CurrentContext.ContextID);

            Console.WriteLine("Thread Name :{0}", primaryThread.Name);
            Console.WriteLine("Has Thread Started?:{0}", primaryThread.IsAlive);
            Console.WriteLine("Priority Level:{0}", primaryThread.Priority);
            Console.WriteLine("Thread state :{0}", primaryThread.ThreadState);
            Console.Read();
        }
    }
}
