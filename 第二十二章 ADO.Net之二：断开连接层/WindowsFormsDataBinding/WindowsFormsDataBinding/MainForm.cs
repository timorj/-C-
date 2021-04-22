using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsDataBinding
{
    public partial class MainForm : Form
    {
        List<Car> listCars = null;

        DataTable inventorytable = new DataTable();
        DataView yugosOnlyView;

        public MainForm()
        {
            InitializeComponent();

            //填充一些数据
            listCars = new List<Car>()
            {
                new Car(){ ID = 100, PetName = "Chucky", Make = "BMW", Color = "Green"},
                new Car(){ ID = 101, PetName ="Tiny", Make ="Yugos", Color = "White"},
                new Car(){ ID = 102, PetName = "Ami", Make = "Jeep", Color = "Red"},
                new Car(){ ID = 103, PetName = "Pain Inducker", Make = "Garavan", Color = "Pink"},
                new Car(){ ID = 104, PetName = "Fred", Make = "BMW", Color ="Green"},
                new Car(){ ID = 105, PetName = "Sidd", Make = "BMW", Color = "Black"},
                new Car(){ ID = 106, PetName = "Mel", Make = "Firebird", Color = "Red"},
                new Car(){ ID = 107, PetName = "Sarah", Make = "Colt", Color = "Black"}
            };
            CreateDataTable();

            CreateDataView();

        }

        /// <summary>
        /// 创建数据视图
        /// </summary>
        private void CreateDataView()
        {
            yugosOnlyView = new DataView(inventorytable);

            //过滤器配置视图
            yugosOnlyView.RowFilter = "Make = 'Yugos'";

            dataGridViewYugosView.DataSource = yugosOnlyView;
        }

        /// <summary>
        /// 创建数据表
        /// </summary>
        private void CreateDataTable()
        {
            //创建表构建
            DataColumn carIDColumn = new DataColumn("ID", typeof(int));
            DataColumn carPetNameColumn = new DataColumn("PetName", typeof(string));
            DataColumn carMakeColumn = new DataColumn("Make", typeof(string));
            DataColumn carColorColumn = new DataColumn("Color", typeof(string));

            carPetNameColumn.Caption = "Pet Name";
            inventorytable.Columns.AddRange(new DataColumn[] { carIDColumn, carMakeColumn, carColorColumn, carPetNameColumn });

            foreach (Car c in listCars)
            {
                DataRow row = inventorytable.NewRow();
                row["ID"] = c.ID;
                row["PetName"] = c.PetName;
                row["Make"] = c.Make;
                row["Color"] = c.Color;
                inventorytable.Rows.Add(row);
            }

            carInventoryDridView.DataSource = inventorytable;
        }

        private void btnRemoveRow_Click(object sender, EventArgs e)
        {

            try
            {
                DataRow[] rowToDelete = inventorytable.Select(string.Format("ID = {0}", int.Parse(txtRowRemove.Text)));

                rowToDelete[0].Delete();
                inventorytable.AcceptChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDisplayMakes_Click(object sender, EventArgs e)
        {
            //根据用户输入的内容构建过滤器
            string filterStr = string.Format("Make = '{0}'", txtMakeToView.Text);

            //查找符合条件的所有记录
            DataRow[] makes = inventorytable.Select(filterStr);

            if(makes.Length == 0)
            {
                MessageBox.Show("Sorry, no cars...", "Selection Error!");
            }
            else
            {
                string strMake = "";
                for (int i = 0; i < makes.Length; i++)
                {
                    strMake += makes[i]["PetName"] + "\n";
                }
                MessageBox.Show(strMake, string.Format("We have {0}'s named:", txtMakeToView.Text));
            }
        }

        private void btnChangeMakes_Click(object sender, EventArgs e)
        {
            if(DialogResult.Yes == MessageBox.Show("Are you sure?? BMWs are much nicer than Yugos!", "Please confirm", MessageBoxButtons.YesNo))
            {
                string filterStr = "Make = 'BMW'";
                string strMake = string.Empty;

                DataRow[] makes = inventorytable.Select(filterStr);

                for (int i = 0; i < makes.Length; i++)
                {
                    makes[i]["Make"] = "Yugos";
                }


            }
        }
    }


    public class Car
    {
        public int ID { get; set; }
        public string PetName { get; set; }
        public string Make { get; set; }
        public string Color { get; set; }
    }

}
