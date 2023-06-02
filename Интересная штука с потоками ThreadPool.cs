using System;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;


namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static int in1 = 0;
        /*
        static Object obj = new Object();

        public static void Main()
        {
            ThreadPool.QueueUserWorkItem(ShowThreadInformation);
            var th1 = new Thread(ShowThreadInformation);
            th1.Start();
            var th2 = new Thread(ShowThreadInformation);
            th2.IsBackground = true;
            th2.Start();
            Thread.Sleep(500);
            ShowThreadInformation(null);
        }

        private static void ShowThreadInformation(Object state)
        {
            lock (obj)
            {
                var th = Thread.CurrentThread;
                Console.WriteLine("Managed thread #{0}: ", th.ManagedThreadId);
                Console.WriteLine("   Background thread: {0}", th.IsBackground);
                Console.WriteLine("   Thread pool thread: {0}", th.IsThreadPoolThread);
                Console.WriteLine("   Priority: {0}", th.Priority);
                Console.WriteLine("   Culture: {0}", th.CurrentCulture.Name);
                Console.WriteLine("   UI culture: {0}", th.CurrentUICulture.Name);
                Console.WriteLine();
            }
        }

        */


        public Form1()
        {
            InitializeComponent();

            //FormBorderStyle = FormBorderStyle.None;
            //WindowState = FormWindowState.Maximized;
            //BackColor = Color.Lime;
            //TransparencyKey = Color.Lime;
            BackColor = Color.Lime;
            //this.Opacity = 0.3;
            //button1_Click();
            //button1.BackColor = Color.Black;
        }

        private void button1_Click()
        {
            // For each screen, add the screen properties to a list box.
            var ee = Screen.AllScreens;
            TextBox t1 = new TextBox();

            t1.Text = "";
            foreach (var screen in Screen.AllScreens)
            {
                t1.Text += ee.ToString();
            }
            Controls.Add(t1);
        }
        

        // Объект заглушка
        static object locker = new object();
        public static void func(object sender)
        {

            //Button b = sender as Button;
            lock (locker)
            {
                //in1++;

                in1++;
                //(sender as Button).BackColor = System.Drawing.Color
                //    .FromArgb(255-in1, 255, 255, 255);
                //sender.Opacity = (255 - in1) / 255;
                //(sender as Button).BackColor = Color.Red;
                Thread.Sleep(50);
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Thread.Sleep(2000);
            for (int i = 0; i < 254; i++)
            {
                Thread a = new Thread(func);
                // Thread a = new Thread(func);
                a.IsBackground = true;
                a.Start();
                // a.Join();
            }
            
            button2.BackColor = Color.Red;
            
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
