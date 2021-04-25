using System;

namespace Prototype_Exercise
{
    interface IPrototype<T>
    {
        T DeepCopy();
    }
    public class Point : IPrototype<Point>
    {
        public int X, Y;
        public Point()
        {

        }
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point DeepCopy()
        {
            return new Point(X, Y);
        }
        public override string ToString()
        {
            return $"X coord: {X}, Y coord: {Y}";
        }
    }

    public class Line : IPrototype<Line>
    {
        public Point Start, End;
        public Line()
        {

        }
        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }
        public Line DeepCopy()
        {
            return new Line(Start.DeepCopy(), End.DeepCopy());
        }
        public override string ToString()
        {
            return $"Line starts at point {Start.ToString()}, lint ends at point {End.ToString()}";
        }
    }
    class Program
    {   
        static void Main(string[] args)
        {
            var line = new Line(new Point(3, 4), new Point(3, 10));
            var copy = line.DeepCopy();

            copy.End.X = 5;
            copy.Start.Y = 7;

            Console.WriteLine(line);
            Console.WriteLine(copy);
        }
    }
}
