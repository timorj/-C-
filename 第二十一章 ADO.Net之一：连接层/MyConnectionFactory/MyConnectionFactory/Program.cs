using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Data.Odbc;
using System.Data.OleDb;

using System.Configuration;

namespace MyConnectionFactory
{
    enum DataProvider
    {
        SqlServer, OleDb, Odbc, None
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Very Simple Connection Factory *********\n");

            string dataProviderString = ConfigurationSettings.AppSettings["provider"];

            DataProvider dp = DataProvider.None;
            if (Enum.IsDefined(typeof(DataProvider), dataProviderString))
                dp = (DataProvider)Enum.Parse(typeof(DataProvider), dataProviderString);
            else
                Console.WriteLine("Sorry, no provider exists!");

            //获取连接
            IDbConnection myCn = GetConnetion(dp);
            Console.WriteLine("Your connection is a {0}.", myCn.GetType().Name);

            Console.ReadKey();
        }

        private static IDbConnection GetConnetion(DataProvider dp)
        {
            IDbConnection conn = null;

            switch (dp)
            {
                case DataProvider.SqlServer:
                    conn = new SqlConnection();
                    break;
                case DataProvider.OleDb:
                    conn = new OleDbConnection();
                    break;
                case DataProvider.Odbc:
                    conn = new OdbcConnection();
                    break;
            }

            return conn;
        }
    }
}
