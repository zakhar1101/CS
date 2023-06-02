using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test_dragdrop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel1.AllowDrop = true;

            panel1.DragEnter += new DragEventHandler(panel_DragEnter);
            panel1.DragDrop += new DragEventHandler(panel_DragDrop);
			
			
			
        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            else if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;
            else if (e.Data.GetDataPresent(DataFormats.Bitmap)) e.Effect = DragDropEffects.Move;
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                string text = (string)e.Data.GetData(DataFormats.Text);
                textBox1.Text = text + "\r\n";

            }
            else if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                Graphics g = Graphics.FromImage(bmp);
                panel1.BackgroundImage = bmp;
                pictureBox1.Image = bmp;
            
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file_path in files)
                {
                    textBox1.Text += $"{file_path}\r\n";
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromFile(file_path);
                    panel1.BackgroundImage = Image.FromFile(file_path);
                }

            }


        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
