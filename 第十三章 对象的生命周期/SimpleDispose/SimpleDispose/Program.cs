using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDispose
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Fun with Dispose");
   
            using (MyResourceWrapper rw = new MyResourceWrapper())
            {

            }

            MyResourceWrapper rw2 = new MyResourceWrapper();
            Console.ReadLine();
        }
    }
    class MyResourceWrapper : IDisposable
    {
        private bool disposed = false;

        private void CleanUp(bool disposing)
        {
            if (!disposed)
            {
                if (disposing) 
                {
                    //释放托管资源
                }
                //清理非托管资源
                disposed = true;
            }
        }
        ~MyResourceWrapper()
        {
            Console.WriteLine("垃圾回收器回收");
            Console.Beep();
            CleanUp(false);
            
        }
        public void Dispose()
        {
            CleanUp(true);
            Console.WriteLine("*****In Dispose********");
            GC.SuppressFinalize(this);
        }
    }
}
