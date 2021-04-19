using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICloneExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****A first look at Interfaces******");

            string myStr = "Hello";
            OperatingSystem unixOs = new OperatingSystem(PlatformID.Unix, new Version());
            System.Data.SqlClient.SqlConnection sqlCnn = new System.Data.SqlClient.SqlConnection();

            CloneMe(sqlCnn);
            CloneMe(myStr);
            CloneMe(unixOs);
        }
        private static void CloneMe(ICloneable c)
        {
            object theClone = c.Clone();
            Console.WriteLine("Your clone is a :{0}", theClone.GetType().Name);
        }
    }
   
}
