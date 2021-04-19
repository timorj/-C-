using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DirectoryApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Fun with Directory(Info) *****\n");
            ShowWindowsDirectory();
            //DisplayImageFiles();
            //ModifyAppDirectory();

            DriveInfo[] myDrives = DriveInfo.GetDrives();
            foreach (DriveInfo d in myDrives)
            {
                Console.WriteLine("Name:{0}", d.Name);
                Console.WriteLine("Type:{0}", d.DriveType);

                if (d.IsReady)
                {
                    Console.WriteLine("Free space: {0}", d.TotalFreeSpace);
                    Console.WriteLine("Format:{0}", d.DriveFormat);
                    Console.WriteLine("Label:{0}",d.VolumeLabel);

                }
                Console.WriteLine();
            }

            //FunWithDirectoryType();
            Console.Read();
        }
        static void FunWithDirectoryType()
        {
            string[] drives = Directory.GetLogicalDrives();
            Console.WriteLine("Here are your dirves");
            foreach (string s in drives)
            {
                Console.WriteLine("-->{0}", s);
            }

            Console.WriteLine("Press Enter to delete directories");
            Console.ReadLine();
            try
            { 
                FileInfo myFolder = new FileInfo("./MyFolder");
                Directory.Delete(myFolder.FullName, true);
            }
            catch (IOException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        static void ShowWindowsDirectory() 
        {
            DirectoryInfo dir = new DirectoryInfo(@"C:\Windows");
            Console.WriteLine("*****Directory Info ******");
            Console.WriteLine("FullName:{0}", dir.FullName);
            Console.WriteLine("Name:{0}", dir.Name);
            Console.WriteLine("Parent:{0}", dir.Parent);
            Console.WriteLine("Creation:{0}", dir.CreationTime);
            Console.WriteLine("Attributes:{0}", dir.Attributes);
            Console.WriteLine("Root:{0}", dir.Root);
            Console.WriteLine("****************\n");
        }
        static void DisplayImageFiles() 
        {
            DirectoryInfo dir = new DirectoryInfo(@"D:\Users\hands\Desktop\ParalleismTest");

            FileInfo[] imageFiles = dir.GetFiles("*.jpg", SearchOption.AllDirectories);

            Console.WriteLine("Found {0} *.jpg files\n", imageFiles.Length);
            foreach (FileInfo f in imageFiles)
            {
                Console.WriteLine("****************");
                Console.WriteLine("File Name:{0}", f.Name);
                Console.WriteLine("File Size:{0}", f.Length);
                Console.WriteLine("Creation:{0}", f.CreationTime);
                Console.WriteLine("Attributes:{0}", f.Attributes);
                Console.WriteLine("****************\n");
            }
        }
        static void ModifyAppDirectory()
        {
            DirectoryInfo dir = new DirectoryInfo(".");
           

            dir.CreateSubdirectory("MyFolder");
            DirectoryInfo myDataFolder = dir.CreateSubdirectory(@"MyFolder\Data");

            Console.WriteLine("New Folder:{0}", myDataFolder.ToString());
        }
    }
}
