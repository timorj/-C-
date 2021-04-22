using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AutoLotDataAccessLayer;
using AutoLotDataAccessLayer.AutoLotDataSetTableAdapters;
namespace LINQToDataSetApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********LINQ over DataSet ***********\n");

            //获取强类型的DataTable
            AutoLotDataSet dal = new AutoLotDataSet();
            InventoryTableAdapter dAdapt = new InventoryTableAdapter();
            AutoLotDataSet.InventoryDataTable data = dAdapt.GetData();

            PrintAllCarIDs(data);
            ShowRedCars(data);
            BuildDataTableFromQuery(data);
            Console.ReadLine();
        }

        static void PrintAllCarIDs(DataTable dt)
        {
            //使得DataTable支持linq查询
            EnumerableRowCollection enumData = dt.AsEnumerable();

            foreach (DataRow r in enumData)
            {
                Console.WriteLine("Car ID = {0}", r["CarID"]);
            }
        }
        static void ShowRedCars(DataTable dt)
        {
            //增强查询时的类型安全
            var cars = from car in dt.AsEnumerable() where car.Field<string>("Color") == "Red" select new { ID = car.Field<int>("CarID"), Make = car.Field<string>("Make") };

            Console.WriteLine("Here are the red cars in stock:");
            foreach (var item in cars)
            {
                Console.WriteLine("-> CarID:{0},Make:{1}", item.ID, item.Make);
            }
        }
        static void BuildDataTableFromQuery(DataTable data)
        {
            var cars = from car in data.AsEnumerable() where car.Field<int>("CarID") > 5 select car;

            //使用结果集构建新的DataTable
            DataTable newTable = cars.CopyToDataTable();

            for (int curRow = 0; curRow < newTable.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < newTable.Columns.Count; curCol++)
                {
                    Console.Write(newTable.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
