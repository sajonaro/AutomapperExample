using System;
using System.Collections.Generic;
using System.Text;

namespace Client
{
    public static class ExtensionMethods
    {
        public static bool EpsilonEquals(this double fistValue, double secondValue)
        {
            return Math.Abs( fistValue - secondValue) < 0.00000001;
        }
    }
}
