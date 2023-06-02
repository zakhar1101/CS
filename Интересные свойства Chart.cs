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
    public partial class map : Form
    {
        public map()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //double a = -10, b = 10, h = 0.1, x, y1, y2;
            //chart1.Series[0].Points.Clear();
            //chart1.Series[1].Points.Clear();
            //x = a;


            //while (x <= b)
            //{
            //    y1 = Math.Sin(x);
            //    y2 = Math.Cos(x);
            //    chart1.Series[0].Points.AddXY(x, y1);
            //    chart1.Series[1].Points.AddXY(x, y2);
            //    x += h;
            //}
            map1 f2 = new map1();
            f2.Show();
            
        }
    }
}
