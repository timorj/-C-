﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Reflection;
using System.IO;

namespace ExternalAssemblyReflector
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******External Assembly Viewer*******");

            string asmName = "";
            Assembly asm = null;
            do
            {
                Console.WriteLine("\n Enter an assembly to evaluate");
                Console.WriteLine("or enter Q to quit:");

                asmName = Console.ReadLine();

                if (asmName.ToUpper() == "Q")
                {
                    break;
                }
                try
                { 
                    asm = Assembly.Load(asmName);
                    DisplayTypesInAsm(asm);
                }
                catch 
                {
                    Console.WriteLine("Sorry, can't find assembly.");
                }

            } while (true);
        }
        static void DisplayTypesInAsm(Assembly asm)
        {
            Console.WriteLine("\n****Types in assembly**** ");
            Console.WriteLine("->{0}", asm.FullName);
            Type[] types = asm.GetTypes();

            foreach (Type t in types)
            {
                Console.WriteLine("Type:{0}", t);
            }
            Console.WriteLine();
        }
    }
}
