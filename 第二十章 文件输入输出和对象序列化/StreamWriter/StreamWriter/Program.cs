using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreamWriterReaderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("FunWith stream writer / StreamReader ******\n");

            using (StreamWriter writer = File.CreateText("reminder.txt"))
            {
                writer.WriteLine("Don't forget Mother's Day this year...");
                writer.WriteLine("Don't forget Farther's Day this year...");
                writer.WriteLine("Don't forget these number:");
                for (int i = 0; i < 10; i++)
                {
                    writer.Write(i + " ");
                }
                writer.Write(writer.NewLine);
            }
            Console.WriteLine("creat new file and wrote some thoughts...");

            Console.WriteLine("Here are your thoughts:\n");
            using (StreamReader reader = File.OpenText("reminder.txt"))
            {
                string input = null;
                while((input = reader.ReadLine()) != null)
                {
                    Console.WriteLine(input);
                }
            }
                Console.ReadLine();
        }
    }
}
