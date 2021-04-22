using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDataAccessLayer;
using AutoLotDataAccessLayer.AutoLotDataSetTableAdapters;
namespace StronglyTypedDataSetConsoleClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("********Fun with Strongly Typed DataSets********\n");

            AutoLotDataSet.InventoryDataTable table = new AutoLotDataSet.InventoryDataTable();
            InventoryTableAdapter dAdapter = new InventoryTableAdapter();
            dAdapter.Fill(table);

            PrintInventory(table);

            AddRecords(table, dAdapter);
            table.Clear();
            dAdapter.Fill(table);
            PrintInventory(table);

            RemoveRecords(table, dAdapter);
            table.Clear();
            dAdapter.Fill(table);
            PrintInventory(table);

            CallStoredProc();
            Console.ReadLine();
        }
        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="dAdapt"></param>
        private static void AddRecords(AutoLotDataSet.InventoryDataTable tb, InventoryTableAdapter dAdapt)
        {
            try
            {
                AutoLotDataSet.InventoryRow newRow = tb.NewInventoryRow();

                newRow.CarID = 999;
                newRow.Color = "Purple";
                newRow.Make = "BMW";
                newRow.PetName = "Saku";

                tb.AddInventoryRow(newRow);

                //以重载的方式加入新行
                tb.AddInventoryRow(777, "Yugo", "Green", "Zippy");

                //报存更新
                dAdapt.Update(tb);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="tb"></param>
        /// <param name="dAdapt"></param>
        private static void RemoveRecords(AutoLotDataSet.InventoryDataTable tb, InventoryTableAdapter dAdapt)
        {
            try
            {
                AutoLotDataSet.InventoryRow rowToDelete = tb.FindByCarID(777);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);

                rowToDelete = tb.FindByCarID(999);
                dAdapt.Delete(rowToDelete.CarID, rowToDelete.Make, rowToDelete.Color, rowToDelete.PetName);


            }catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void CallStoredProc()
        {
            try
            {
                QueriesTableAdapter q = new QueriesTableAdapter();

                Console.WriteLine("Enter Car ID to look up:");
                string carID = Console.ReadLine();
                string carName = "";
                q.GetPetName(int.Parse(carID), ref carName);
                Console.WriteLine("CarID {0} has the name of {1}", carID, carName);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// 打印强类型的数据集表数据
        /// </summary>
        /// <param name="table"></param>
        private static void PrintInventory(AutoLotDataSet.InventoryDataTable table)
        {
            for (int curCol = 0; curCol < table.Columns.Count; curCol++)
            {
                Console.Write(table.Columns[curCol].ColumnName+"\t");
            }
            Console.WriteLine("\n-----------------------");

            for (int curRow = 0; curRow < table.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < table.Columns.Count; curCol++)
                {
                    Console.Write(table[curRow][curCol].ToString()+"\t");
                }
                Console.WriteLine();
            }
        }
    }
}
