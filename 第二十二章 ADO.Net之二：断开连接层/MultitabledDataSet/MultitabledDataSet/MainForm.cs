using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.Common;
using System.Data.SqlClient;
using System.Configuration;
namespace MultitabledDataSet
{
    public partial class MainForm : Form
    {
        private DataSet autoLotDS = new DataSet("AutoLot");

        //使用命令构建器来简化数据适配器的配置
        private SqlCommandBuilder sqlCBInventory;
        private SqlCommandBuilder sqlCBCustomers;
        private SqlCommandBuilder sqlCBOrders;

        //每个表的数据适配器
        private SqlDataAdapter invTableAdapter;
        private SqlDataAdapter custTableAdapter;
        private SqlDataAdapter ordersTableAdapter;

        private string cnStr = string.Empty;
        public MainForm()
        {
            InitializeComponent();

            cnStr = ConfigurationManager.ConnectionStrings["AutoLotSQLProvider"].ConnectionString;

            invTableAdapter = new SqlDataAdapter("Select * From Inventory", cnStr);
            custTableAdapter = new SqlDataAdapter("Select * From Cutstomers", cnStr);
            ordersTableAdapter = new SqlDataAdapter("Select * From Orders", cnStr);

            //自动生成命令
            sqlCBInventory = new SqlCommandBuilder(invTableAdapter);
            sqlCBCustomers = new SqlCommandBuilder(custTableAdapter);
            sqlCBOrders = new SqlCommandBuilder(ordersTableAdapter);

            //填充表
            invTableAdapter.Fill(autoLotDS, "Inventory");
            custTableAdapter.Fill(autoLotDS, "Cutstomers");
            ordersTableAdapter.Fill(autoLotDS, "Orders");

            //建立表间关系
            BuildTableRelationship();

            //绑定网格
            dataGridViewInventory.DataSource = autoLotDS.Tables["Inventory"];
            dataGridViewCustomers.DataSource = autoLotDS.Tables["Cutstomers"];
            dataGridViewOrders.DataSource = autoLotDS.Tables["Orders"];
        }

        private void BuildTableRelationship()
        {
            DataRelation dr = new DataRelation("CustomerOrder", autoLotDS.Tables["Cutstomers"].Columns["CustID"], autoLotDS.Tables["Orders"].Columns["CustID"]);
            autoLotDS.Relations.Add(dr);

            dr = new DataRelation("InventoryOrder", autoLotDS.Tables["Inventory"].Columns["CarID"], autoLotDS.Tables["Orders"].Columns["CarID"]);
            autoLotDS.Relations.Add(dr);
        }

        private void btnUpdateDataBase_Click(object sender, EventArgs e)
        {
            try
            {
                invTableAdapter.Update(autoLotDS, "Inventory");
                custTableAdapter.Update(autoLotDS, "Cutstomers");
                ordersTableAdapter.Update(autoLotDS, "Orders");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnGetOrderInfo_Click(object sender, EventArgs e)
        {
            string strOderInfo = string.Empty;
            DataRow[] drsCust = null;
            DataRow[] drsOrder = null;

            int custID = int.Parse(txtCustID.Text);

            drsCust = autoLotDS.Tables["Cutstomers"].Select(string.Format("CustID={0}", custID));
            strOderInfo += string.Format("Customers {0}: {1} {2}\n", drsCust[0]["CustID"].ToString(), drsCust[0]["FirstName"].ToString(), drsCust[0]["LastName"].ToString());

            //切换到Order表
            drsOrder = drsCust[0].GetChildRows(autoLotDS.Relations["CustomerOrder"]);

            //为客户循环所有订单
            foreach (DataRow order in drsOrder)
            {
                strOderInfo += string.Format("----\nOrder Number:{0}\n", order["OrderID"]);

                DataRow[] drsInv = order.GetParentRows(autoLotDS.Relations["InventoryOrder"]);

                //得到Car的信息
                DataRow car = drsInv[0];
                strOderInfo += string.Format("Make:{0}\n", car["Make"]);
                strOderInfo += string.Format("Color:{0}\n", car["Color"]);
                strOderInfo += string.Format("PetName:{0}\n", car["PetName"]);
            }
            MessageBox.Show(strOderInfo, "Order Details");

        }
    }
}
