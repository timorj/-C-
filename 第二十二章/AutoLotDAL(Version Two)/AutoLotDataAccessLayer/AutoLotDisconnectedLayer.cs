using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AutoLotDataAccessLayer
{
    public class InventoryDALDisLayer
    {
        private string cnString = string.Empty;
        private SqlDataAdapter dAdapt = null;

        public InventoryDALDisLayer(string connectionString)
        {
            cnString = connectionString;

            ConfigureAdapter(out dAdapt);
        }

        /// <summary>
        /// 配置数据适配器
        /// </summary>
        /// <param name="dAdapt"></param>
        private void ConfigureAdapter(out SqlDataAdapter dAdapt)
        {
            dAdapt = new SqlDataAdapter("Select * From Inventory", cnString);

            //在运行时动态获取其余的命令对象
            SqlCommandBuilder builder = new SqlCommandBuilder(dAdapt);
        }

        /// <summary>
        /// 获取Inventory表
        /// </summary>
        /// <returns></returns>
        public DataTable GetAllInventory()
        {
            DataTable inv = new DataTable("Inventory");
            dAdapt.Fill(inv);
            return inv; 
        }

        public void UpdateInventory(DataTable modifiedTable)
        {
            dAdapt.Update(modifiedTable);
        }


    }
}
