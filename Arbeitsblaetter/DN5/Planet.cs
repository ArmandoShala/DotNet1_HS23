using System.Drawing;

namespace DN5
{
    public class Planet : Orb
    {
        public Planet(string name, double x, double y, double vx, double vy, double m) : base(name, x, y, vx, vy, m) { }

        public override void Draw(Graphics g) => g.DrawImage(bitmap, (float)Pos.X, (float)Pos.Y, bitmap.Width / 2, bitmap.Height / 2);
    }
}