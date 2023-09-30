using System;

namespace DN3
{
    public struct Vector
    {
        double x, y, z;

        //Konstruktor
        public Vector(double x, double y, double z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }
        
        public static implicit operator Vector(double x) => new (x, 0, 0);

        public double this[int index]
        {
            get
            {
                return index switch
                {
                    0 => x,
                    1 => y,
                    2 => z,
                    _ => throw new ArgumentOutOfRangeException(nameof(index), "Nur [0, 2] möglich"),
                };

            }
            set
            {
                 _ = index switch
                {
                    0 => x = value,
                    1 => y = value,
                    2 => z = value,
                    _ => throw new ArgumentOutOfRangeException(nameof(index), "Nur [0, 2] möglich"),
                };
            }
        }

        public override string ToString()
        {
            return $"[{x:N1} {y:N1} {z:N1}]";
        }

        public override bool Equals(object? obj)
        {
            if (obj is not Vector vectorToCheck)
                return false;

            return NearlyEqual(x, vectorToCheck.x)
                   && NearlyEqual(y, vectorToCheck.y)
                   && NearlyEqual(z, vectorToCheck.z);
        }

        private static bool NearlyEqual(double a, double b)
        {
            const double epsilon = 1E-10; // depends, usually parameter
            const double minNormal = 2.2250738585072014E-308d;
            var absA = Math.Abs(a);
            var absB = Math.Abs(b);
            var diff = Math.Abs(a - b);
            if (a.Equals(b))
            {
                // shortcut, also handles infinities
                return true;
            }

            if (a == 0 || b == 0 || absA + absB < minNormal)
            {
                // a or b is zero or both are extremely close to it
                // relative error is less meaningful here
                return diff < (epsilon * minNormal);
            }

            // use relative error
            return diff / (absA + absB) < epsilon;
        }

        public override int GetHashCode() => HashCode.Combine(x, y, z);

        public static Vector operator +(Vector a, Vector b) =>
            new(a.x + b.x,
                a.y + b.y,
                a.z + b.z);

        public static Vector operator -(Vector a, Vector b) =>
            new(a.x - b.x,
                a.y - b.y,
                a.z - b.z);

        public static Vector operator *(Vector a, Vector b) =>
            new(a.y * b.z - a.z * b.y,
                a.z * b.x - a.x * b.z,
                a.x * b.y - a.y * b.x);
        
        public static Vector operator *(double scalar, Vector vector) =>
            new(scalar * vector.x,
                scalar * vector.y,
                scalar * vector.z);

        public static Vector operator *(Vector vector, double scalar) => scalar * vector;

        public static Vector operator /(double scalar, Vector vector) => 
            new(scalar / vector.x,
                scalar / vector.y,
                scalar / vector.z);

        public static Vector operator /(Vector vector, double scalar) =>
            new(vector.x / scalar,
                vector.y / scalar,
                vector.z / scalar);
        public static explicit operator double(Vector v) => Math.Sqrt(v.x * v.x + v.y * v.y + v.z * v.z);

    }

    internal class MainClass
    {
        public static void Test()
        {
            Vector a = new Vector(1, 2, 3);
            Vector b = new Vector(4, 5, 6);
            Vector c = a * b;
            Console.WriteLine(c);
        }

        public static void Main(string[] args) {
           Test();
        }
    }
}