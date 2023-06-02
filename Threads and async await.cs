using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;



namespace currentreferencethread
{
    class Program
    {
        public static void Main()
        {
            // var th = new Thread(ExecuteInForeground);

            // th.Start();

            // Thread.Sleep(1000);
            // Console.WriteLine("Main thread ({0}) exiting...",
            //                  Thread.CurrentThread.ManagedThreadId);
            // Console.ReadKey();
        }

        static void func1()
        {

        }
        https://jp.pornhub.com/view_video.php?viewkey=ph601c0b310fddd
        https://jp.pornhub.com/view_video.php?viewkey=ph60c421bd16cef
        https://jp.pornhub.com/view_video.php?viewkey=ph5d3f5ff09f8db
        https://jp.pornhub.com/view_video.php?viewkey=ph5f319808899e1
        https://jp.pornhub.com/view_video.php?viewkey=ph5edffc2fc3ff6   


        public static async void function()
        {
            Console.WriteLine("Hello");
            await Task.Run(() => func1);
        }


        private static void ExecuteInForeground()
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}", Thread.CurrentThread.ManagedThreadId, Thread.CurrentThread.ThreadState, Thread.CurrentThread.Priority);
            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }
        





        /*
        static Object obj = new Object();
        static void Main(string[] args)
        {
            
            Thread new1 = new Thread(myFunc);
            new1.IsBackground = true;
            new1.Start();
            

            Console.WriteLine("start");
            
            ThreadPool.QueueUserWorkItem(ShowThreadInformation);


            ar th1 = new Thread(ShowThreadInformation);
            th1.Start();
            var th2 = new Thread(ShowThreadInformation);
            th2.IsBackground = true;
            th2.Start();


            Thread.Sleep(500);
            ShowThreadInformation(null);

            

            Console.ReadKey();
        }


        static void myFunc()
        {
            Thread.Sleep(10000);
            Console.WriteLine("hello world");

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



    }

}
