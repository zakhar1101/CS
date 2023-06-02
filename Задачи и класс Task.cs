using System;
using System.Net;
using System.IO;
using System.Threading.Tasks;
using System.Threading;
namespace ConsoleApp1
{
    class Program
    {


        static void Main(string[] args)
        {
            //Task t1 = RequestAsync("123");
            //t1.Start();

            //#######################################################################
            // Ожидание завершения задачи
            /*
            Task t1 = new Task(() => Console.WriteLine("Task1 is executed"));
            t1.Start();

            Task t2 = Task.Factory.StartNew(() => Console.WriteLine("Task2 is executed!"));
            Task t3 = Task.Run(() => Console.WriteLine("Task3 is executed"));

            t1.Wait();
            t2.Wait();
            t3.Wait();
            */

            /*
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task Starts");
                Thread.Sleep(1000);     // задержка на 1 секунду - имитация долгой работы
                Console.WriteLine("Task Ends");
            });
            task1.Start();  // запускаем задачу
            Console.WriteLine("Main Ends");
            task1.Wait();   // ожидаем выполнения задачи
            */
            //#######################################################################
            //Синхронный запуск задачи
            /*
            Console.WriteLine("Main Starts");
            // создаем задачу
            Task task1 = new Task(() =>
            {
                Console.WriteLine("Task Starts");
                Thread.Sleep(1000);
                Console.WriteLine("Task Ends");
            });
            task1.RunSynchronously(); // запускаем задачу синхронно
            Console.WriteLine("Main Ends"); // этот вызов ждет завершения задачи task1 
            */
            //#######################################################################
            // Задачи продолжения
            /*
            Task task1 = new Task(() =>
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
            });

            // задача продолжения - task2 выполняется после task1
            Task task2 = task1.ContinueWith(PrintTask);

            task1.Start();

            // ждем окончания второй задачи
            task2.Wait();
            Console.WriteLine("Конец метода Main");


            void PrintTask(Task t)
            {
                Console.WriteLine($"Id задачи: {Task.CurrentId}");
                Console.WriteLine($"Id предыдущей задачи: {t.Id}");
                Thread.Sleep(3000);
            }
            */

            //#######################################################################


            Task<int> sumTask = new Task<int>(() => Sum(4, 5));

            // задача продолжения
            Task printTask = sumTask.ContinueWith(task1 => PrintResult(task1.Result));

            sumTask.Start();

            // ждем окончания второй задачи
            printTask.Wait();
            Console.WriteLine("Конец метода Main");

            int Sum(int a, int b) => a + b;
            void PrintResult(int sum) => Console.WriteLine($"Sum: {sum}");



            //#######################################################################
            // Цепочка задачек
            Task task1 = new Task(() => Console.WriteLine($"Current Task: {Task.CurrentId}")); // Лямбда выражение

            // задача продолжения
            Task task2 = task1.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

            Task task3 = task2.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));


            Task task4 = task3.ContinueWith(t =>
                Console.WriteLine($"Current Task: {Task.CurrentId}  Previous Task: {t.Id}"));

            task1.Start();

            task4.Wait();   //  ждем завершения последней задачи
            Console.WriteLine("Конец метода Main");

            //Wait() блокирует вызывающий поток, в котором запущена задача, пока эта задача не завершит свое выполнение. 
            //task.Start();
            //t1.Wait();

            /*
            string text = "";
            string line = "";
            WebRequest request = WebRequest.Create(link);
            WebResponse response = request.GetResponse();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {

                    while ((line = reader.ReadLine()) != null)
                    {
                        text += line + "\n\n";
                    }

                }

            }

            using (FileStream fs = new FileStream("output.txt", FileMode.Append, FileAccess.Write))
            {
                (new StreamWriter(fs)).Write(text);
            }
            response.Close();


            Console.WriteLine("Запрос выполнен");
            Console.Read();
            */

        }

        private static async Task RequestAsync(string link)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(link);
            HttpWebResponse response = (HttpWebResponse)await request.GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    Console.WriteLine(reader.ReadToEnd());
                }
            }
            response.Close();
        }


    }
}
