using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp5
{
    public static class fewerew  // сначала объявляем публичнай статический метод, название класса, в моей версии роли не играет, возможно последнее зря написал
    {
        public static int CharCount(this string str, char c) // Затем вот такая конструкция, где тип перед this и будет значить расширяемый тип
        {

            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c) 
                    counter++;
            }
            return counter;
        }

        public static void SayHello(this string str, int a, int b, int c) // тоже дополнительный метод для string
        {
            MessageBox.Show($"Hello ALL!!!!!!!!{a}!!{c}!!!!!!{b}!!!!"); 
        }
        public static void Say(this int number, int a, int b, int c) // а, тут уже расширяем тип int 
        {
            MessageBox.Show($"!!!!!!{a}!!{c}!!!!!!{b}!!!!");
        }
    }
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string Str1 = "Bu Bu Bu";
            textBox1.Text += Str1.CharCount(' ');
            Str1.SayHello(1, 2, 3);
            int puk = 3;
            puk.Say(12, 12, 12);
        }




            
    }
}
