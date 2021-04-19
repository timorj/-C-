using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using CommonSnappableTypes;
namespace MyExtendableApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void snapInModleToolStrip_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.FileName.Contains("CommonSnappableTypes"))
                    MessageBox.Show("CommonSnappableTypes has no snap-ins");
                else if (!LoadExternalModule(dlg.FileName))
                {
                    MessageBox.Show("Nothing implements IAppFunctionality");
                }
            }
        }

        private bool LoadExternalModule(string path)
        {
            bool foundSnapIn = false;
            Assembly asm = null;
            try
            {
                asm = Assembly.LoadFrom(path);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return foundSnapIn;
            }

            var theClassTypes = from t in asm.GetTypes() where t.IsClass && (t.GetInterface("IAppFunctionality") != null) select t;

            foreach (Type t in theClassTypes)
            {
                foundSnapIn = true;

                IAppFunctionality itfApp = (IAppFunctionality)Activator.CreateInstance(t);

                itfApp.DoIt();
                lstLoadedSnapIns.Items.Add(t.FullName);
                DisplayCompanyData(t);
            }
            return foundSnapIn;
        }

        private void DisplayCompanyData(Type t)
        {
            var compantInfos = from ci in t.GetCustomAttributes(false) where (ci.GetType() == typeof(CompanyInfoAttribute)) select ci;
            foreach (CompanyInfoAttribute ci in compantInfos)
            {
                MessageBox.Show(ci.CompanyUrl, string.Format("More info about {0} can be found here.", ci.CompanyName));

            }
        }
    }
}
