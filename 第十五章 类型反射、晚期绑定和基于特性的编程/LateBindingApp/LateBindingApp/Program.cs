using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Reflection;

namespace LateBindingApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with late binding****");
            Assembly a = null;
            try
            {
                a = Assembly.Load("CarLibrary");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            if (a != null)
                //CreateUsingLateBinding(a);
            InvokeMethodWithArgsUsingLateBinding(a);
            Console.ReadLine();
        }
        static void CreateUsingLateBinding(Assembly asm)
        {
            try
            {
                Type miniVan = asm.GetType("CarLibrary.MiniVan");

                object obj = Activator.CreateInstance(miniVan);
                Console.WriteLine("Create a {0} using late binding!", obj);

                MethodInfo mi = miniVan.GetMethod("TurboBoost");

                mi.Invoke(obj, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        static void InvokeMethodWithArgsUsingLateBinding(Assembly asm)
        {
            try
            {
                Type t = asm.GetType("CarLibrary.SportsCar");

                object obj = Activator.CreateInstance(t);
                Console.WriteLine("Create a {0} using late binding!", obj);

                MethodInfo mi = t.GetMethod("TurnOnRadio");

                mi.Invoke(obj, new object[] { true, 2 });
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
