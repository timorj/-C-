using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDelegate
{
    public delegate void MyGenericDelegate<T>(T arg);
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with GenericDelegate*******");

            MyGenericDelegate<string> stringHandler = new MyGenericDelegate<string>(StringTarget);

            stringHandler("i love you!");

            MyGenericDelegate<int> intHandler = new MyGenericDelegate<int>(IntTarget);

            intHandler(23);

        }

        static void StringTarget(string arg) 
        {
            Console.WriteLine("=> arg in Upper is:{0}", arg.ToUpper());
        }
        static void IntTarget(int arg) 
        {
            Console.WriteLine("++arg is {0}", ++arg);
        }
    }
}
