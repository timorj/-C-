using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomGenericMethods
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10, b = 2;
            Swap<int>(ref a, ref b);
            Console.WriteLine("a:{0}, b:{1}", a, b);

        }
        static void Swap<T>(ref T a, ref T b) 
        {
            Console.WriteLine("You sent the Swap() method a {0}", typeof(T));
            T temp = a;
            a = b;
            b = temp;
        }
    }
}
