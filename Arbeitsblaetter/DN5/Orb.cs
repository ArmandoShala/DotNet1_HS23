using DN3;
namespace DN5;

internal delegate void CollisionHandler(Orb o1);

public abstract class Orb
{
    public event CollisionHandler Collision;

    public bool IsDead { get; private set; }

    private const double G = 30; //6.673e-11
    private const double COLLISION_DISTANCE = 15.0;

    protected Bitmap bitmap;
    protected Vector posNew;
    protected Vector v0;
    protected string name;

    public Vector Pos { get; protected set; }

    public double Mass { get; }


    public abstract void Draw(Graphics g);

    public void Move() => Pos = posNew;

    public Orb(string name, double x, double y, double vx, double vy, double m)
    {
        bitmap = (Bitmap) Resources.ResourceManager.GetObject(name);
        bitmap.MakeTransparent(bitmap.GetPixel(1, 1));
        Pos = new Vector(x, y, 0);
        v0 = new Vector(vx, vy, 0);
        Mass = m;
        this.name = name;
    }

    public virtual void CalcPosNew(IList<Orb> space)
    {
        if (IsDead) return;
        var a = new Vector(0, 0, 0);
        foreach (var o in space)
        {
            if (o == this || o.IsDead) continue;
            var distance = o.Pos - Pos;
            var r = (double) distance;

            if (r < COLLISION_DISTANCE)
            {
                Collision?.Invoke(this);
            }

            a += (G * o.Mass / (r * r * r)) * distance;
        }

        const double t = 3d;
        posNew = Pos + v0 * t + t * t * a;
        v0 += t * a;
    }

    public override string ToString() => name;
}