using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace new123
{
    public class new1
    {



        private int min;
        private int max;
        private int acc;




        new1(int min, int max, int acc)
        {
            this.acc = acc;
            this.min = min;
            this.max = max;
        }
        new1(int acc)
        {
            this.acc = acc;
        }

        public static new1 operator ++(new1 c1)
        {

            if (c1.acc + 1 > c1.max)
            {
                throw new IndexOutOfRangeException();
            }
            else
            {
                return new new1(c1.acc, c1.min, c1.max) { acc = c1.acc + 1 };
            }        
        }
        public static new1 operator --(new1 c1) => new new1(c1.acc);
    }

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BackColor = Color.Red;
        }
    }
}
