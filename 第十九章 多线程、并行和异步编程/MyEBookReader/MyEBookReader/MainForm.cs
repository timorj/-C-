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
using System.Net;

namespace MyEBookReader
{
    public partial class MainForm : Form
    {
        private string theEBook;
        public MainForm()
        {
            InitializeComponent();
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            try
            {
                WebClient wc = new WebClient();
                wc.DownloadStringCompleted += (s, eArgs) =>
                {
                    theEBook = eArgs.Result;
                    txtBook.Text = theEBook;
                };

                //双城记
                wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/cache/epub/22002/pg22002.txt"));
                //wc.DownloadStringAsync(new Uri("http://www.gutenberg.org/files/98/98-8.txt"));

            }
            catch (Exception ex)
            {
                this.Text = ex.Message;
            }
        }

        private void btnGetStats_Click(object sender, EventArgs e)
        {
            //从电子书中获取单词
            string[] words = theEBook.Split(new char[] { ' ', '\u000A', ',', '.', ';', ':', '-', '?', '/' }, StringSplitOptions.RemoveEmptyEntries);

            string[] tenMostCommon = null;

            string longestWord = string.Empty;

            Parallel.Invoke(() =>
            {
                tenMostCommon = FindTenMostWords(words);
            }, ()=> {
                longestWord = FindLongestWord(words);
            });

            StringBuilder bookStatus = new StringBuilder("Ten most Common Words are:\n");
            foreach (string s in tenMostCommon)
            {
                bookStatus.AppendLine(s);
            }
            bookStatus.AppendFormat("Longest word is: {0}", longestWord);
            bookStatus.AppendLine();
            MessageBox.Show(bookStatus.ToString(), "Book Info");
        }
        private string[] FindTenMostWords(string[] words)
        {
            var frequencyOrder = from word in words where word.Length > 6 group word by word into g orderby g.Count() descending select g.Key;
            string[] commonWords = (frequencyOrder.Take(10)).ToArray();
            return commonWords;
        }
        private string FindLongestWord(string[] words)
        {
            return (from word in words orderby word.Length descending select word).FirstOrDefault(); ;
        } 
    }
}
