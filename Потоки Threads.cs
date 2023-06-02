﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;

namespace parametrizedthread
{

    class Program1 {
        double a = 2;

       
    }


    
    class Program
    {
        static void Main(string[] args)
        {
            var th = new Thread(ExecuteInForeground);
            th.Start(10000);
            Thread.Sleep(1000);
            Console.WriteLine("Main thread ({0}) exiting...",
                              Thread.CurrentThread.ManagedThreadId);

            Console.ReadKey();

        }

        private static void ExecuteInForeground(Object obj)
        {
            int interval;
            try
            {
                interval = (int)obj;
            }
            catch (InvalidCastException)
            {
                interval = 5000;
            }
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
            } while (sw.ElapsedMilliseconds <= interval);
            sw.Stop();
        }
    }

}

