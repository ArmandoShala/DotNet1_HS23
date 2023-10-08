using System.Drawing;
using DN3;

namespace DN4
{
    public abstract class Orb
    {
        public const double G = 30; //6.673e-11
        private const double Dt = 1.5;
        protected Bitmap bitmap;

        public Vector Velocity { get; set; }
        public Vector Pos { get; set; }

        public double Mass { get; set; }

        public string Name { get; }

        public abstract void Draw(Graphics g);

        public Orb(string name, double x, double y, double vx, double vy, double m)
        {
            if (name != "")
            {
                bitmap = (Bitmap)Image.FromFile($"{name}.gif");
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            }
            Velocity = new Vector(vx, vy, 0);
            Pos = new Vector(x, y, 0);
            Name = name;
            Mass = m;
        }

        public virtual void CalcVelocity(IList<Orb> space)
        {
            var a = new Vector(0, 0, 0); //f�r Gesamtbeschleunigung
            foreach (var other in space)
            {
                if (other == this) continue;
                var r = other.Pos - Pos;
                var forceMagnitude = G * (Mass * other.Mass) / Math.Pow(r.Magnitude, 2);
                var force = r.Normalize() * forceMagnitude;
                a += force / Mass;
            }
            Velocity += a;
        }

        public void Move() => Pos += Velocity * Dt;

        public override string ToString() => Name;
    }
}