using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAppDomain
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Custom AppDomains*********\n");

            AppDomain defaultAD = AppDomain.CurrentDomain;
            ListAllAssembliesInAppDomain(defaultAD);

            defaultAD.DomainUnload += (sender, e) => 
            {
                Console.WriteLine("Default AD unloaded!");
            };

            MakeNewAppDomain();

            Console.ReadLine();
        }

        private static void MakeNewAppDomain()
        {
            AppDomain newAD = AppDomain.CreateDomain("SecondAppDomain");
            newAD.DomainUnload += (sender, e) => 
            {
                Console.WriteLine("newAD has been unloaded!");
            };
            try
            {
                newAD.Load("CarLibrary");
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message);
            }
            ListAllAssembliesInAppDomain(newAD);

            AppDomain.Unload(newAD);

        }
        static void ListAllAssembliesInAppDomain(AppDomain ad)
        {
            var loadedAssemblies = from a in ad.GetAssemblies() orderby a.GetName().Name select a;

            Console.WriteLine("Here are the assemblies loaded in {0}\n", ad.FriendlyName);

            foreach (var a in loadedAssemblies)
            {
                Console.WriteLine("-> Name:{0}", a.GetName().Name);
                Console.WriteLine("-> Version:{0}", a.GetName().Version);
            }
        }
    }
}
