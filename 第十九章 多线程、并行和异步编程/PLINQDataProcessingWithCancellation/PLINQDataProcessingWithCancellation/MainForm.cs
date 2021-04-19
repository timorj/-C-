using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;
namespace PLINQDataProcessingWithCancellation
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnExecute_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() =>
            {
                ProcessIntData();
            });
        }

        private void ProcessIntData()
        {
            int[] source = Enumerable.Range(1, 100000000).ToArray();
            int[] modThreeIsZero = null;
            try
            {
                modThreeIsZero = (from i in source.AsParallel().WithCancellation(cancelToken.Token) where i % 3 == 0 orderby i descending select i).ToArray();

                MessageBox.Show(string.Format("Found {0} numbers that match query!", modThreeIsZero.Count()));

            }
            catch (OperationCanceledException ex) 
            {
                this.Invoke(new Action(() =>
                {
                    this.Text = ex.Message;
                }));
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
