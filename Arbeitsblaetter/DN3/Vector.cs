namespace DN3;

public struct Vector
{
    private double _x, _y, _z;

    //Konstruktor
    public Vector(double x, double y = 0.0, double z = 0.0)
    {
        this._x = x;
        this._y = y;
        this._z = z;
    }
    
    public double Magnitude => Math.Sqrt(_x * _x + _y * _y + _z * _z);

    public Vector Normalize() => new(_x / Magnitude, _y / Magnitude, _z / Magnitude);

    public static implicit operator Vector(double x) => new (x, 0, 0);

    public double this[int index]
    {
        get
        {
            return index switch
            {
                0 => _x,
                1 => _y,
                2 => _z,
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Nur [0, 2] möglich"),
            };

        }
        set
        {
            _ = index switch
            {
                0 => _x = value,
                1 => _y = value,
                2 => _z = value,
                _ => throw new ArgumentOutOfRangeException(nameof(index), "Nur [0, 2] möglich"),
            };
        }
    }

    public override string ToString()
    {
        return $"[{_x:N1} {_y:N1} {_z:N1}]";
    }

    public override bool Equals(object? obj)
    {
        if (obj is not Vector vectorToCheck)
            return false;

        return NearlyEqual(_x, vectorToCheck._x)
               && NearlyEqual(_y, vectorToCheck._y)
               && NearlyEqual(_z, vectorToCheck._z);
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

    public override int GetHashCode() => HashCode.Combine(_x, _y, _z);

    public static Vector operator +(Vector a, Vector b) =>
        new(a._x + b._x,
            a._y + b._y,
            a._z + b._z);

    public static Vector operator -(Vector a, Vector b) =>
        new(a._x - b._x,
            a._y - b._y,
            a._z - b._z);

    public static Vector operator *(Vector a, Vector b) =>
        new(a._y * b._z - a._z * b._y,
            a._z * b._x - a._x * b._z,
            a._x * b._y - a._y * b._x);
        
    public static Vector operator *(double scalar, Vector vector) =>
        new(scalar * vector._x,
            scalar * vector._y,
            scalar * vector._z);

    public static Vector operator *(Vector vector, double scalar) => scalar * vector;

    public static Vector operator /(double scalar, Vector vector) => 
        new(scalar / vector._x,
            scalar / vector._y,
            scalar / vector._z);

    public static Vector operator /(Vector vector, double scalar) =>
        new(vector._x / scalar,
            vector._y / scalar,
            vector._z / scalar);
    public static explicit operator double(Vector v) => Math.Sqrt(v._x * v._x + v._y * v._y + v._z * v._z);

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