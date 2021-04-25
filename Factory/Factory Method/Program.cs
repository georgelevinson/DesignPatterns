using System;

namespace Factory_Method
{
    public enum CoordinateSystem
    {
        Cartesian,
        Polar
    }
    public class Point
    {
        private double x, y;

        public static Point NewCaresianPoint(double x, double y)
        {
            return new Point(x, y);
        }
        public static Point NewPolarPoint(double rho, double theta)
        {
            return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }
        private Point(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }
    static class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
