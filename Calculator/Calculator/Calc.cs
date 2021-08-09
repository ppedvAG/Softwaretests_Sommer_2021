using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

[assembly:InternalsVisibleTo("Calculator.Tests")]

namespace Calculator
{
    public class Calc
    {
        public int Sum(int a, int b)
        {
            if (b > 400)
                return 12;

            return checked(a + b);
        }

        internal void IchBinInternal()
        {
            Debug.WriteLine("Gruß vom Internal");
        }
    }
}
