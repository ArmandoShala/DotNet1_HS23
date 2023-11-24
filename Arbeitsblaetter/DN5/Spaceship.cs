using System.Drawing;

namespace DN4
{
    public class Spaceship : Orb
    {
        public Spaceship(double x, double y, double vx, double vy, double m) : base("spaceship", x, y, vx, vy, m) { }

        public override void Draw(Graphics g) => g.DrawImage(bitmap, (float)Pos.X, (float)Pos.Y, bitmap.Width / 2, bitmap.Height / 2);
    }
}