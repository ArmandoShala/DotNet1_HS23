using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1 {
    public enum PrimeType {Prime, NotPrime};

    public class Eratosthenes  {
        
        public PrimeType[] Sieve(int maxPrime) {
           // TODO Implement
           return null;
        }
        
        public int[] PrimesAsArray(PrimeType[] primes) {
            // TODO Implement
            return null;
        }

        public List<int> PrimesAsList(PrimeType[] primes) {
            // TODO Implement
            return null;
        }

        public Dictionary<int,int>  PrimesAsDictionary(PrimeType[] primes) {
            // TODO Implement
            return null;
        }

        public void printAll(IEnumerable<int> collection) {
            int i = 0;
            foreach (int p in collection) {
                Console.Write((i++) + "->" + p + " ");
                if ((i + 1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine();
        }
        
        static void Main(string[] args) {
            int maxPrime = 100;
            Eratosthenes eratosthenes = new Eratosthenes();
            if (args.Length >= 1)
                maxPrime = Int32.Parse(args[0]);
                          
            PrimeType[] primes =  eratosthenes.Sieve(maxPrime);
            Console.WriteLine("Aufgabe 1");
            for (int i = 0; i < maxPrime; i++)  {
                Console.Write(i + ":" + primes[i] + " ");
                if ((i+1) % 5 == 0) Console.WriteLine();
            }
            Console.WriteLine("\nAufgabe 2");
            eratosthenes.printAll(eratosthenes.PrimesAsArray(primes));
            Console.WriteLine("\nAufgabe 3");
            eratosthenes.printAll(eratosthenes.PrimesAsList(primes));
            Console.WriteLine("\nAufgabe 4");
            eratosthenes.printAll(eratosthenes.PrimesAsDictionary(primes).Select(z => z.Value).ToArray());
     
            Console.ReadLine();
        }
    }
}