using System;

namespace SOLID_L
{
    public class Rectangle
    {
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public Rectangle()
        {

        }
        public Rectangle(int width, int height)
        {
            Width = width;
            Height = height;
        }
        public override string ToString()
        {
            return $"{nameof(Width)}: {Width}, {nameof(Height)}:{Height}";
        }
    }
    public class Square : Rectangle
    {
        public override int Width { set { base.Width = base.Height = value; } }
        public override int Height { set { base.Width = base.Height = value; } }

    }
    class Program
    {
        static public int Area(Rectangle r) => r.Width * r.Height;

        static void Main(string[] args)
        {
            Rectangle rc = new Rectangle(2, 3);
            Console.WriteLine($"{rc} has area of {Area(rc)}");

            Rectangle sq = new Square();
            sq.Width = 5;
            Console.WriteLine($"{sq} as an area of {Area(sq)}");

        }
    }
}
