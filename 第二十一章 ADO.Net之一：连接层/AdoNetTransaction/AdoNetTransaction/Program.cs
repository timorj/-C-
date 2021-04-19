using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConnectedLayer;
using System.Configuration;
using System.Data;
namespace AdoNetTransaction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*********Simple transcation example **********");

            bool throwEx = true;
            string userAnswer = string.Empty;

            Console.WriteLine("Do you want to throw an exception (Y or N):");
            userAnswer = Console.ReadLine();

            if(userAnswer.ToUpper() == "N")
            {
                throwEx = false;
            }

            InventoryDAL dal = new InventoryDAL();
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            dal.OpenConnection(cnStr);

            dal.ProcessCreditRisk(throwEx, 333);

            Console.WriteLine("Check CreditRisk table for result.");
            Console.ReadLine();
        }
    }
}
