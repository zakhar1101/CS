using System;
using System.Threading;


namespace SemaphorAndBarrier
{
    class Program
    {
        static Semaphore sm = new Semaphore(5, 5);
        
        
        static Random Rnd = new Random();
        static void somefunction(Object obj)
        {
			
            sm.WaitOne();
            Barrier br = (Barrier)obj;
            Console.WriteLine($"thread - {Thread.CurrentThread.Name} is running");
            //Thread.Sleep(Rnd.Next(100, 110));
            br.SignalAndWait();
            //Thread.Sleep(3000);
            Console.WriteLine($"thread - {Thread.CurrentThread.Name} is stoped");
            sm.Release();
        }
        static void Main(string[] args)
        {
            int count = 15;
            Barrier br = new Barrier(participantCount: 5);
            Thread[] thrArr = new Thread[count];
            for (int i = 0; i < count; i++)
            {
                thrArr[i] = new Thread(somefunction);
                thrArr[i].Name = $"thr-{i}";
                thrArr[i].Start(br);
            }
        }
    }
}
