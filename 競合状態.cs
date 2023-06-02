using System;
using System.Threading;

namespace индексаторы
{
    class Program
    {
        class Someclass
        {
            Random rnd = new Random();
            int acc;
            Object obj = new object();
            public int Acc
            {
                set
                {
                    if (acc > 0 && acc < 100)
                        acc = value;
                }
                get
                {
                    return acc;
                }
            }
            public Someclass(int acc)
            {
                this.acc = acc;
            }

            public void add()
            {
                for (int i = 0; i < 100; i++)
                {

                    lock (obj) {
                        int tmp = acc;
                        tmp++;
                        Thread.Sleep(rnd.Next(50, 100));
                        acc = tmp;
                        Console.WriteLine($"acc = {acc}, {Thread.CurrentThread.Name}");
                    }
                }
            }
        }


        static void Main(string[] args)
        {
            Someclass sc1 = new Someclass(0);
            Thread thr1 = new Thread(sc1.add);
            Thread thr2 = new Thread(sc1.add);
            thr1.Name = "thr-1";
            thr2.Name = "thr-2";
            thr1.Start();
            thr2.Start();

        }
    }
}
