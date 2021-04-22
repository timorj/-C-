using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Data.Entity.Core.EntityClient;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryEDMConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******Fun with ADO.Net EF ********\n");
            RemoveRecord();
            PrintAllInventory();
            Console.WriteLine("-----------------");
            AddNewRecord();
            PrintAllInventory();

            Console.WriteLine("-----------------");
            UpdateRecord();
            PrintAllInventory();

            Console.WriteLine("-----------------");
            FunWithLINQQueries();

            Console.WriteLine("------------------");
            FunWithEntitySQL();

            Console.WriteLine("------------------");
            FunWithEntityDataReader();
            Console.ReadLine();
        }
        private static void FunWithEntityDataReader()
        {
            using (EntityConnection cn = new EntityConnection("name = AutoLotEntities"))
            {
                cn.Open();

                string query = "SELECT VALUE car FROM AutoLotEntities.Cars As Car";

                //创建一个命令对象
                using (EntityCommand cmd = cn.CreateCommand())
                {
                    cmd.CommandText = query;

                    //使用EntityDataReader获取得到的数据
                    using (EntityDataReader dr = cmd.ExecuteReader( System.Data.CommandBehavior.SequentialAccess))
                    {
                        while (dr.Read())
                        {
                            Console.WriteLine("******Record*******");
                            Console.WriteLine("ID:{0}", dr["CarID"]);
                            Console.WriteLine("Make:{0}", dr["Make"]);
                            Console.WriteLine("Color:{0}", dr["Color"]);
                            Console.WriteLine("Pet Name:{0}", dr["CarNickName"]);
                        }
                    }
                }

            }
        }

        /// <summary>
        /// Linq to SQL
        /// </summary>
        private static void FunWithLINQQueries()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                var colorMakes = from item in context.Cars select new { item.Color, item.Make };
                foreach (var item in colorMakes)
                {
                    Console.WriteLine(item);
                }

                var idsLessThan1000 = from item in context.Cars where item.CarID < 1000 select item;
                foreach (var item in idsLessThan1000)
                {
                    Console.WriteLine(item);
                }
            }
        }

        /// <summary>
        /// Linq to Entity
        /// </summary>
        private static void FunWithEntitySQL()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                ObjectContext newContext = ((IObjectContextAdapter)context).ObjectContext;
                //构建一个包含Entity SQL语法的字符串
                string query = "SELECT VALUE car FROM AutoLotEntities.Cars " + "AS car WHERE car.Color = 'black'";


                var blackCars = newContext.CreateQuery<Car>(query);

                foreach (var item in blackCars)
                {
                    Console.WriteLine(item);
                }
            }
        }

        private static void UpdateRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                Car carToUpdate = (from car in context.Cars where car.CarID == 2222 select car).FirstOrDefault();
                
                if(carToUpdate != null)
                {
                    carToUpdate.CarNickName = "LiPengfei";
                    context.SaveChanges();
                }
            }
        }

        private static void RemoveRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                //查找实体，如果存在则将其删除
                Car carToDelete = (Car)context.Cars.Where(g => g.CarID == 2222).Select(g => g).FirstOrDefault();
                if(carToDelete != null)
                {
                    context.Cars.Remove(carToDelete);
                    context.SaveChanges();
                }
            }
        }

        private static void PrintAllInventory()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                foreach (Car c in context.Cars)
                {
                    Console.WriteLine(c);
                }
            }
        }

        private static void AddNewRecord()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                try
                {
                    context.Cars.Add(new Car() { 
                        CarID = 2222,
                         Make = "Yugo",
                         Color = "Brown"
                    });
                    context.SaveChanges();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
        }


    }
}
