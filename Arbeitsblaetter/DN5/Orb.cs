using System.Runtime.InteropServices;
using DN3;
using DN4;

namespace DN5;

public delegate void OrbDeleteHandler(Orb o1);

public abstract class Orb
{
    const double G = 30; //6.673e-11

    protected Bitmap bitmap;
    protected Vector posNew, pos;
    protected Vector v0;
    protected string name;
    protected double masse;
    protected int framecounter = -1;

    public event OrbDeleteHandler Deleter;

    public Vector Pos => pos;

    public Vector Velocity => v0;

    public double Mass => masse;
    public abstract void Draw(Graphics g);

    public void Move() => pos = posNew;

    public Orb(string name, double x, double y, double vx, double vy, double m)//, Func<> )
    {
        bitmap = new Bitmap(name + ".gif");
        bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
        pos = new Vector(x, y, 0);
        v0 = new Vector(vx, vy, 0);
        masse = m;
        this.name = name;
    }

    public virtual void CalcPosNew(IList<Orb> space)
    {
        var a = new Vector();

        if (framecounter >= 0)
        {
            framecounter--;
            if (framecounter == 0)
                Deleter(this);
        }
        else
        {
            foreach (var orb in space)
            {
                if (orb.Equals(this))
                    continue;
                var direction = orb.Pos - Pos;

                if (direction.Norm() <= 30)
                {
                    var list = this.GetType().GetCustomAttributes(typeof(ExplodableAttribute), true);
                    if (list.Length > 0)
                        explode();
                }

                a += G * orb.Mass * direction / Math.Pow(direction.Norm(), 3);
            }

            var t = 3;
            posNew = pos + v0 * t + (t * t) * a;
            v0 = v0 + t * a;
        }
    }

    private void explode()
    {
        bitmap = new Bitmap("explosion.gif");
        bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
        v0 /= 3;
        masse = 0;
        framecounter = 10;
        PlaySound("explosion.wav", (IntPtr)0, 1);
    }

    [DllImport("winmm.dll")]
    public static extern long PlaySound(String lpszName, IntPtr hModule, Int32 dwFlags);

    public override string ToString() => name;
}