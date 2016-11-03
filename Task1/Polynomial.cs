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
        private readonly double x;
        //private int degree;
        //public double X {private get; set; }
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
        public Polynomial(double x, double[] coefficients)
        {
            this.x = x;
            /*this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients, 0);*/
            this.coefficients = new double[coefficients.Length];
            for (int i = 0; i < coefficients.Length; i++)
            {
                this[i] = coefficients[i];
            }
        }

        public double Calculate()
        {
            double result = 0;
            for(int i = 0; i < Degree; i++)
            {
                result = result + this[i] * Math.Pow(x, i);
            }
            return result;
        }

        public double[] CalculateSum(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial maxDegreePolynomial = firstPolynomial.Degree > secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial minDegreePolynomial = firstPolynomial.Degree < secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            double[] resultArray = new double[maxDegreePolynomial.Degree];
            for (int i = 0; i < minDegreePolynomial.Degree; i++)
            {
                resultArray[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            
            return resultArray;
        }
    }
}


