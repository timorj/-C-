using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleFileIO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Simple I/O with file Type *****\n");
            string[] myTasks = { "Fix bathroom sink", "Call Dave","Call Mom and Dad", "Play Xbox 360" };

            File.WriteAllLines("./Tasks.txt", myTasks);

            foreach (string task in File.ReadLines("./Tasks.txt"))
            {
                Console.WriteLine("TODO:{0}", task);
            }
            Console.ReadLine();
        }
    }
}
