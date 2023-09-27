using System;

namespace Arbeitsblatt3 {
    public class Space {
        
        static void Main(string[] args) {
            DN3.Vector omegaEarth,omegaSun, omegaGalaxy;
            DN3.Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }
        
        public static void InitOmegaVectors(out DN3.Vector omegaEarth, out DN3.Vector omegaSun, out DN3.Vector omegaGalaxy) {
            DN3.Vector unitVector = new DN3.Vector(0, 1, 0);
            
            // TODO Implement       
        }
        
        public static void InitRVectors(out DN3.Vector rEarth, out DN3.Vector rSun, out DN3.Vector rGalaxy) {
            DN3.Vector unitVector = new DN3.Vector(1, 0, 0);
            // TODO Implement     
        }

        public static double CalcSpeed(DN3.Vector omegaEarth,DN3.Vector omegaSun, DN3.Vector omegaGalaxy,DN3.Vector rEarth, DN3.Vector rSun, DN3.Vector rGalaxy) {
            // TODO Implement     
        }
    }
}
