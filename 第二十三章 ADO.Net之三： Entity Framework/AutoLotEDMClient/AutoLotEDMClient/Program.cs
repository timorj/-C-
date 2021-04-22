using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotDataAccessLayer;

namespace AutoLotEDMClient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************Navigation Properties*******");
            Console.WriteLine("Please enter customer ID:");
            string id = Console.ReadLine();

            PrintCustomerOrders(id);

            CallStoredProc();
            Console.Read();
        }

        /// <summary>
        /// 调用导航属性
        /// </summary>
        /// <param name="custID"></param>
        private static void PrintCustomerOrders(string custID)
        {
            int id = int.Parse(custID);

            using (AutoLotEntities context = new AutoLotEntities())
            {
                var carsOnOrder = from o in context.Orders where o.CustID == id select o.Inventory;
                Console.WriteLine("\n Customer has {0} orders pending:", carsOnOrder.Count());
                foreach (var item in carsOnOrder)
                {
                    Console.WriteLine("->{0} {1} named {2}.", item.Color, item.Make, item.PetName);
                }
            }
        }

        private static void CallStoredProc()
        {
            using (AutoLotEntities context = new AutoLotEntities())
            {
                //方法一
                ObjectParameter input = new ObjectParameter("carID", 83);
                ObjectParameter output = new ObjectParameter("petName", typeof(string));

                //调用储存过程
                ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;
                objectContext.ExecuteFunction("GetPetName", input, output);

                Console.WriteLine("Car #83 is named {0}.", output.Value);

                //方法二
                context.GetPetName(83, output);
                Console.WriteLine("Car #83 is named {0}.", output.Value);
            }
        }
    }
}
