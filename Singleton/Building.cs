using System;
using System.Collections.Generic;
using System.Text;

namespace Singleton
{
    sealed class BuildingContext : IDisposable
    {
        public int WallHeight;
        private static Stack<BuildingContext> stack = new Stack<BuildingContext>();
        static BuildingContext()
        {
            stack.Push(new BuildingContext(0));
        }
        public BuildingContext(int wallHeight)
        {
            WallHeight = wallHeight;
            stack.Push(this);
        }
        public static BuildingContext Current => stack.Peek();
        public void Dispose()
        {
            if (stack.Count > 1)
                stack.Pop();
        }
    }
    class Building
    {
        public List<Wall> Walls = new List<Wall>();
        public override string ToString()
        {
            var sb = new StringBuilder();
            foreach (var wall in Walls)
                sb.AppendLine(wall.ToString());
            return sb.ToString();
        }
    }
    class Wall
    {
        public Point start, end;
        public int height;
        public Wall(Point start, Point end)
        {
            this.start = start;
            this.end = end;
            height = BuildingContext.Current.WallHeight;
        }
        public override string ToString()
        {
            return $"{nameof(start)}: {start}, {nameof(start)}: {start}, {nameof(height)}: {height}";
        }
    }
    struct Point
    {
        private int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public override string ToString()
        {
            return $"{nameof(x)}: {x}, {nameof(y)}: {y}";
        }
    }
}
