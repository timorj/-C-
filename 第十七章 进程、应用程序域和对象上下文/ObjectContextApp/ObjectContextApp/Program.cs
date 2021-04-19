using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.Remoting.Contexts;
using System.Threading;

namespace ObjectContextApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****fun with object context******\n");

            SportsCar sport = new SportsCar();
            Console.WriteLine();

            SportsCar sport2 = new SportsCar();
            Console.WriteLine();

            SportsCarTS synchroSport = new SportsCarTS();
            Console.WriteLine();

            Console.Read();
        }
    }


}
