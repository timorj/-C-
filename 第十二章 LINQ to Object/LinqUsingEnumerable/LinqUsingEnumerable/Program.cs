using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqUsingEnumerable
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryStringWithEnumerableAndLambdas();
            Console.Read();
        }
        static void QueryStringWithOperator() 
        {
            Console.WriteLine("*******Using query operator*****");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 2", "Daxter", "System Shock 2" };

            var subset = from game in currentVideoGames where game.Contains(" ") orderby game select game;

            foreach (var item in subset)
            {
                Console.WriteLine("item:{0}", item);
            }
        }
        static void QueryStringWithEnumerableAndLambdas()
        {
            Console.WriteLine("*****using Enumerable / lambda expressions********");

            string[] currentVideoGames = { "Morrowind", "Uncharted 2", "Fallout 2", "Daxter", "System Shock 2" };

            var subset = currentVideoGames.Where(game => game.Contains(" ")).OrderBy(game => game).Select(game => game);

            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }

        }
    }
}
