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
    public partial class picture : Form
    {
        Graphics gr;
        int cc = 2;
        public picture()
        {
            InitializeComponent();
            BackColor = Color.White;
            gr = pictureBox1.CreateGraphics();

            /*
            int n = pictureBox1.Width;
            int Npr = 2;
            int Rad = 2;
            int WIDTH = 6;

            string ss1 = "";


            
            double[,] xy = new double[n, n];


            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    xy[i, j] = (Npr * (Math.Sqrt(Math.Pow(Rad, 2) - Math.Pow(WIDTH * (i / n) - (WIDTH / 2.0), 2) - Math.Pow(WIDTH * (j / n) - (WIDTH / 2.0), 2))));
                    ss1 += xy[i, j].ToString();
                        
                }
                ss1 += "\n";
            }
            MessageBox.Show(ss1);
            */
            
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Lime);
            int x = e.X;
            int y = e.Y;

            int radius = 10;    

            //gr.DrawEllipse(pen, x - radius, y - radius, 2*radius, 2*radius);
            gr.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
            cc = 1;
            //gr.DrawLine(pen, x, 0, x, pictureBox1.Height);
            //gr.DrawLine(pen, 0, y, pictureBox1.Width, y);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

            cc = 2;






        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            Pen pen = new Pen(Color.Red, 2);
            SolidBrush brush = new SolidBrush(Color.Lime);
            int x = e.X;
            int y = e.Y;

            int radius = 10;


            if (cc == 1)
                gr.FillEllipse(brush, x - radius, y - radius, 2 * radius, 2 * radius);
        }
    }
}
