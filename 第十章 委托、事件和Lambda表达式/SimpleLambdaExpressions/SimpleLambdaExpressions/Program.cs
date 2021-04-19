using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleLambdaExpressions
{
    class Program
    {
        static void Main(string[] args)
        {
            //TraditionalDelegateSyntax();
            LambdaExpressionSynatx();
        }
        static void TraditionalDelegateSyntax() 
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 3, 4, 8, 10 });

            /* Predicate<int> callBack = new Predicate<int>(IsEvenNumber);
             List<int> evenNumbers = list.FindAll(callBack);
 */
            //匿名方法：
            //List<int> evenNumbers = list.FindAll(delegate (int i) { return i % 2 == 0; });
           
            //Lambda 表达式
            List<int> evenNumbers = list.FindAll(i => (i % 2 == 0));

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        static void LambdaExpressionSynatx() 
        {
            List<int> list = new List<int>();
            list.AddRange(new int[] { 20, 1, 3, 4, 8, 10 });

            //Lambda 表达式
            List<int> evenNumbers = list.FindAll(i => 
            {
                Console.WriteLine("value of i is currently:{0}", i);
                bool isEven = ((i % 2) == 0);
                return isEven;
            });

            Console.WriteLine("Here are your even numbers:");
            foreach (int evenNumber in evenNumbers)
            {
                Console.Write("{0}\t", evenNumber);
            }
            Console.WriteLine();
            Console.ReadLine();
        }

        private static bool IsEvenNumber(int obj)
        {
            return (obj % 2 == 0);
        }
    }
}
