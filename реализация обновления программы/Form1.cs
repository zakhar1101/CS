using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Reflection;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        private string[] files;
        private int number;
        private Image oldImage;
        public static string[] args;
        WebClient client = new WebClient();

        public Form1()
        {
            InitializeComponent();
            pictureBox1.AllowDrop = true;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            
            pictureBox1.DragEnter += new DragEventHandler(panel_DragEnter);
            pictureBox1.DragDrop += new DragEventHandler(panel_DragDrop);
            number = 0;

            button1.Enabled = false;
            button2.Enabled = false;
            Text = "gifsReader";
           

        }

        void panel_DragEnter(object sender, DragEventArgs e)
        {
            //if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Move;
            else if (e.Data.GetDataPresent(DataFormats.Bitmap)) e.Effect = DragDropEffects.Move;
        }

        void panel_DragDrop(object sender, DragEventArgs e)
        {
            //MessageBox.Show("this message");
            if (e.Data.GetDataPresent(DataFormats.Bitmap))
            {
                Bitmap bmp = (Bitmap)e.Data.GetData(DataFormats.Bitmap);
                Graphics g = Graphics.FromImage(bmp);
                //panel1.BackgroundImage = bmp;
                pictureBox1.Image = bmp;

            }



            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file_path in files)
                {
                    //textBox1.Text += $"{file_path}\r\n";
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromFile(file_path);
                    //panel1.BackgroundImage = Image.FromFile(file_path);
                }

            }




        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if ((DialogResult == DialogResult.OK)) e.Cancel = true;
        
            /*
            if (MessageBox.Show("Закрыть? ", "Message", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.No)
                e.Cancel = true;
            else
                e.Cancel = false;
            */
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                button1.Enabled = false;
                return;
            }
            number--;
            if (number == -1) number = files.Length - 1;
            //oldImage = pictureBox1.Image;
            //if (oldImage != null) // Если oldImage не равна null освобождаем ресурсы :)
            //    ((IDisposable)oldImage).Dispose();

            pictureBox1.Image = Image.FromFile(files[number]);

            

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (files.Length == 0)
            {
                button2.Enabled = false;
                return;
            }
            number++;
            if (number == files.Length) number=0;
            //oldImage = pictureBox1.Image;
            //if (oldImage != null) // Если oldImage не равна null освобождаем ресурсы :)
            //    ((IDisposable)oldImage).Dispose();

            MessageBox.Show(files[number]);
            pictureBox1.Image = Image.FromFile(files[number]);


        }

        private void button3_Click(object sender, EventArgs e)
        {

            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    // получаем все файлы
                    files = Directory.GetFiles(fbd.SelectedPath);

                    // перебор полученных файлов
                    var gifs = from item in files 
                               where (new FileInfo(item)).Extension == ".gif"
                               orderby item 
                               select item;
                    //var gifsext = from item in files
                    //              where item.Any()
                    //              select 
                    files = gifs.ToArray();
                    foreach (string file in files)
                    {
                        FileInfo fileinfo1 = new FileInfo(file);
                        ListViewItem lvi = new ListViewItem();
                        // установка названия файла
                        lvi.Text = file.Remove(0, file.LastIndexOf('\\') + 1);
                        lvi.ImageIndex = 2; // установка картинки для файла
                                            // добавляем элемент в 
                        listView1.Items.Add(lvi);
                    }

                    // MessageBox.Show("Files found: " + files.Length.ToString(), "Message");
                }
            }

            try
            {
                if (files?.Length != 0)
                {
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    pictureBox1.Image = Image.FromFile(files[0]);
                    oldImage = pictureBox1.Image;
                    button1.Enabled = true;
                    button2.Enabled = true;
                }
            }
            catch
            {
                File.AppendAllText(@"C:\Users\User\Desktop\output.txt", "Массив с названиями файлов принял значение null\n");
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            var oldImage = pictureBox1.Image;
            if (oldImage != null) // Если oldImage не равна null освобождаем ресурсы :)
                ((IDisposable)oldImage).Dispose();
        }

        private void listView1_Click(object sender, EventArgs e)
        {
            var firstSelectedItem = listView1.SelectedItems[0];
            //MessageBox.Show(firstSelectedItem.Text);
            var lfi = firstSelectedItem.Text;
            var res = files.Where(p => p.Split("\\")[^1] == lfi).OrderBy(p =>p);
            string[] result = res.ToArray();
            pictureBox1.Image = Image.FromFile(result[0]);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bool start = Class1.OK();
            if (start)
            {
                string curver = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                string version = client.DownloadString("https://raw.githubusercontent.com/user9959/myapp/main/version.txt");
                MessageBox.Show($"curver: {curver}, version: {version}", "update", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation);

                if (curver != version.Trim())
                {
                    MessageBox.Show("Обновитесь пожалуйста", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    client.DownloadFile("https://raw.githubusercontent.com/user9959/myapp/main/1428332734.png", "picutre.png");
                    Application.Exit();
                }
                //Cmd();
            }
        }

        private void Cmd()
        {
            throw new NotImplementedException();
        }
    }
}
