using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    public class Polynomial
    {
        private readonly double[] coefficients;
        //private double x;
        //private int degree;
        public double X {private get; set; }
        //public int Degree { get; set; }
        public int Degree
        {
            get { return coefficients.Length; }
        }
        public double this[int i]
        {
            get
            {
                return coefficients[i];
            }
            set
            {
                coefficients[i] = value;
            }
        }
        public Polynomial(double[] coefficients)
        {
            //this.x = x;
            /*this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients, 0);*/
            this.coefficients = new double[coefficients.Length];
            for (int i = 0; i < coefficients.Length; i++)
            {
                this[i] = coefficients[i];
            }
        }

        public Polynomial(Polynomial p)
        {
            this.coefficients = new double[p.Degree];
            for (int i = 0; i < p.Degree; i++)
            {
                this[i] = p[i];
            }
        }

        public double Calculate(double x)
        {
            double result = 0;
            for(int i = 0; i < Degree; i++)
            {
                result = result + this[i] * Math.Pow(x, i);
            }
            return result;
        }

        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial maxDegreePolynomial = firstPolynomial.Degree > secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial minDegreePolynomial = firstPolynomial.Degree < secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            double[] arr = new double[maxDegreePolynomial.Degree];
            for (int i = 0; i < maxDegreePolynomial.Degree; i++)
            {
                arr[i] = maxDegreePolynomial[i];
            }
            for (int i = 0; i < minDegreePolynomial.Degree; i++)
            {
                arr[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            Polynomial result = new Polynomial(arr);
            return result;
        }
    }
}


