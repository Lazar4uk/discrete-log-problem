using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;

/**
 * Auto-generated code below aims at helping you parse
 * the standard input according to the problem statement.
 **/
class Solution
{
    static void Main(string[] args)
    {
        string[] inputs = Console.ReadLine().Split(' ');
        long G = long.Parse(inputs[0]);
        ulong H = ulong.Parse(inputs[1]);
        long Q = long.Parse(inputs[2]);
        BigInteger g = G;
        BigInteger h = H;
        BigInteger q = Q;

        var m = (int)(Math.Sqrt(Q)) + 1;
        var baby_steps = new Dictionary<BigInteger, BigInteger>();
        var tt = new BigInteger[m];
        //Precompute the baby steps
        for (int j = 0; j < m; j++)
        {
            tt[j] = j;
            baby_steps.Add(BigInteger.ModPow(g, j, q), j);
        }
        //Giant step: G^(-m)
        var gm = BigInteger.ModPow(modinv(G, Q), m, q);
        //Search for a match
        for (int i = 0; i < m; i++)
        {
            var target = (h * BigInteger.ModPow(gm, tt[i], q)) % q;

            if (baby_steps.ContainsKey(target))
            {
                Console.WriteLine((long)i * m + baby_steps[target]);
                return;
            }
        }
    }
    static long modinv(long a, long m)
    {
            var m0 = m;
            long y = 0, x = 1;
    
            if (m == 1)
                return 0;
            long q, t;
            while (a > 1) {
                // q is quotient
                q = a / m;
    
                t = m;
    
                // m is remainder now, process
                // same as Euclid's algo
                m = a % m;
                a = t;
                t = y;
    
                // Update x and y
                y = x - q * y;
                x = t;
            }
    
            // Make x positive
            if (x < 0)
                x += m0;
    
            return (long)x;
    }
}
