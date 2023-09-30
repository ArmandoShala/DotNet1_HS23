using System;

namespace DN3
{
    public class Space
    {
        static void Main(string[] args)
        {
            Vector omegaEarth, omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;

            InitOmegaVectors(out omegaEarth, out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            var speed = CalcSpeed(omegaEarth, omegaSun, omegaGalaxy, rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is " + speed + " km/s");
            Console.ReadLine();
        }

        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy)
        {
            var unitVector = new Vector(0, 1, 0);
            omegaEarth = new Vector();
            omegaSun = new Vector();
            omegaGalaxy = new Vector();
        }

        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy)
        {
            var unitVector = new Vector(1, 0, 0);
            rEarth = new Vector(6370.0);
            rSun = new Vector();
            rGalaxy = new Vector();
        }

        public static double CalcSpeed(Vector omegaEarth, Vector omegaSun, Vector omegaGalaxy, Vector rEarth,
            Vector rSun, Vector rGalaxy)
        {
        }
    }
}