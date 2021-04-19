using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqOverStrings
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Fun with linq to object******\n");
            //QueryOverStrings();
            QueryOverInts();
            Console.ReadLine();
        }
        static void QueryOverStrings()
        {
            string[] currentVideoGames =
            {
                "Morrowind", "Uncharted 2","Fallout 3","Daxter", "System Shock 2"
            };
            IEnumerable<string> SubSet = from g in currentVideoGames where g.Contains(" ") orderby g select g;

            foreach (var item in SubSet)
            {
                Console.WriteLine(item);
            }
            ReflectOverQueryResults(SubSet);
        }
        static void ReflectOverQueryResults(object resultObject) 
        {
            Console.WriteLine("********Info about query*******");
            Console.WriteLine("result is of type:{0}", resultObject.GetType().Name);
            Console.WriteLine("result location;:{0}", resultObject.GetType().Assembly.GetName().Name);
        }
        static void QueryOverInts()
        {
            int[] numbers = new int[] { 10, 20, 30, 40, 1,2,3,8 };

            var subSet = from i in numbers where i < 10 select i;
            foreach (var i in subSet)
            {
                Console.WriteLine("Item:{0}", i);
            }
            Console.WriteLine();
            numbers[0] = 4;

            foreach (var j in subSet)
            {
                Console.WriteLine("{0} < 10", j);
            }

            ReflectOverQueryResults(subSet);
        }
    }
}
