using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace multiplicityDemo
{
    internal class DecimalComplex
    {
        public decimal Real { get; set; }
        public decimal Imaginary { get; set; }

        public DecimalComplex()
        {
            Real = 0;
            Imaginary = 0;
        }

        public DecimalComplex(decimal value)
        {
            Real = value;
            Imaginary = value;
        }
        public DecimalComplex(decimal real, decimal imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }
        public decimal Magnitude { get { return calcMagn(); } }

        public decimal calcMagn()
        {
            decimal magnitude = 0;
            decimal realSq = Real * Real;
            decimal imagSq = Imaginary * Imaginary;
            decimal sum = imagSq + realSq;
            magnitude = Sqrt(sum);
            return magnitude;
        }
        public static decimal Sqrt(decimal x, decimal epsilon = 0.0M)
        {
            decimal current = (decimal)Math.Sqrt((double)x);
            decimal previous;
            do
            {
                previous = current;
                if (previous == 0.0M) return 0;
                current = (previous + x / previous) / 2;
            }
            while (Math.Abs(previous - current) > epsilon);
            return current;
        }

        public static DecimalComplex operator *(DecimalComplex a, DecimalComplex b)
        => new DecimalComplex((a.Real * b.Real - a.Imaginary * b.Imaginary), (a.Real * b.Imaginary + b.Real * a.Imaginary));

        public static DecimalComplex operator +(DecimalComplex a, DecimalComplex b)
        => new DecimalComplex((a.Real + b.Real), (a.Imaginary + b.Imaginary));

        public static DecimalComplex operator -(DecimalComplex a, DecimalComplex b)
        => new DecimalComplex((a.Real - b.Real), (a.Imaginary - b.Imaginary));

        public static DecimalComplex operator /(DecimalComplex a, DecimalComplex b)
        => new DecimalComplex((a.Real * b.Real+a.Imaginary*b.Imaginary)/(b.Imaginary*b.Imaginary+b.Real*b.Real), (b.Real * a.Imaginary - a.Real * b.Imaginary) / (b.Imaginary * b.Imaginary + b.Real * b.Real));
    }
}
