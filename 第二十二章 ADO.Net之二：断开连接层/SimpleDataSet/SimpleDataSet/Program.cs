using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace SimpleDataSet
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*****Fun with DataSets******\n");

            DataSet carsInventoryDS = new DataSet("Car Inventory");

            carsInventoryDS.ExtendedProperties["TimeStamp"] = DateTime.Now;
            carsInventoryDS.ExtendedProperties["DataSetID"] = Guid.NewGuid();
            carsInventoryDS.ExtendedProperties["Company"] = "Mikko's Hot Tub Store";

            FillDataSet(carsInventoryDS);
            PrintDataSet(carsInventoryDS);

            SaveAndLoadAsXML(carsInventoryDS);
            SaveAndLoadAsBinary(carsInventoryDS);

            Console.ReadLine();

        }
        /// <summary>
        /// 展示DataSet的数据
        /// </summary>
        /// <param name="ds"></param>
        private static void PrintDataSet(DataSet ds)
        {
            Console.WriteLine("DataSet is named:{0}", ds.DataSetName);

            foreach (System.Collections.DictionaryEntry de in ds.ExtendedProperties)
            {
                Console.WriteLine("key = {0}, value = {1}", de.Key, de.Value);
            }
            Console.WriteLine();

            foreach (DataTable dt in ds.Tables)
            {
                Console.WriteLine("=> {0} Table:", dt.TableName);

                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Columns[curCol].ColumnName + "\t");
                }
                Console.WriteLine("\n-------------------------------");

                //遍历调用
                /* for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
                 {
                     for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                     {
                         Console.Write(dt.Rows[curRow][curCol].ToString()+"\t");
                     }
                     Console.WriteLine();
                 }*/
                //DataReader调用
                PrintDataTable(dt);

            }
        }

        /// <summary>
        /// 展示表数据
        /// </summary>
        /// <param name="dt"></param>
        static void PrintDataTable(DataTable dt)
        {
            DataTableReader dtReader = dt.CreateDataReader();

            while (dtReader.Read())
            {
                for (int i = 0; i < dtReader.FieldCount; i++)
                {
                    Console.Write("{0}\t", dtReader.GetValue(i).ToString().Trim());
                }
                Console.WriteLine();
            }
            dtReader.Close();
        }

        /// <summary>
        /// 模拟填充DataSet
        /// </summary>
        /// <param name="ds"></param>
        static void FillDataSet(DataSet ds)
        {
            DataColumn carIDColumn = new DataColumn("CarID", typeof(int));
            carIDColumn.Caption = "Car ID";//用户友好名称
            carIDColumn.ReadOnly = true;
            carIDColumn.AllowDBNull = false;
            carIDColumn.Unique = true;
            //设置自增
            carIDColumn.AutoIncrement = true;
            carIDColumn.AutoIncrementSeed = 0;
            carIDColumn.AutoIncrementStep = 1;

            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            carPetNameColumn.Caption = "Pet Name";

            DataTable inventoryTable = new DataTable("Inventory");
            inventoryTable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            //设置主键
            inventoryTable.PrimaryKey = new DataColumn[] { carIDColumn };


            DataRow carRow = inventoryTable.NewRow();
            //0为自增字段，所以从1开始
            carRow[1] = "Saab";
            carRow[2] = "Red";
            carRow[3] = "Sea Breeze";
            inventoryTable.Rows.Add(carRow);

            ds.Tables.Add(inventoryTable);
        }

        /// <summary>
        /// 序列化DataSet为XML
        /// </summary>
        /// <param name="ds"></param>
        static void SaveAndLoadAsXML(DataSet ds)
        {
            ds.WriteXml("carsDataSet.xml");
            ds.WriteXmlSchema("carsDataSet.xsd");

            ds.Clear();
            ds.ReadXml("carsDataSet.xml");
        }

        /// <summary>
        /// 序列化DataSet为Binary
        /// </summary>
        /// <param name="ds"></param>
        static void SaveAndLoadAsBinary(DataSet ds)
        {
            ds.RemotingFormat = SerializationFormat.Binary;
            
            using (FileStream fs = new FileStream("BinaryCars.bin", FileMode.Create))
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(fs, ds);
            }

            ds.Clear();

            Console.WriteLine("反序列化的结果:");
            using (FileStream fs = new FileStream("BinaryCars.bin", FileMode.Open))
            {
                BinaryFormatter bf = new BinaryFormatter();
                DataSet data = (DataSet)bf.Deserialize(fs);
                PrintDataSet(data);
            }
        }

        /// <summary>
        /// 查看行的状态
        /// </summary>
        private static void ManipulateDataRowState()
        {
            DataTable tempTable = new DataTable("Temp");
            tempTable.Rows.Add(new DataColumn("tempColumn", typeof(int)));

            //Detached
            DataRow row = tempTable.NewRow();
            Console.WriteLine("After calling NewRow():{0}", row.RowState);

            //Added
            tempTable.Rows.Add(row);
            Console.WriteLine("After calling Add():{0}", row.RowState);

            //Added
            row["tempColumn"] = 10;
            Console.WriteLine("After calling assignment:{0}", row.RowState);

            //Unchanged
            tempTable.AcceptChanges();
            Console.WriteLine("After calling AcceptChanges:{0}", row.RowState);

            //Modified
            row["tempColumn"] = 11;
            Console.WriteLine("After calling assignment:{0}", row.RowState);

            //Deleted
            tempTable.Rows[0].Delete();
            Console.WriteLine("After calling Delete:{0}", row.RowState);
        }
    }
}
