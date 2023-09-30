using System;
using System.Collections.Generic;
using System.Text;

namespace DN3 {
    public class Space_Blank {
        static void Main_Blank(string[] args) {
            Vector omegaEarth,omegaSun, omegaGalaxy;
            Vector rEarth, rSun, rGalaxy;
            
            InitOmegaVectors(out omegaEarth,out omegaSun, out omegaGalaxy);
            InitRVectors(out rEarth, out rSun, out rGalaxy);
            double speed = CalcSpeed(omegaEarth,omegaSun, omegaGalaxy,rEarth, rSun, rGalaxy);
            Console.WriteLine("Speed is "+speed+" km/s");
            Console.ReadLine();
        }
        
        public static void InitOmegaVectors(out Vector omegaEarth, out Vector omegaSun, out Vector omegaGalaxy) {
            Vector unitVector = new Vector(0, 1, 0);
            // TODO Implement
            throw new NotImplementedException();
        }
        
        public static void InitRVectors(out Vector rEarth, out Vector rSun, out Vector rGalaxy) {
            Vector unitVector = new Vector(1, 0, 0);
            // TODO Implement     
            throw new NotImplementedException();
        }

        public static double CalcSpeed(Vector omegaEarth,Vector omegaSun, Vector omegaGalaxy,Vector rEarth, Vector rSun, Vector rGalaxy) {
            // TODO Implement     
            throw new NotImplementedException();
        }
    }
}
