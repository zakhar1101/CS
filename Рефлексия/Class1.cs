using System;

namespace ClassLibrary1
{
    public class Plane
    {
        private double x;
        private double y;
        private double z;

        public Plane()
        {
            x = 10;
            y = 10;
            z = 10;
        }
        public Plane(double x)
        {
            this.x = x;
        }
        public Plane(double x, double y) : this(x)
        {
            this.y = y;
        }
        public Plane(double x, double y, double z) : this(x, y)
        {
            this.z = z;
        }
        public void Show()
        {
            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
        }
        public double X { get { return x; } set { x = value; } }
        public double Y { get { return x; } set { x = value; } }
        public double Z { get { return x; } set { x = value; } }
    }

    
    public class test
    {
        private int x, y, z;
        public test()
        {

        }
        public test(int x,int y,int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        public void show()
        {
            Console.WriteLine($"x={x}\ny={y}\nz={z}");
        }
        public void say()
        {
            Console.WriteLine("Hello World!");
        }
    }

    class test2 : test
    {
        public test2(int x, int y, int z) : base(x, y, z)
        {

        }
    }

    class test3 : test
    {

    }
    
}
