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

        public int Degree
        {
            get { return coefficients.Length; }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
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

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coefficients">Array of double.</param>
        public Polynomial(double[] coefficients)
        {
            this.coefficients = new double[coefficients.Length];

            for (int i = 0; i < coefficients.Length; i++)
            {
                this[i] = coefficients[i];
            }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p">Polynomial object.</param>
        public Polynomial(Polynomial p)
        {
            coefficients = new double[p.Degree];

            for (int i = 0; i < p.Degree; i++)
            {
                this[i] = p[i];
            }
        }

        /// <summary>
        /// Calculate polynomial for the value of x.
        /// </summary>
        public double Calculate(double x)
        {
            double result = 0;

            for(int i = 0; i < Degree; i++)
            {
                result = result + this[i] * Math.Pow(x, i);
            }

            return result;
        }

        /// <summary>
        /// Finds sum of two polynomials.
        /// </summary>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial maxDegreePolynomial = firstPolynomial.Degree > secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial minDegreePolynomial = firstPolynomial.Degree < secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial result = new Polynomial(maxDegreePolynomial);
            for (int i = 0; i < minDegreePolynomial.Degree; i++)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            return result;
        }

        /// <summary>
        /// Finds subtraction of two polynomials.
        /// </summary>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Polynomial subtrahendPolynomial = new Polynomial(secondPolynomial);
            for (int i = 0; i < subtrahendPolynomial.Degree; i++)
            {
                subtrahendPolynomial[i] = -subtrahendPolynomial[i];
            }
            Polynomial result = firstPolynomial + subtrahendPolynomial;
            return result;
        }

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            double[] resultArray = new double[firstPolynomial.Degree + secondPolynomial.Degree -1];
            Polynomial result = new Polynomial(resultArray);
            for (int i = 0; i < firstPolynomial.Degree; i++)
            {
                for (int j = 0; j < secondPolynomial.Degree; j++)
                {
                    result[i + j] += firstPolynomial[i] * secondPolynomial[j];
                }
            }
            return result;
        }

        /// <summary>
        /// Override Equals().
        /// </summary>
        public override bool Equals(Object o)
        {
            if (o == null)
            {
                return false;
            }
            if (this.GetType() != o.GetType())
            {
                return false;
            }
            if (ReferenceEquals(this, o))
            {
                return true;
            }
            if (o is Polynomial)
            {
                Polynomial p = o as Polynomial;
                if (this.Degree != p.Degree)
                {
                    return false;
                }
                for (int i = 0; i < Degree; i++)
                {
                    if (!(this[i]==(p[i])))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}


