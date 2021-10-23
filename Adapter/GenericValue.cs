using System;
using System.Collections.Generic;
using System.Text;
using static Adapter.Dimensions;

namespace Adapter
{
    public static class Dimensions
    {
        public interface IInteger
        {
            int Value { get; }
        }
        public class Two : IInteger
        {
            public int Value => 2;
        }
        public class Three : IInteger
        {
            public int Value => 3;
        }
    }
    public class Vector<TSelf, T, D>
        where D : IInteger, new()
        where TSelf : Vector<TSelf, T, D>, new()
    {
        protected T[] data;
        public Vector()
        {
            data = new T[new D().Value];
        }
        public Vector(params T[] values)
        {
            var requiredSize = new D().Value;
            data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                data[i] = values[i];
        }
        public T this[int index]
        {
            get => data[index];
            set => data[index] = value;
        }
        public T X
        {
            get => data[0];
            set => data[0] = value;
        }
        public static TSelf Create(params T[] values)
        {
            var result = new TSelf();

            var requiredSize = new D().Value;
            result.data = new T[requiredSize];

            var providedSize = values.Length;

            for (int i = 0; i < Math.Min(requiredSize, providedSize); ++i)
                result.data[i] = values[i];

            return result;
        }
    }

    public class VectorOfInt<TSelf, D> : Vector<TSelf, int, D>
        where TSelf : VectorOfInt<TSelf, D>, new()
        where D : IInteger, new()
    {
        public VectorOfInt()
        {

        }
        public VectorOfInt(params int[] values) : base(values)
        {

        }
        public static VectorOfInt<TSelf, D> operator +
            (VectorOfInt<TSelf, D> lhs, VectorOfInt<TSelf, D> rhs)
        {
            var result = new VectorOfInt<TSelf, D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
            return result;
        }
    }
    public class VectorOfFloat<TSelf, D> : Vector<TSelf, float, D>
        where TSelf : Vector<TSelf, float, D>, new()
        where D : IInteger, new()
    {
        public VectorOfFloat()
        {

        }
        public VectorOfFloat(params float[] values) : base(values)
        {

        }
        public static VectorOfFloat<TSelf, D> operator +
            (VectorOfFloat<TSelf, D> lhs, VectorOfFloat<TSelf, D> rhs)
        {
            var result = new VectorOfFloat<TSelf, D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }
            return result;
        }
    }
    public class Vector2i : VectorOfInt<Vector2i, Two>
    {
        public Vector2i()
        {

        }
        public Vector2i(params int[] values) : base(values)
        {

        }
        public override string ToString()
        {
            return $"{String.Join(", ", data)}";
        }
    }
    public class Vector3f : VectorOfFloat<Vector3f, Three>
    {
        public Vector3f()
        {

        }
        public Vector3f(params float[] values) : base(values)
        {

        }
        public override string ToString()
        {
            return $"{String.Join(", ", data)}";
        }
    }
}