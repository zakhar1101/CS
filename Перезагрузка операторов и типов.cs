using System;

namespace reload_operators
{
    class Program
    {

        class Test
        {
            public int counter;

            public static implicit operator Test(int x)
            {
                return new Test { counter = x };
            }
            public static implicit operator int(Test counter)
            {
                return counter.counter;
            }


            public static Test operator ++(Test ojb1)
            {
                return new Test { counter = ojb1.counter + 1};
            }
            public static bool operator false(Test ojb1)
            {
                return true;
            }
            public static bool operator true(Test ojb1)
            {
                return false;
            }


            public static Test operator --(Test ojb1)
            {
                return new Test { counter = ojb1.counter + 1 };
            }
            public static bool operator <(Test ojb1, Test obj2)
            {
                return obj2.counter < ojb1.counter + 1;
            }
            public static bool operator >(Test ojb1, Test obj2)
            {
                return obj2.counter > ojb1.counter + 1;
            }

            public static Test operator +(Test ojb1, Test obj2)
            {
                return new Test { counter = ojb1.counter + obj2.counter };
            }

            public static Test operator -(Test ojb1, Test obj2)
            {
                return new Test { counter = ojb1.counter - obj2.counter };
            }

            public static Test operator *(Test ojb1, Test obj2)
            {
                return new Test { counter = ojb1.counter * obj2.counter };
            }

            public static Test operator /(Test ojb1, Test obj2)
            {
                return new Test { counter = ojb1.counter / obj2.counter };
            }

        }
        static void Main(string[] args)
        {
            Test p1 = new Test { counter = 3 };
            Test p2 = new Test { counter = 33 };
            Test p3 = p1 + p2;
            Console.WriteLine(p3);
            Test p4 = 4;
            int i1 = p4;

            Console.WriteLine(i1);
        }
    }
}
