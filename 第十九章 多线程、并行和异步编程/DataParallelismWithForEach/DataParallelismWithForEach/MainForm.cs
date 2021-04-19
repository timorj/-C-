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
using System.IO;

namespace DataParallelismWithForEach
{
    public partial class MainForm : Form
    {
        private CancellationTokenSource cancelToken = new CancellationTokenSource();
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnProcessImages_Click(object sender, EventArgs e)
        {
            Task.Factory.StartNew(() => {
                ProcessFiles();
            });          
        }

        private void ProcessFiles()
        {
            ParallelOptions parOps = new ParallelOptions();
            parOps.CancellationToken = cancelToken.Token;
            parOps.MaxDegreeOfParallelism = System.Environment.ProcessorCount;




            string[] files = Directory.GetFiles(@"G:\高程数据\裁剪数据\区块2\区块2_Level_11.tif", "*.jpg", SearchOption.AllDirectories);
            string newDir = @"D:\Users\hands\Desktop\ParalleismTest";
            string file = files[0];
            DirectoryInfo s = Directory.GetParent(file);
            Console.WriteLine(s.Parent);
            Directory.CreateDirectory(newDir);
            try
            {

                Parallel.ForEach(files, parOps , currentFile =>
                {
                    parOps.CancellationToken.ThrowIfCancellationRequested();

                    string fileName = Path.GetFileName(currentFile);
                    string fileDirectory = Path.GetDirectoryName(currentFile);
                    
             
                    using (Bitmap bitmap = new Bitmap(currentFile))
                    {
                        bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                        bitmap.Save(Path.Combine(newDir, fileName));

                    //this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                }
                //子线程更新主窗体ui
                this.Invoke(new Action(() =>
                    {
                        this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                    }));
                });
            }
            catch(OperationCanceledException ex)
            {
                this.Invoke(new Action(() => { this.Text = ex.Message; }));
            }
            
          /*  foreach (string currentFile in files)
            {
                string fileName = Path.GetFileName(currentFile);

                using (Bitmap bitmap = new Bitmap(currentFile))
                {
                    bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
                    bitmap.Save(Path.Combine(newDir, fileName));

                    //this.Text = string.Format("Processing {0} on thread {1}", fileName, Thread.CurrentThread.ManagedThreadId);
                }
            }*/

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancelToken.Cancel();
        }
    }
}
