using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDelegate
{
    public delegate int BinaryOp(int x, int y);
    class SimpleMath
    {
        public static int Add(int a, int b) 
        {
            return a + b;
        }
        public static int Subtract(int x, int y) 
        {
            return x - y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            BinaryOp binaryOp = new BinaryOp(SimpleMath.Add);
            int a = binaryOp(1, 1);
            Console.WriteLine("委托调用的结果为：{0}", a);

            DisplayDelegateInfo(binaryOp);
        }
        static void DisplayDelegateInfo(Delegate delobj) 
        {
            foreach (Delegate del in delobj.GetInvocationList())
            {
                Console.WriteLine("Method Name:{0}", del.Method);
                Console.WriteLine("Targe Name:{0}", del.Target);
            }
        }
    }
}
