using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarLibrary;
namespace CSharpCarClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****C# Carlibrary Client App*****");
            SportsCar sportsCar = new SportsCar("Viper", 240,40);
            sportsCar.TurboBoost();

            MiniVan mv = new MiniVan();

            mv.TurboBoost();

            Console.WriteLine("Done. Press any key to terminate");
            Console.ReadLine();

        }
    }
}
