﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Excel = Microsoft.Office.Interop.Excel;

namespace ExportDataToOfficeApp
{
    public partial class Form1 : Form
    {
        List<Car> carsInStock = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            carsInStock = new List<Car>()
            {
                new Car{ Color = "Green", Make = "VW", PetName = "Mary"},
                new Car{ Color = "Red", Make = "Saab", PetName = "Mel"},
                new Car{ Color = "Black", Make = "Ford", PetName = "Hank"},
                new Car{ Color = "Yellow", Make = "BMW", PetName = "Davie"}
            };
            UpdateGrid();

        }

        private void UpdateGrid()
        {
            dataGridCars.DataSource = null;
            dataGridCars.DataSource = carsInStock;
        }

        private void btnAddNewCar_Click(object sender, EventArgs e)
        {
            NewCarDialog d = new NewCarDialog();
            if(d.ShowDialog() == DialogResult.OK)
            {
                carsInStock.Add(d.theCar);
                UpdateGrid();
            }
        }

        private void btnExportToExcel_Click(object sender, EventArgs e)
        {
            ExportToExcel(carsInStock);
        }

        private void ExportToExcel(List<Car> carsInStock)
        {
            Excel.Application excelApp = new Excel.Application();
            excelApp.Workbooks.Add();
            excelApp.Visible = true;
            Excel._Worksheet worksheet = excelApp.ActiveSheet;

            worksheet.Cells[1, "A"] = "Make";
            worksheet.Cells[2, "B"] = "Color";
            worksheet.Cells[3, "C"] = "PetName";

            int row = 1;
            foreach (Car car in carsInStock)
            {
                row++;
                worksheet.Cells[row, "A"] = car.Make;
                worksheet.Cells[row, "B"] = car.Color;
                worksheet.Cells[row, "C"] = car.PetName;

            }

            worksheet.Range["A1"].AutoFormat(Excel.XlRangeAutoFormat.xlRangeAutoFormatClassic2);

            worksheet.SaveAs(string.Format(@"{0}\Inventory.xlsx", Environment.CurrentDirectory));
            excelApp.Quit();
            MessageBox.Show("The Inventory.xlsx has been saved to your app folder.","Export Complete!");
        }
    }
    public class Car
    {
        public string Color { get; set; }
        public string Make { get; set; }
        public string PetName { get; set; }
        public Car()
        {

        }
        public Car(string Color, string make, string petName)
        {
            this.Color = Color;
            this.Make = make;
            this.PetName = petName;
        }
    }
}
