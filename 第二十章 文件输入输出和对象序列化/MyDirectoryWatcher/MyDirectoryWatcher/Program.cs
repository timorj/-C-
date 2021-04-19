using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDirectoryWatcher
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******The Amazing File Watcher *******\n");

            DirectoryInfo dir = Directory.CreateDirectory("./MyFolder");
            FileSystemWatcher watcher = new FileSystemWatcher();

            try
            {
                watcher.Path = dir.FullName;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
                return;
            }
            watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite | NotifyFilters.FileName | NotifyFilters.DirectoryName;

            watcher.Filter = "*.txt";
            watcher.Changed += (sender, e) => 
            {
                Console.WriteLine("File:{0}{1}!", e.FullPath, e.ChangeType);
            };
            watcher.Created += (sender, e) =>
            {
                Console.WriteLine("File:{0}{1}!", e.FullPath, e.ChangeType);
            };
            watcher.Deleted += (sender, e) =>
            {
                Console.WriteLine("File:{0}{1}!", e.FullPath, e.ChangeType);
            };
            watcher.Renamed += (sender, e) =>
            {
                Console.WriteLine("File:{0} renamed to {1}", e.OldFullPath, e.FullPath);
            };
            watcher.EnableRaisingEvents = true;

            Console.WriteLine(@"Press 'q' to quit app");
            while (Console.Read() != 'q') ;
        }
    }
}
