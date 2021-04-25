using System;

namespace Factory_Class
{
    
    public class Point
    {
        private readonly double x, y;

        
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"X: {x}, Y: {y}";
        }
        public static class Factory
        {
            public static Point NewCaresianPoint(double x, double y)
            {
                return new Point(x, y);
            }
            public static Point NewPolarPoint(double rho, double theta)
            {
                return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
            var point = Point.Factory.NewCaresianPoint(2, 5);
            Console.WriteLine(point);
        }
    }
}
