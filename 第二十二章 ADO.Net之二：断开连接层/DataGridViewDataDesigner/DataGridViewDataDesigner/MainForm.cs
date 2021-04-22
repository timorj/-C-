using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataGridViewDataDesigner
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: 这行代码将数据加载到表“inventoryDataSet.Inventory”中。您可以根据需要移动或删除它。
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);

        }

        private void btnUpdateDataGridView_Click(object sender, EventArgs e)
        {
            try
            {
                this.inventoryTableAdapter.Update(this.inventoryDataSet.Inventory);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.inventoryTableAdapter.Fill(this.inventoryDataSet.Inventory);
        }
    }
}
