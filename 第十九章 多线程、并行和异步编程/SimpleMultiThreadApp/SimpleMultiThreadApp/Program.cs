using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Threading;
using System.Windows.Forms;

namespace SimpleMultiThreadApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********The Amazing Thread App *******");
            Console.WriteLine("Do you want [1] or [2] threads?");
            string threadCount = Console.ReadLine();

            Thread primaryThread = Thread.CurrentThread;
            primaryThread.Name = "Primary";

            Console.WriteLine("->{0} is executing Main()", Thread.CurrentThread.Name);

            Printer printer = new Printer();
            switch (threadCount)
            {
                case "2":
                    Thread backgroundThread = new Thread(new ThreadStart(printer.PrintNumbers));
                    backgroundThread.Name = "Secondary";
                    backgroundThread.Start();
                    break;
                case "1":
                    printer.PrintNumbers();
                    break;
                default:
                    Console.WriteLine("I don't know what you want... you get 1 thread.");
                    break;
            }
            MessageBox.Show("I'm busy", "Work on main Thread.");
            Console.ReadLine();

        }
    }
    class Printer
    {
        public void PrintNumbers()
        {
            Console.WriteLine("->{0} is executing PrintNumbers()", Thread.CurrentThread.Name);

            Console.WriteLine("Your numbers:");

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("{0},", i);
                Thread.Sleep(1000);
            }
            Console.WriteLine();
            
        }
    }
}
