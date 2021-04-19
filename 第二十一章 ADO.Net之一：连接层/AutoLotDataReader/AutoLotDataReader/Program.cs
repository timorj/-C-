using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataReader
{
    
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("******Fun with Data Readers *********\n");

            //使用ConnectionBuilder构建连接字符串
            SqlConnectionStringBuilder cnStrBuilder = new SqlConnectionStringBuilder();
            cnStrBuilder.InitialCatalog = "AutoLot";
            cnStrBuilder.DataSource = @"(localdb)\MSSQLLocalDB";
            cnStrBuilder.ConnectTimeout = 30;
            cnStrBuilder.IntegratedSecurity = true;
           
            using (SqlConnection cn = new SqlConnection())
            {
                cn.ConnectionString = cnStrBuilder.ConnectionString;
                cn.Open();

                ShowConnectionStatus(cn);

                string strSql = "Select * From Inventory;Select * From Cutstomers";
                SqlCommand myCommand = new SqlCommand();
                myCommand.CommandText = strSql;
                myCommand.Connection = cn;

                using (SqlDataReader dr = myCommand.ExecuteReader())
                {
                    do
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("****** Record *******");
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                Console.WriteLine("{0} = {1}", dr.GetName(i), dr.GetValue(i).ToString());
                            }
                            Console.WriteLine();
                        }

                    } while (dr.NextResult());
                }
            }
            Console.Read();
        }

        private static void ShowConnectionStatus(SqlConnection cn)
        {
            Console.WriteLine("******* Info about your connection *******");
            Console.WriteLine("Database location:{0}", cn.DataSource);
            Console.WriteLine("Database name:{0}", cn.Database);
            Console.WriteLine("Time out:{0}", cn.ConnectionTimeout);
            Console.WriteLine("Connection state:{0}\n", cn.State.ToString());

        }
    }
}
