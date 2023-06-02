using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace inferometer
{
    public partial class result_form : Form
    {
        //Graphics gr;
        Random rnd;
        double R1, R2, n, SizeM, lengthL, Alpha, Rm;
        int Resolution;

        //int A, B, C, D, E, F;
        //int cc = 2;

        public result_form()
        {
            InitializeComponent();
            readData();
            showResult();


            //this.Load += new EventHandler(Autorun);
            //System.Windows.Forms.Form f = System.Windows.Forms.Application.OpenForms["start"];
            
            //pictureBox1.BackColor = SystemColors.GrayText;

            //System.Threading.Thread.Sleep(1000);
            //MessageBox.Show("Сообщение");
            //Autorun();
            //MessageBox.Show("Сообщение");
            //button1_Click(, e);
            //Refresh();
            //MessageBox.Show(lengthL.ToString());
            //System.Drawing.Color col = System.Drawing.ColorTranslator.FromHtml("#FFCC66"); --> error
            //Color col = ColorTranslator.FromHtml("#FFCC66");
            //pen = new Pen(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)), 2
            //Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
            //SolidBrush brush = new SolidBrush(Color.Lime);
            // for ARGB
            //Color col2 = ColorConverter.ConvertFromString("#FFDFD991") as Color; // --> error
            //Color color = (Color)ColorConverter.ConvertFromString("#FFDFD9");

        }

        void showResult()
        {
            Bitmap bmp = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            rnd = new Random();
            //MessageBox.Show("Сообщение 0000123");
            //Graphics gr = pictureBox1.CreateGraphics();
            Graphics gr = Graphics.FromImage(bmp);

            SolidBrush brush;
            Color color;
            int number_blocks = Resolution;
            float width_block = (float)pictureBox1.Width / number_blocks;
            float height_block = (float)pictureBox1.Height / number_blocks;
            //gr.FillRectangle(new SolidBrush(Color.Lime), 0, 0, 300, 300);
            for (int y = 0; y < number_blocks; y += 1)
            {
                for (int x = 0; x < number_blocks; x += 1)
                {
                    color = Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256));
                    brush = new SolidBrush(color);
                    
                    gr.FillRectangle(brush, x * width_block, y * height_block, width_block, height_block);
                }
            }
            pictureBox1.Image = bmp;
            pictureBox1.Image.Save(@"result.png");
            //System.Threading.Thread.Sleep(3000);
        }

        void readData()
        {
            Form f = Application.OpenForms["start"];
            try
            {

                lengthL = Convert.ToDouble(((start)f).textBox1.Text);
                Resolution = Convert.ToInt32(((start)f).textBox2.Text);
                SizeM = Convert.ToDouble(((start)f).textBox3.Text);
                R1 = Convert.ToDouble(((start)f).textBox4.Text);
                R2 = Convert.ToDouble(((start)f).textBox5.Text);
                Alpha = Convert.ToDouble(((start)f).textBox6.Text);
                Rm = Convert.ToDouble(((start)f).textBox7.Text);
            }
            catch
            {
                MessageBox.Show("Что пошло не так сука!");
            }

        }
        /*
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Lime);
            float x = e.X;
            float y = e.Y;

            float radius = 0.5f;    
            //gr.FillEllipse(brush, )
            //gr.DrawEllipse(pen, x - radius, y - radius, 2 * radius, 2 * radius);
            gr.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
            cc = 1;
            //gr.DrawLine(pen, x, 0, x, pictureBox1.Height);
            //gr.DrawLine(pen, 0, y, pictureBox1.Width, y);
        }
        */

        /*
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            gr = pictureBox1.CreateGraphics();
            rnd = new Random();

            SolidBrush brush;

            float radius = 0;


            for (int i = 0; i < pictureBox1.Width; i++)
            {
                for (int j = 0; j < pictureBox1.Height; j++)
                {
                    brush = new SolidBrush(Color.FromArgb(rnd.Next(0, 256), rnd.Next(0, 256), rnd.Next(0, 256)));
                    gr.FillRectangle(brush, i - radius, j - radius, 2 * radius, 2 * radius);
                }
            }

        }
        */


        /*
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Lime);
            float x = e.X;
            float y = e.Y;
            
            float radius = 0.5f;


            if (cc == 1)
            {
                gr.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
            }
        }
        */

    }
}
