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
    public static class fewerew
    {
        public static int CharCount(this string str, char c)
        {

            int counter = 0;
            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == c) 
                    counter++;
            }
            return counter;
        }

        public static void SayHello(this string str, int a, int b, int c)
        {
            MessageBox.Show($"Hello ALL!!!!!!!!{a}!!{c}!!!!!!{b}!!!!"); 
        }
        public static void Say(this int number, int a, int b, int c)
        {
            MessageBox.Show($"!!!!!!{a}!!{c}!!!!!!{b}!!!!");
        }
    }

    class Person
    {
        string[] people = new string[] { "Akiko", "Misako", "Li", "Sasha" };


        string name = "";
        string email = "";
        string phone = "";


        public string this[int index]
        {
            //set => people[index] = value;
            //get => people[index];
            set
            {
                people[index] = value;

            }
            get
            {
                return people[index];
            }

        }
        public string this[string index]
        {
            set
            {
                switch (index)
                {
                    case "name": name = value;
                        break;
                    case "email": email = value;
                        break;
                    case "phone": phone = value;
                        break;
                    default:
                        break;
                }
            }
            get
            {
                switch (index)
                {
                    case "name": return name;
                    case "email": return email;
                    case "phone": return phone;
                    default: throw new Exception("Unknown property name");
                }
            }
        }
    }
    class Matrix
    {
        int[,] numbers = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
        public int this[int i, int j] // это индексатор используется для того чтобы обращаться к объекту класса как массиву каких-либо сущностей
        {
            get
            {
                return numbers[i, j];
            }
            set
            {
                numbers[i, j] = value;
            }
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


            Person p1 = new Person();
            textBox1.Text += p1[2];
            p1["name"] = "Madoka";
            p1["email"] = "buka@google.com";
            p1["phone"] = "923742034";

            textBox1.Text += p1["name"];
            textBox1.Text += p1["email"];
            textBox1.Text += p1["phone"];

        }




            
    }
}
