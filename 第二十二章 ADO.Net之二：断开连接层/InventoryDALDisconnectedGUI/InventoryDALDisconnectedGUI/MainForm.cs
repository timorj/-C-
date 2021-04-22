using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using AutoLotDataAccessLayer;

namespace InventoryDALDisconnectedGUI
{

    public partial class MainForm : Form
    {
        InventoryDALDisLayer dal = null;
        public MainForm()
        {
            InitializeComponent();
            string cnStr = @"data source = (localdb)\MSSQLLocalDB;Initial Catalog = AutoLot;Integrated Security = SSPI; Pooling = False";
            dal = new InventoryDALDisLayer(cnStr);

            inventoryGrid.DataSource = dal.GetAllInventory();
        }

        private void btnUpdateInventory_Click(object sender, EventArgs e)
        {
            DataTable changedDT = (DataTable)inventoryGrid.DataSource;

            try
            {
                dal.UpdateInventory(changedDT);
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
