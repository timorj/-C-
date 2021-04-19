using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace StringReaderWriterApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with String writer/ stringreader ********\n");
            using (StringWriter strWriter = new StringWriter())
            {
                strWriter.WriteLine("Don't forget Mother's Day this year...");
                Console.WriteLine("Contents of StringWriter:\n {0}", strWriter);

                StringBuilder sb = strWriter.GetStringBuilder();
                sb.Insert(0, "Hey!");
                Console.WriteLine("->{0}", sb.ToString());
               /* sb.Remove(0, "Hey!".Length);
                Console.WriteLine("->{0}", sb.ToString());*/

                using (StringReader strReader = new StringReader(strWriter.ToString()))
                {
                    string input = null;
                    while((input = strReader.ReadLine()) != null)
                    {
                        Console.WriteLine(input);
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
