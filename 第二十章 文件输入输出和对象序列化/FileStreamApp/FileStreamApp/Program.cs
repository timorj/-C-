using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Text;

namespace FileStreamApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Fun with FileStreams ********\n");

            using (FileStream fStream = File.Open("./myMessage.dat", FileMode.OpenOrCreate))
            {
                string msg = "Hello!";
                byte[] msgAsByteArray = Encoding.Default.GetBytes(msg);

                fStream.Write(msgAsByteArray, 0, msgAsByteArray.Length);

                fStream.Position = 0;

                Console.WriteLine("Your message as an array of byte:");
                byte[] bytesFromFile = new byte[msgAsByteArray.Length];

                for (int i = 0; i < msgAsByteArray.Length; i++)
                {
                    bytesFromFile[i] = (byte)fStream.ReadByte();
                    Console.WriteLine(bytesFromFile[i]);
                }

                Console.WriteLine("\nDecoded Message:");
                Console.WriteLine(Encoding.Default.GetString(bytesFromFile));
            }
            Console.ReadLine();
        }
    }
}
