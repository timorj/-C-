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

namespace AutoLotEDM_GUI
{
    public partial class MainForm : Form
    {
        AutoLotEntities context = new AutoLotEntities();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            gridInventory.DataSource = context.Inventories.ToList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            MessageBox.Show("Data saved!");
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            context.Dispose();
        }
    }
}
