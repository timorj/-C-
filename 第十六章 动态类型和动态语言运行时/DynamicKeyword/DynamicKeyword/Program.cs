using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicKeyword
{
    class Program
    {
        static void Main(string[] args)
        {
            /*PrintThreeStrings();*/
            /*ChangeDynamicDataType();*/
            InvokeMembersOnDynamicData();
            Console.Read();
        }
        static void PrintThreeStrings()
        {
            var s1 = "Greeting";
            object s2 = "From";
            dynamic s3 = "Strings";

            Console.WriteLine("s1 is of type: {0}", s1.GetType());
            Console.WriteLine("s2 is of type: {0}", s2.GetType());
            Console.WriteLine("s3 is of type: {0}", s3.GetType());
        }
        static void ChangeDynamicDataType()
        {
            dynamic t = "Hello!";
            Console.WriteLine("t is of type: {0}", t.GetType());

            t = false;
            Console.WriteLine("t is of type:{0}", t.GetType());

            t = new List<int>();
            Console.WriteLine("t is of type:{0}", t.GetType());
        }
        static void InvokeMembersOnDynamicData()
        {
            dynamic textData1 = "hello!";

            try
            {
                Console.WriteLine(textData1.ToUpper());
                Console.WriteLine(textData1.toUpper());
            }
            catch (Microsoft.CSharp.RuntimeBinder.RuntimeBinderException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
    class VeryDynamicClass
    {
        private static dynamic myDynamicField;

        public dynamic DynamicProperty { get; set; }

        public dynamic DynamicMethod(dynamic dynamicParam)
        {
            dynamic dynamicLocalVar = "Local Variable";

            int myInt = 10;
            if (dynamicParam is int)
            {
                return dynamicLocalVar;
            }
            else
            {
                return myInt;
            }
        }
    }
}
