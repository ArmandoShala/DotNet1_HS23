using System;
using System.Linq;

namespace DN2 {
    class MainClass {
        const double EPS = 1E-5;
        const int STEPS = 100;

        public static void Main(string[] args) {
            Func<double, double> linear = x => x;
            Func<double, double> square = x => x * x;

            Console.WriteLine("Linear fixed [0..10]: " + Integrate(linear, 0, 10, STEPS, IntegrationType.Fixed) + " steps: " + STEPS);
            Console.WriteLine("Linear fixed [5..15]: " + Integrate(linear, 5, 15, STEPS, IntegrationType.Fixed) + " steps: " + STEPS);
            Console.WriteLine("Linear adapt [0..10]: " + Integrate(linear, 0, 10, EPS, IntegrationType.Adaptive) + " steps: " + Integrator.Steps);
            Console.WriteLine("Square fixed [0..10]: " + Integrate(square, 0, 10, STEPS, IntegrationType.Fixed) + " steps: " + STEPS);
            Console.WriteLine("Square adapt [0..10]: " + Integrate(square, 0, 10, EPS, IntegrationType.Adaptive) + " steps: " + Integrator.Steps);
            Console.ReadLine();
        }

        public static double Integrate(Func<double, double> f, double start, double end, int steps, IntegrationType type) {
            if (type == IntegrationType.Fixed) {
                return Integrator.FixedIntegrate(f, start, end, steps);
            } else if (type == IntegrationType.Adaptive) {
                return Integrator.AdaptiveIntegrate(f, start, end, EPS);
            } else {
                throw new ArgumentException("Invalid integration type");
            }
        }
    }

    public enum IntegrationType {
        Adaptive,
        Fixed
    }

    public class Integrator {
        private static int Steps;

        public static double FixedIntegrate(Func<double, double> f, double start, double end, int steps) {
            Steps = steps;
            var d = (end - start) / Steps;
            var result = Enumerable.Range(0, Steps)
                .Select(i => start + i * d)
                .Select(x => f(x))
                .Sum();

            return d * (result - (f(start) + f(end)) / 2);
        }

        public static double AdaptiveIntegrate(Func<double, double> f, double start, double end, double eps) {
            Steps = 1;
            var tempResult = FixedIntegrate(f, start, end, Steps);
            var error = 1.0;
            var result = tempResult;

            while (error > eps) {
                Steps *= 2;
                tempResult = FixedIntegrate(f, start, end, Steps);
                error = Math.Abs(result - tempResult);
                result = tempResult;
            }
            return result;
        }
    }
}
