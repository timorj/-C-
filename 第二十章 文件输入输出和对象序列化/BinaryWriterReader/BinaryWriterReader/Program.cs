using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinaryWriterReader
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("***Fun with Binary writers/readers *********\n");
            FileInfo f = new FileInfo("BinFile.dat");
            using (BinaryWriter bw = new BinaryWriter(f.OpenWrite()))
            {
                Console.WriteLine("Base stream is:{0}", bw.BaseStream);

                double aDouble = 1234.56;
                int aInt = 34567;
                string aString = "A ,B ,C";

                bw.Write(aDouble);
                bw.Write(aInt);
                bw.Write(aString);

            }

            using (BinaryReader br = new BinaryReader(f.OpenRead()))
            {
                Console.WriteLine(br.ReadDouble());
                Console.WriteLine(br.ReadInt32());
                Console.WriteLine(br.ReadString());
            }
            Console.WriteLine("Done!");
            Console.ReadLine();

        }
    }
}
