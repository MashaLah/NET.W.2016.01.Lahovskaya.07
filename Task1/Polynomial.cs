using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Task1
{
    public sealed class Polynomial
    {
        private double[] coefficients;
        public static double epsilon;
        public static double Epsilon
        {
            get { return epsilon; }
            private set
            {
                if (value <= 0 || value >= 1)
                    throw new ArgumentOutOfRangeException(nameof(value));
                epsilon = value;
            }
        }

        public int Degree
        {
            get
            {
                if (coefficients.Length == 1)
                    return 0;
                int i;
                for (i = coefficients.Length - 1; i >= 0; i--)
                {
                    if (Math.Abs(coefficients[i]) > epsilon)
                        break;
                }
                return i;
            }
        }

        /// <summary>
        /// Indexer.
        /// </summary>
        public double this[int i]
        {
            get
            {
                if (i < 0 || i > Degree+1)
                    throw new ArgumentOutOfRangeException($"{nameof(i)} can't be <0 and can't be bigger tham Degree.");
                
                return coefficients[i];
            }
            set
            {
                if (i < 0 || i > Degree+1)
                    throw new ArgumentOutOfRangeException($"{nameof(i)} can't be <0 and can't be bigger tham Degree.");
                
                coefficients[i] = value;
            }
        }

        static Polynomial()
        {
            Epsilon = double.Parse(ConfigurationManager.AppSettings["epsilon"]);
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="coefficients">Array of double.</param>
        public Polynomial(params double[] coefficients)
        {
            if (ReferenceEquals(coefficients,null))
                throw new ArgumentNullException(nameof(coefficients));

            if (coefficients.Length == 0)
                throw new ArgumentException($"Argument {nameof(coefficients)} is empty.");

            this.coefficients = new double[coefficients.Length];
            coefficients.CopyTo(this.coefficients,0);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="p">Polynomial object.</param>
        public Polynomial(Polynomial polynomial)
        {
            if (polynomial == null)
                throw new ArgumentNullException(nameof(polynomial));

            coefficients = new double[polynomial.Degree+1];
            
            for (int i = 0; i < polynomial.Degree+1; i++)
                this[i] = polynomial[i];         
        }

        /// <summary>
        /// Calculate polynomial for the value of x.
        /// </summary>
        public double Calculate(double x)=>
            coefficients.Select((t, i) => t * Math.Pow(x, i)).Sum();

        public static Polynomial operator +(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            return polynomial;
        }

        /// <summary>
        /// Finds sum of two polynomials.
        /// </summary>
        public static Polynomial operator +(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null))
                throw new ArgumentNullException(nameof(firstPolynomial));

            if (ReferenceEquals(secondPolynomial, null))
                throw new ArgumentNullException(nameof(secondPolynomial));

            Polynomial maxDegreePolynomial = firstPolynomial.Degree > secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial minDegreePolynomial = firstPolynomial.Degree < secondPolynomial.Degree ? firstPolynomial : secondPolynomial;
            Polynomial result = new Polynomial(maxDegreePolynomial);
            for (int i = 0; i < minDegreePolynomial.Degree; i++)
            {
                result[i] = firstPolynomial[i] + secondPolynomial[i];
            }
            return result;
        }

        public static Polynomial operator +(Polynomial polynomial, double x)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            Polynomial result = new Polynomial(polynomial);
            for (int i = 0; i < polynomial.Degree + 1; i++)
                result [i] += x;
            return result;
        }

        public static Polynomial operator +(double x, Polynomial polynomial)
        {
            return polynomial + x;
        }

        public static Polynomial operator -(Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            return polynomial*(-1);
        }

        /// <summary>
        /// Finds subtraction of two polynomials.
        /// </summary>
        public static Polynomial operator -(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null))
                throw new ArgumentNullException(nameof(firstPolynomial));

            if (ReferenceEquals(secondPolynomial, null))
                throw new ArgumentNullException(nameof(secondPolynomial));

            return firstPolynomial + (-secondPolynomial);
        }

        public static Polynomial operator -(Polynomial polynomial, double x)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            Polynomial result = new Polynomial(polynomial);
            for (int i = 0; i < polynomial.Degree + 1; i++)
                result[i] -= x;
            return result;
        }

        public static Polynomial operator -(double x, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            return x + (-polynomial);
        }

        /// <summary>
        /// Multiplies two polynomials.
        /// </summary>
        public static Polynomial operator *(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            if (ReferenceEquals(firstPolynomial, null))
                throw new ArgumentNullException(nameof(firstPolynomial));

            if (ReferenceEquals(secondPolynomial, null))
                throw new ArgumentNullException(nameof(secondPolynomial));

            double[] resultArray = new double[firstPolynomial.Degree + secondPolynomial.Degree -1];
            Polynomial result = new Polynomial(resultArray);
            for (int i = 0; i < firstPolynomial.Degree; i++)
            {
                for (int j = 0; j < secondPolynomial.Degree; j++)
                    result[i + j] += firstPolynomial[i] * secondPolynomial[j];
            }
            return result;
        }

        public static Polynomial operator *(Polynomial polynomial, double x)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            Polynomial result = new Polynomial(polynomial);
            for (int i = 0; i < polynomial.Degree + 1; i++)
                result[i] *= x;
            return result;
        }

        public static Polynomial operator *(double x, Polynomial polynomial)
        {
            if (ReferenceEquals(polynomial, null))
                throw new ArgumentNullException(nameof(polynomial));
            return polynomial * x;
        }

        /// <summary>
        /// Override Equals().
        /// </summary>
        public override bool Equals(Object o)
        {
            if (this == null)
            {
                throw new NullReferenceException();
            }                      
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


