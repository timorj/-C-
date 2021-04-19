using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
namespace DefaultAppDomainApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitDAD();
            //DisplayDADStatus();
            ListAllAssembliesInAppDomain();
            
            Console.Read();
        }
        static void DisplayDADStatus()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            Console.WriteLine("Name of the domain:{0}", defaultAD.FriendlyName);
            Console.WriteLine("ID of domain in the process:{0}", defaultAD.Id);
            Console.WriteLine("Is this the default domain?:{0}", defaultAD.IsDefaultAppDomain().ToString());
            Console.WriteLine("Base Directory of this domain:{0}", defaultAD.BaseDirectory);
        }
        static void ListAllAssembliesInAppDomain()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            Assembly[] loadedAssemblies = (from a in defaultAD.GetAssemblies() orderby a.GetName().Name select a).ToArray();

            Console.WriteLine("****Here are the assemblies loaded in {0} *****\n", defaultAD.FriendlyName);
            foreach (Assembly asm in loadedAssemblies)
            {
                Console.WriteLine("-> Name:{0}", asm.GetName().Name);
                Console.WriteLine("-> Version:{0}", asm.GetName().Version);
            }

        }
        static void InitDAD()
        {
            AppDomain defaultAD = AppDomain.CurrentDomain;

            defaultAD.AssemblyLoad += new AssemblyLoadEventHandler((sender, e) => 
            {
                Console.WriteLine("{0} has been loaded!", e.LoadedAssembly.GetName().Name);
            });
        }
    }
}
