using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                string PathToFolder = string.Format(@"c:\");
                string[] allfiles = Directory.GetFiles(PathToFolder, "*sys", SearchOption.AllDirectories);

                foreach (string filename in allfiles)
                {
                    textBox1.Text += filename + "\r\n";
                    Console.WriteLine(filename);
                }
            }
            catch
            {
                MessageBox.Show("hello");
            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void b1_Click(object sender, EventArgs e)
        {
            try
            {
                string PathToFolder = string.Format(@"c:\");
                string[] allfiles = Directory.GetFiles(PathToFolder, "*sys", SearchOption.AllDirectories);


                foreach (string filename in allfiles)
                {
                    textBox1.Text += filename + "\r\n";
                    Console.WriteLine(filename);
                }
            }
            catch
            {
                MessageBox.Show("hello");
            }
        }

        public void recSearch()
        {

        }
        private void b2_Click(object sender, EventArgs e)
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox1.Location = new System.Drawing.Point(3, 3);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(539, 104);
            this.textBox1.TabIndex = 1;

            //MessageBox.Show(filePath);
            string PathToFolder = @"%userprofile%"; //rawstring
            var filePath = Environment.ExpandEnvironmentVariables(PathToFolder);
            IEnumerable<string> allfiles = Directory.EnumerateFiles(filePath, ".\\", SearchOption.AllDirectories);


            // В отличие от этого
            //string[] allfiles = Directory.GetFiles(PathToFolder, "*sys", SearchOption.AllDirectories);

            foreach (string filename in allfiles)
            {
                //Console.WriteLine(filename);
                textBox1.Text += filename;
            }

            // поиск файлов начинается сразу до получения всего списка файлов
            //Thread myThread = new Thread(new ThreadStart(recSearch));

            //myThread.Start();
           


        }
    }
}
