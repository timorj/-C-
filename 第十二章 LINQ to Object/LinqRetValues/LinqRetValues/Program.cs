using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqRetValues
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine( "*****Linq Transformations*****");
            var subset = GetStringSubset();
            foreach (var item in subset)
            {
                Console.WriteLine(item);
            }
            Console.ReadLine();
        }

        static string[] GetStringSubset() 
        {
            string[] colors = { "Light Red", "Green", "Yellow", "Dark Red", "Red", "Purple" };
            var theRedColor = from i in colors where i.Contains("Red") select i;
            return theRedColor.ToArray();
        } 
    
    }
    
}
