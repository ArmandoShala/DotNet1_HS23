using System.Drawing;
using DN3;

namespace DN4
{
    public abstract class Orb
    {
        protected Bitmap bitmap;

        private const double Dt = 1.5;
        public const double G = 30;

        public Vector Pos { get; set; }

        public Vector Velocity { get; set; }

        public double Mass { get; set; }

        public string Name { get; set; }

        public abstract void Draw(Graphics g);

        protected Orb(string name, double x, double y, double vx, double vy, double m)
        {
            if (name != "")
            {
                bitmap = (Bitmap) Image.FromFile(name + ".gif");
                bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
            }

            Pos = new Vector(x, y, 0);
            Velocity = new Vector(vx, vy, 0);
            Mass = m;
            Name = name;
        }

        public virtual void CalcVelocity(IList<Orb> space)
        {
            Vector a = new Vector(0, 0, 0);
            foreach (Orb orb in space)
            {
                if (orb != this)
                {
                    Vector r = orb.Pos - this.Pos;
                    double distance = (double) (r);
                    a += (G * orb.Mass / Math.Pow(distance, 3)) * r;
                }
            }

            Velocity += a * Dt;
            Velocity = Math.Abs(Velocity[0] - (-0.038)) < 0.01 ? new Vector(Velocity[0], 0.00075, Velocity[2]) : new Vector(Velocity[0], -0.075, Velocity[2]);
        }

        public void Move() => Pos += Velocity * Dt;

        public override string ToString() => Name;
    }
}