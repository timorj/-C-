using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Extending interface  compatible types *******");

            string[] data = { "wow", "this", "is", "sort", "of", "annoying" };
            data.PrintDataAndBeep();

            Console.WriteLine();
            List<int> myInts = new List<int>() { 1, 2, 3 };
            myInts.PrintDataAndBeep();

            Console.Read();
        }
    }
    static class AnnoyingExtensions 
    {
        public static void PrintDataAndBeep(this System.Collections.IEnumerable iterator) 
        {
            foreach (var item in iterator)
            {
                Console.WriteLine(item);
                Console.Beep();
            }
        }
    }
}
