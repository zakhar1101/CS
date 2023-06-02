using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json;


namespace question
{





    public partial class Form1 : Form
    {

        // про эти 5 переменных ниже есть пояснение
        RadioButton rb1;
        RadioButton rb2;
        RadioButton rb3;
        RadioButton rb4;
        RadioButton rb5;
        // счётчик правельных ответов
        int count = 0;

        // в аррай мы записываем максимальные баллы, но пока просто зодали массив
        int[] arr = new int[5];
        // тут думаю понятно
        public string password;


        // Выполняется самым первым
        public Form1()
        {
            InitializeComponent();
            // Скрыть тренировачный режим
            defult_mode();
            // Прочитать json файл
            Read();
        }

        // Кнопка старт
        private void button1_Click(object sender, EventArgs e)
        {
            // Снимает блокировка с кнопок завершить и начать заново
            button2.Enabled = true;
            button3.Enabled = true;

            // панели с вариантами ответов становятся доступными
            panel1.Enabled = true;
            panel2.Enabled = true;
            panel3.Enabled = true;
            panel4.Enabled = true;
            panel5.Enabled = true;

            // сама кнопка старт блокируется
            button1.Enabled = false;
        }

        public async void Read()
        {

            //using (StreamReader fs = new rr("user.json"))
            using (StreamReader fs = new StreamReader("user.json"))
            {
                string json = await fs.ReadToEndAsync();
                //MessageBox.Show(json.ToString());

                JsonDocument doc = JsonDocument.Parse(json);
                JsonElement root = doc.RootElement;


                // запись самого вопроса
                textBox6.Text = root[0].GetProperty("q1")[0].ToString();
                textBox7.Text = root[1].GetProperty("q2")[0].ToString();
                textBox8.Text = root[2].GetProperty("q3")[0].ToString();
                textBox9.Text = root[3].GetProperty("q4")[0].ToString();
                textBox10.Text = root[4].GetProperty("q5")[0].ToString();

                // запись вариантов ответов их всего 3
                radioButton1.Text = root[0].GetProperty("q1")[1].ToString();
                radioButton2.Text = root[0].GetProperty("q1")[2].ToString();
                radioButton3.Text = root[0].GetProperty("q1")[3].ToString();

                // запись вариантов ответов их всего 3
                radioButton4.Text = root[1].GetProperty("q2")[1].ToString();
                radioButton5.Text = root[1].GetProperty("q2")[2].ToString();
                radioButton6.Text = root[1].GetProperty("q2")[3].ToString();

                // запись вариантов ответов их всего 3
                radioButton7.Text = root[2].GetProperty("q3")[1].ToString();
                radioButton8.Text = root[2].GetProperty("q3")[2].ToString();
                radioButton9.Text = root[2].GetProperty("q3")[3].ToString();

                // запись вариантов ответов их всего 3
                radioButton10.Text = root[3].GetProperty("q4")[1].ToString();
                radioButton11.Text = root[3].GetProperty("q4")[2].ToString();
                radioButton12.Text = root[3].GetProperty("q4")[3].ToString();

                // запись вариантов ответов их всего 3
                radioButton13.Text = root[4].GetProperty("q5")[1].ToString();
                radioButton14.Text = root[4].GetProperty("q5")[2].ToString();
                radioButton15.Text = root[4].GetProperty("q5")[3].ToString();


                // правильный ответ хранится тут
                textBox1.Text = root[0].GetProperty("q1")[4].ToString();
                textBox2.Text = root[1].GetProperty("q2")[4].ToString();
                textBox3.Text = root[2].GetProperty("q3")[4].ToString();
                textBox4.Text = root[3].GetProperty("q4")[4].ToString();
                textBox5.Text = root[4].GetProperty("q5")[4].ToString();

                // Тут мы все баллы за вопросы
                arr[0] = root[0].GetProperty("q1")[5].GetInt32();
                arr[1] = root[1].GetProperty("q2")[5].GetInt32();
                arr[2] = root[2].GetProperty("q3")[5].GetInt32();
                arr[3] = root[3].GetProperty("q4")[5].GetInt32();
                arr[4] = root[4].GetProperty("q5")[5].GetInt32();

                password = root[5].GetProperty("key").GetString();
            }
        }

        // функция для обычного режима
        public void defult_mode()
        {
            tableLayoutPanel1.ColumnStyles[4].Width = 0;
        }

        // функция для тренеровочного режима
        public void training_mode()
        {
            tableLayoutPanel1.ColumnStyles[4].Width = tableLayoutPanel1.ColumnStyles[3].Width;
        }


        // кнопка завершить
        private void button2_Click(object sender, EventArgs e)
        {
            training_mode();
            try
            {

                if (textBox1.Text == rb1.Text)
                {
                    count += arr[0];
                }
                if (textBox2.Text == rb2.Text)
                {
                    count += arr[1];
                }
                if (textBox3.Text == rb3.Text)
                {
                    count += arr[2];
                }
                if (textBox4.Text == rb4.Text)
                {
                    count += arr[3];
                }
                if (textBox5.Text == rb5.Text)
                {
                    count += arr[4];
                }
                label6.Text = $"Результат: {count}";
            }
            catch (Exception e1)
            {
                // Если не все поля заполнены вывести это
                MessageBox.Show("Заполните все поля");
            }
        }

        // кнопка закрыть
        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        // Обработчики события для 1 ряда радиобатонов
        private void radioButton1_Click(object sender, EventArgs e)
        {
            // В rb1 запишется объект выбранного варианта ответа для первого вопроса(он запишется в rb1)
            rb1 = sender as RadioButton;
        }

        // Если нажали Тренеровочный режим
        private void тестовыйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Создать форму для поттверждения пароля
            EnterPassword enForm = new EnterPassword();
            // показать её
            enForm.Show();
            
        }

        // Если нажали обычный режим
        private void обычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            defult_mode();
        }


        // Обработчики события для 2 ряда радиобатонов
        private void radioButton4_Click(object sender, EventArgs e)
        {
            // В rb2 запишется объект выбранного варианта ответа для второго вопроса(он запишется в rb2)
            rb2 = sender as RadioButton;
        }

        // Обработчики события для 3 ряда радиобатонов
        private void radioButton7_Click(object sender, EventArgs e)
        {
            // В rb3 запишется объект выбранного варианта ответа для третьего вопроса(он запишется в rb3)
            rb3 = sender as RadioButton;
        }

        // Обработчики события для 4 ряда радиобатонов
        private void radioButton10_Click(object sender, EventArgs e)
        {
            // В rb4 запишется объект выбранного варианта ответа для четвёртого вопроса(он запишется в rb4)
            rb4 = sender as RadioButton;
        }

        // Обработчики события для 5 ряда радиобатонов
        private void radioButton13_Click(object sender, EventArgs e)
        {
            // В rb5 запишется объект выбранного варианта ответа для пятого вопроса(он запишется в rb5)
            rb5 = sender as RadioButton;
        }

        // Когда нажимаем начать занова
        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            radioButton4.Checked = false;
            radioButton5.Checked = false;
            radioButton6.Checked = false;
            radioButton7.Checked = false;
            radioButton8.Checked = false;
            radioButton9.Checked = false;

            radioButton10.Checked = false;
            radioButton11.Checked = false;
            radioButton12.Checked = false;
            radioButton13.Checked = false;
            radioButton14.Checked = false;
            count = 0;
            label6.Text = "";
            defult_mode();
        }
    }
}
