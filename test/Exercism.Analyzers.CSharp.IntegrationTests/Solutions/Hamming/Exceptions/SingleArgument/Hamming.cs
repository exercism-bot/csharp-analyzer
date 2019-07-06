using System;
using System.Linq;

public static class Hamming
{
    public static int Distance(string firstStrand, string secondStrand)
    {
        if (firstStrand.Length != secondStrand.Length)
        {
            throw new ArgumentException("Strains must be equal in length.");
        }

        return firstStrand.Where((x, i) => x != secondStrand[i]).Count();
    }
}