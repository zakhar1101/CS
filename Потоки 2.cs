using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;
using System.Diagnostics;


namespace myapp234
{
    class Program
    {


        static void print_any()
        {
            double acc = 0;
            while (acc < 0.001)
            {
                acc += 0.00001;
                Console.WriteLine(acc);
            }
            Console.WriteLine("print_any is end");
        }


        static void newFunction()
        {
            var sw = Stopwatch.StartNew();
            Console.WriteLine("Thread {0}: {1}, Priority {2}",
                              Thread.CurrentThread.ManagedThreadId,
                              Thread.CurrentThread.ThreadState,
                              Thread.CurrentThread.Priority);


            do
            {
                Console.WriteLine("Thread {0}: Elapsed {1:N2} seconds",
                                  Thread.CurrentThread.ManagedThreadId,
                                  sw.ElapsedMilliseconds / 1000.0);
                Thread.Sleep(500);
            } while (sw.ElapsedMilliseconds <= 5000);
            sw.Stop();
        }


        static void Main(string[] args)
        {

            // The following example demonstrates how to use 
            // the Stopwatch class to determine the execution time for an application.
            //Stopwatch stopWatch = new Stopwatch();
            //stopWatch.Start();
            //Thread.Sleep(3000);


            /*
            Thread newThread = new Thread(new ThreadStart(print_any));
            newThread.Start();
            Thread.Sleep(0);

            */


            Thread thread2 = new Thread(newFunction);
            //Console.WriteLine("Main is end");
            //Thread newThreadNumberTwo = new Thread(newFunction);
            thread2.Start();

            /*
            for (int i = 0; i < 4; i++)
            {
                Console.WriteLine("Main thread: Do some work.");
                Thread.Sleep(0);
            }
            */
            Console.WriteLine("Main thread: Call Join(), to wait until ThreadProc ends.");
            /*
            newThread.Join();
            Console.WriteLine("Main thread: ThreadProc.Join has returned.  Press Enter to end program.");
            Console.ReadLine();
            */
            // Get the elapsed time as a TimeSpan value.
            //TimeSpan ts = stopWatch.Elapsed;
            // Format and display the TimeSpan value.
            //string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            //    ts.Hours, ts.Minutes, ts.Seconds,
            //    ts.Milliseconds / 10);
            //Console.WriteLine("elapsedTime: ", ts.Milliseconds);
            //Console.WriteLine("RunTime " + elapsedTime);


            //Thread.Sleep(10000);
            Console.WriteLine("End");
            Console.ReadKey();
            
        }
    }
}
