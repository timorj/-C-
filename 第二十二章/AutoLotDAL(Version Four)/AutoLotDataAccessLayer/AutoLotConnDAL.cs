using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotConnectedLayer
{
    public class InventoryDAL
    {
        private SqlConnection sqlcn = null;

        /// <summary>
        /// 打开连接，注意显示关闭连接
        /// </summary>
        /// <param name="connectionString"></param>
        public void OpenConnection(string connectionString)
        {
            sqlcn = new SqlConnection();
            sqlcn.ConnectionString = connectionString;
            sqlcn.Open();
        }

        /// <summary>
        /// 关闭连接
        /// </summary>
        public void CloseConnetion()
        {
            sqlcn.Close();
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="color"></param>
        /// <param name="make"></param>
        /// <param name="petName"></param>
        public void InsertAuto(int id, string color, string make, string petName)
        {

            string sql = string.Format("Insert Into Inventory" + "(CarID, Make, Color, PetName) Values" + "(@CarID, @Make, @Color, @PetName)");

            using (SqlCommand cmd = new SqlCommand(sql, sqlcn)) 
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CarID";
                param.Value = id;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Make";
                param.Value = make;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Color";
                param.Value = color;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = petName;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                //增加命令
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <param name="car"></param>
        public void InsertAuto(NewCar car)
        {
            string sql = string.Format("Insert Into Inventory" + "(CarID, Make, Color, PetName) Values" + "(@CarID, @Make, @Color, @PetName)");

            using (SqlCommand cmd = new SqlCommand(sql, sqlcn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@CarID";
                param.Value = car.CarID;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Make";
                param.Value = car.Make;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@Color";
                param.Value = car.Color;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = car.PetName;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                //增加命令
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="id"></param>
        public void DeleteCar(int id)
        {
            string sql = string.Format("Delete From Inventory where CarID = @CarID");
            using (SqlCommand cmd = new SqlCommand(sql, sqlcn))
            {
                try
                {
                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@CarID";
                    param.Value = id;
                    param.SqlDbType = SqlDbType.Int;
                    cmd.Parameters.Add(param);
                    cmd.ExecuteNonQuery();
                }
                catch (SqlException e)
                {
                    Exception error = new Exception("Sorry! That Car is on order!", e);
                    throw e;
                }

            }
        }

        /// <summary>
        /// 更改数据
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newPetName"></param>
        public void UpdateCarPetName(int id, string newPetName)
        {
            string sql = string.Format("Update Inventory Set PetName = @PetName Where CarID = @CarID");
            using (SqlCommand cmd = new SqlCommand(sql, sqlcn))
            {
                SqlParameter param = new SqlParameter();
                param.ParameterName = "@PetName";
                param.Value = newPetName;
                param.SqlDbType = SqlDbType.Char;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@CarID";
                param.Value = id;
                param.SqlDbType = SqlDbType.Int;
                cmd.Parameters.Add(param);

                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// 获取数据
        /// </summary>
        /// <returns></returns>
        public List<NewCar> GetAllInventoryAsList()
        {
            List<NewCar> inv = new List<NewCar>();

            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, sqlcn))
            {
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    inv.Add(new NewCar()
                    {
                        CarID = (int)dr["CarID"],
                        Color = (string)dr["Color"],
                        Make = (string)dr["Make"],
                        PetName = (string)dr["PetName"]
                    });
                }
                dr.Close();
            }
            return inv;
        }
        
        /// <summary>
        /// 以非连接层的方式获取数据
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllInventoryAsDataTable()
        {
            DataTable inv = new DataTable();

            string sql = "Select * From Inventory";
            using (SqlCommand cmd = new SqlCommand(sql, sqlcn))
            {
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    inv.Load(dr);
                }
            }
            return inv;
        }

        /// <summary>
        /// 设置GetPetName储存过程
        /// </summary>
        /// <param name="carID"></param>
        /// <returns></returns>
        public string LookUpPetName(int carID)
        {
            string carPetName = string.Empty;

            using (SqlCommand cmd = new SqlCommand("GetPetName", sqlcn))
            {
                //储存过程
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@carID";
                param.Value = carID;
                param.SqlDbType = SqlDbType.Int;
               

                param.Direction = ParameterDirection.Input;
                cmd.Parameters.Add(param);

                param = new SqlParameter();
                param.ParameterName = "@petName";
                param.SqlDbType = SqlDbType.Char;
                param.Size = 10;
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                //执行储存过程
                cmd.ExecuteNonQuery();

                carPetName = (string)cmd.Parameters["@petName"].Value;

            }
            return carPetName;
        }

        /// <summary>
        /// 处理数据库事务
        /// </summary>
        /// <param name="throwEx"></param>
        /// <param name="custID"></param>
        public void ProcessCreditRisk(bool throwEx, int custID)
        {
            string fName = string.Empty;
            string lName = string.Empty;
            SqlCommand cmd = new SqlCommand(string.Format("Select * From Cutstomers where CustID = {0}", custID), sqlcn);

            using (SqlDataReader dr = cmd.ExecuteReader())
            {
                if (dr.HasRows)
                {
                    dr.Read();
                    fName = (string)dr["FirstName"];
                    lName = (string)dr["LastName"];

                }
                else
                {
                    return;
                }
            }

            SqlCommand cmdRemove = new SqlCommand(string.Format("Delete from Cutstomers Where CustID = @CustID"), sqlcn);

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@CustID";
            param.Value = custID;
            param.SqlDbType = SqlDbType.Int;
            cmdRemove.Parameters.Add(param);

            SqlCommand cmdInsert = new SqlCommand(string.Format("Insert Into CreditRisks" + "(CustID, FirstName, LastName) Values" +"({0}, '{1}', '{2}')", custID, fName, lName), sqlcn);

            SqlTransaction tx = null;
            try
            {
                tx = sqlcn.BeginTransaction();

                cmdInsert.Transaction = tx;
                cmdRemove.Transaction = tx;

                cmdInsert.ExecuteNonQuery();
                cmdRemove.ExecuteNonQuery();
                
                

                //模拟错误
                if (throwEx)
                {
                    throw new Exception("Sorry! DataBase error! Tx failed...");
                }

                tx.Commit();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                tx.Rollback();
            }
        }
    }
    public class NewCar
    {
        public int CarID { get; set; }
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }

    }
}
