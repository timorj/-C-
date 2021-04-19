using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ProcessManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            //ListAllRunningProcesses();
            //GetSpecificProcess();

            //EnumThreadsForPid(15308);
            //EnumModsForPid(15308);
            StartAndKillProcess();
            Console.Read();
        }

        static void ListAllRunningProcesses()
        {
            var runningProcs = from proc in Process.GetProcesses(".") orderby proc.Id select proc;

            foreach (var p in runningProcs)
            {
                Console.WriteLine("->PID:{0}\tName:{1}", p.Id, p.ProcessName);
            }
            Console.WriteLine("**************");
        }
        static void GetSpecificProcess()
        {
            Process theProcs = null;

            try
            {
                theProcs = Process.GetProcessById(1000);
                Console.WriteLine("-> PID:{0}\tName:{1}", theProcs.Id, theProcs.ProcessName);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }

        }
        static void EnumThreadsForPid(int pID)
        {
            Process procs = null;
            try
            {
                procs = Process.GetProcessById(pID);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }

            Console.WriteLine("Here are the threads used by: {0}", procs.ProcessName);
            ProcessThreadCollection theThreads = procs.Threads;

            foreach (ProcessThread pt in theThreads)
            {
                string info = string.Format("-> Thread ID:{0}\t Start Time: {1}\t Priority:{2}", pt.Id, pt.StartTime.ToShortTimeString(), pt.PriorityLevel);
                Console.WriteLine(info);
            }

            Console.WriteLine("*******************\n");
        }
        static void EnumModsForPid(int pID)
        {
            Process theProc = null;
            try
            {
                theProc = Process.GetProcessById(pID);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            Console.WriteLine("Here are the loaded modules for:{0}", theProc.ProcessName);

            ProcessModuleCollection theMods = theProc.Modules;

            foreach (ProcessModule pm in theMods)
            {
                string info = string.Format("-> Mod Name:{0}", pm.ModuleName);
                Console.WriteLine(info);
            }
            Console.WriteLine("******************************");

        }
        static void StartAndKillProcess()
        {
            Process ieProcs = null;

            try
            {
                ProcessStartInfo startInfo = new ProcessStartInfo("msedge.exe", "www.baidu.com");
                startInfo.WindowStyle = ProcessWindowStyle.Normal;
                ieProcs = Process.Start(startInfo);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            Console.WriteLine("-> Hit enter to kill {0}....", ieProcs.ProcessName);

            Console.ReadLine();

            try
            {
                ieProcs.Kill();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
