using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Data.Common;
namespace FillDataSetUsingSqlDataAdapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with Data Adapters******");

            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;

            DataSet ds = new DataSet("AutoLot");

            SqlDataAdapter dAdapter = new SqlDataAdapter("Select * From Inventory", cnStr);
            
            //映射用户友好名称
            DataTableMapping custMap = dAdapter.TableMappings.Add("Inventory", "Current Inventory");
            custMap.ColumnMappings.Add("CarID", "Car ID");
            custMap.ColumnMappings.Add("PetName", "Car of Name");

            //为ds填充一个新表
            dAdapter.Fill(ds, "Inventory");


            PrintDataSet(ds);
            Console.ReadLine();
        }

        private static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("Data source name:{0}", ds.DataSetName);
            for (int i = 0; i < ds.Tables.Count; i++)
            {
                Console.WriteLine("Table {0}", ds.Tables[i].TableName);
                DataTable dt = ds.Tables[i];

                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Console.Write("{0}\t", dt.Columns[j].ColumnName);
                }
                Console.WriteLine();

                DataTableReader dr = new DataTableReader(dt);
                while (dr.Read())
                {
                    for (int k = 0; k < dr.FieldCount; k++)
                    {
                        Console.Write("{0}\t", dr[k].ToString());
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
