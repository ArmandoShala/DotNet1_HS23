/// <summary>
/// Sieb des Eratosthenes
/// Autor: Karl Rege 
/// </summary>

namespace DN1;

public enum PrimeType
{
    Prime,
    NotPrime
};

public class Eratosthenes
{
    public PrimeType[] Sieve(int maxPrime)
    {
        var primes = new PrimeType[maxPrime];

        for (var i = 2; i < maxPrime; i++)
        {
            primes[i] = isNumberPrime(i) ? PrimeType.Prime : PrimeType.NotPrime;
        }

        return primes;
    }

    private bool isNumberPrime(int number)
    {
        if (number <= 1) return false;
        if (number == 2 || number == 3 || number == 5) return true;
        if (number % 2 == 0 || number % 3 == 0 || number % 5 == 0) return false;

        var boundary = (int) Math.Floor(Math.Sqrt(number));

        // You can do less work by observing that at this point, all primes 
        // other than 2 and 3 leave a remainder of either 1 or 5 when divided by 6. 
        // The other possible remainders have been taken care of.
        int i = 6; // start from 6, since others below have been handled.
        while (i <= boundary)
        {
            if (number % (i + 1) == 0 || number % (i + 5) == 0)
                return false;

            i += 6;
        }

        return true;
    }

    public int[] PrimesAsArray(PrimeType[] primes) =>
        Enumerable.Range(2, primes.Length - 2).Where(i => primes[i] == PrimeType.Prime).ToArray();

    public List<int> PrimesAsList(PrimeType[] primes) =>
        Enumerable.Range(2, primes.Length - 2).Where(i => primes[i] == PrimeType.Prime).ToList();

    public Dictionary<int, int> PrimesAsDictionary(PrimeType[] primes)
    {
        var retDict = new Dictionary<int, int>();
        var index = 0;
        for (var i = 2; i < primes.Length; i++)
        {
            if (primes[i] != PrimeType.Prime) continue;
            retDict.Add(index, i);
            index++;
        }

        return retDict;
    }

    public void printAll(IEnumerable<int> collection)
    {
        int i = 0;
        foreach (int p in collection)
        {
            Console.Write((i++) + "->" + p + " ");
            if ((i + 1) % 5 == 0) Console.WriteLine();
        }

        Console.WriteLine();
    }

    static void Main(string[] args)
    {
        int maxPrime = 100;
        Eratosthenes eratosthenes = new Eratosthenes();
        if (args.Length >= 1)
            maxPrime = Int32.Parse(args[0]);

        PrimeType[] primes = eratosthenes.Sieve(maxPrime);
        Console.WriteLine("Aufgabe 1");
        for (int i = 0; i < maxPrime; i++)
        {
            Console.Write(i + ":" + primes[i] + " ");
            if ((i + 1) % 5 == 0) Console.WriteLine();
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