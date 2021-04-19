using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoLotConnectedLayer;
using System.Data;
using System.Configuration;

namespace AutoLotCUIclient
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*******The AutoLot Console UI********\n");
            string cnStr = ConfigurationManager.ConnectionStrings["AutoLotSqlProvider"].ConnectionString;
            bool userDone = false;
            string userCommand = "";

            InventoryDAL invDAL = new InventoryDAL();
            invDAL.OpenConnection(cnStr);

            try
            {
                ShowInstructions();

                do
                {
                    Console.WriteLine("\n Please enter your Command:");
                    userCommand = Console.ReadLine();
                    switch (userCommand.ToUpper())
                    {
                        case "I":
                            InsertNewCar(invDAL);
                            break;
                        case "U":
                            UpdateCarPetName(invDAL);
                            break;
                        case "D":
                            DeleteCar(invDAL);
                            break;
                        case "L":
                            ListInventory(invDAL);
                            break;
                        case "S":
                            ShowInstructions();
                            break;
                        case "P":
                            LookUpPetName(invDAL);
                            break;
                        case "Q":
                            Environment.Exit(-1);
                            break;
                        default:
                            break;
                    }

                } while (!userDone);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                invDAL.CloseConnetion();
            }

        }

        private static void LookUpPetName(InventoryDAL invDAL)
        {
            Console.WriteLine("Enter ID of Car to look up:");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("PetName of {0} if {1}.", id, invDAL.LookUpPetName(id).TrimEnd());
        }

        private static void ListInventory(InventoryDAL invDAL)
        {
            DataTable dt = invDAL.GetAllInventoryAsDataTable();

            DisplayDataTable(dt);
        }

        private static void DisplayDataTable(DataTable dt)
        {
            for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
            {
                Console.Write(dt.Columns[curCol].ColumnName+"\t");
            }
            Console.WriteLine("\n------------------");

            for (int curRow = 0; curRow < dt.Rows.Count; curRow++)
            {
                for (int curCol = 0; curCol < dt.Columns.Count; curCol++)
                {
                    Console.Write(dt.Rows[curRow][curCol].ToString() + "\t");
                }
                Console.WriteLine();
            }
        }

        private static void DeleteCar(InventoryDAL invDAL)
        {
            Console.WriteLine("Enter ID of Car to Delete:");
            int id = int.Parse(Console.ReadLine());

            try
            {
                invDAL.DeleteCar(id);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void UpdateCarPetName(InventoryDAL invDAL)
        {
            int carID;
            string newCarPetName;

            Console.WriteLine("Enter Car ID:");
            carID = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter new Pet Name:");
            newCarPetName = Console.ReadLine();

            invDAL.UpdateCarPetName(carID, newCarPetName);
        }

        private static void InsertNewCar(InventoryDAL invDAL)
        {
            int newCarID;
            string newCarColor, newCarMake, newCarPetName;

            Console.WriteLine("Enter Car ID:");
            newCarID = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Car Color:");
            newCarColor = Console.ReadLine();

            Console.WriteLine("Enter Car Make:");
            newCarMake = Console.ReadLine();

            Console.WriteLine("Enter Car Pet Name:");
            newCarPetName = Console.ReadLine();

            NewCar newCar = new NewCar() { CarID = newCarID, Color = newCarColor, Make = newCarMake, PetName = newCarPetName };

            invDAL.InsertAuto(newCar);
        }

        private static void ShowInstructions()
        {
            Console.WriteLine("I:Inserts a new Car.");
            Console.WriteLine("U:Updates an existing Car.");
            Console.WriteLine("D:Deletes an existing Car.");
            Console.WriteLine("L:Lists current inventory.");
            Console.WriteLine("S:Shows these instructions.");
            Console.WriteLine("P:Looks up petName.");
            Console.WriteLine("Q:Quits program.");
        }
    }
}
