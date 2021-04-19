using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleIndexer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("**********Fun with Indexer***********");

            PersonCollection person = new PersonCollection();

            person["Homer"] = new Person("Homer", "simpson", 18);
            person["Marge"] = new Person("Marge", "Simson", 24);

            foreach (var item in person)
            {
                Console.WriteLine(item);
            }
        }
    }
}
