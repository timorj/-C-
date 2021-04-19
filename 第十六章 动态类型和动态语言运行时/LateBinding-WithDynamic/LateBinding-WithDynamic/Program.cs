using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace LateBinding_WithDynamic
{
    class Program
    {
        static void Main(string[] args)
        {
            AddWithReflection();
            AddWithDynamic();
            Console.Read();
        }
        static void AddWithReflection() 
        {
            try
            {
                Assembly asm = Assembly.Load("MathLibrary");

                Type mathType = asm.GetType("MathLibrary.SimpleMath");

                MethodInfo mi = mathType.GetMethod("Add");

                object obj = Activator.CreateInstance(mathType);

                object[] args = { 2, 2 };

                int result = (int)mi.Invoke(obj, args);

                Console.WriteLine("The Reflection result is:{0}", result);
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void AddWithDynamic()
        {
            try
            {
                Assembly asm = Assembly.Load("MathLibrary");

                Type math = asm.GetType("MathLibrary.SimpleMath");

                dynamic obj = Activator.CreateInstance(math);

                int result = obj.Add(2, 2);
                Console.WriteLine("dynamic result is:{0}", result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
