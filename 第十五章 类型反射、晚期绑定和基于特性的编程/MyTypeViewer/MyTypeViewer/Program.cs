﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace MyTypeViewer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Welcome to MyTypeViewer ******");
            string typeName = "";
            do
            {
                Console.WriteLine("\nEnter a type Name to evaluate.");
                Console.WriteLine("or Enter Q to quit:");

                typeName = Console.ReadLine();

                if (typeName.ToUpper() == "Q") break;

                try
                {
                    Type t = Type.GetType(typeName);
                    Console.WriteLine("");
                    ListVariousStats(t);
                    ListProps(t);
                    ListFields(t);
                    ListMethods(t);
                    ListInterfaces(t);
                }
                catch
                {
                    Console.WriteLine("Sorry! can't find type.");
                }

            } while (true);
        }

        static void ListMethods(Type t)
        {
            Console.WriteLine("******Method********");
            //MethodInfo[] methods = t.GetMethods();
            //var methods = from n in t.GetMethods() select n.Name;
            /*  foreach (MethodInfo m in methods)
              {
                  string retVal = m.ReturnType.FullName;
                  string paramInfo = "(";
                  foreach (ParameterInfo pi in m.GetParameters())
                  {
                      paramInfo += string.Format("{0} {1}", pi.ParameterType, pi.Name);

                  }
                  paramInfo += ")";

                  Console.WriteLine("->{0} {1} {2}", retVal, m.Name, paramInfo);

              }*/

            //使用Linq实现
            var methods = from n in t.GetMethods() select n;
            foreach (var m in methods)
            {
                Console.WriteLine("-> {0}", m);
            }
            Console.WriteLine();
        }
        static void ListFields(Type t)
        {
            Console.WriteLine("*****Fields*****");
            var fieldNames = from f in t.GetFields() select f.Name;

            foreach (var name in fieldNames)
            {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }
        static void ListProps(Type t)
        {
            Console.WriteLine("******Properties********");
            var propNames = from p in t.GetProperties() select p.Name;
            foreach (var name in propNames)
            {
                Console.WriteLine("->{0}", name);
            }
            Console.WriteLine();
        }
        static void ListInterfaces(Type t) 
        {
            Console.WriteLine("*******Interfaces******");
            var ifaces = from i in t.GetInterfaces() select t;
            foreach (Type i in ifaces)
            {
                Console.WriteLine("->{0}", i.Name);
            }
        }
        static void ListVariousStats(Type t)
        {
            Console.WriteLine("*****Various Statistics*****");
            Console.WriteLine("Base class is:{0}", t.BaseType);
            Console.WriteLine("Is type abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is type sealed? {0}", t.IsSealed);
            Console.WriteLine("Is type generic? {0}", t.IsGenericTypeDefinition);
            Console.WriteLine("Is type class type? {0}", t.IsClass);
            Console.WriteLine();

        }
    }
}
