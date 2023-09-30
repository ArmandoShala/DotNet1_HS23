namespace DN3;

public class Space
{
    static void Main(string[] args)
    {
        InitOmegaVectors(out var omegaEarth, out var omegaSun, out var omegaGalaxy);
        InitRVectors(out var rEarth, out var rSun, out var rGalaxy);
        var speed = CalcSpeed(omegaEarth, omegaSun, omegaGalaxy, rEarth, rSun, rGalaxy);
        Console.WriteLine("Speed is " + speed + " km/s");
    }

    public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy)
    { 
        var unitVector = new Vector(0, 1, 0);
        var radiant = unitVector * 2 * Math.PI;
        omegaEarth =  radiant / multiply(24, 3600);
        omegaSun = radiant / multiply(365.25, 24, 3600);
        omegaGalaxy =  radiant / multiply(225000000, 365.25, 24, 3600);
    }

    private static double multiply(params double[] numbs) =>
        numbs.Aggregate(1.0, (curVal, i) => curVal * i);

    public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy)
    {
        Vector unitVector = new Vector(1, 0, 0);
        rEarth = unitVector * 6370; // Earth's radius in kilometers
        rSun = unitVector * 149.6e6; // Distance from Earth to Sun in kilometers
        rGalaxy = unitVector * (25000 * 9.46e12); // Distance from Sun to Galactic Center in kilometers
    }

    public static double CalcSpeed(Vector omegaEarth, Vector omegaSun, Vector omegaGalaxy, Vector rEarth, Vector rSun, Vector rGalaxy)
    {
        Vector vEarth = omegaEarth * rEarth;
        Vector vSun = omegaSun * rSun;
        Vector vGalaxy = omegaGalaxy * rGalaxy;

        Vector totalVelocity = vEarth + vSun + vGalaxy;

        return (double)totalVelocity; // Implicit conversion of Vector to double calculates the magnitude
    }
}