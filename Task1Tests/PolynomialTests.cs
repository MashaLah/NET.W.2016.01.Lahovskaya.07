using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;
using System.Collections;

namespace Task1Tests
{
    public class PolynomialTests
    {
        /// <summary>
        /// A test for constructor with array. Array is null.
        /// </summary>
        [Test]
        public void Constructor_ArrayIsNull_ThrowArgumentNullException()
        {
            double[] arr = null;
            Assert.Throws<ArgumentNullException>(() => new Polynomial(arr));
        }

        /// <summary>
        /// A test for constructor with array. Array is empty.
        /// </summary>
        [Test]
        public void Constructor_ArrayIsEmpty_ThrowArgumentException()
        {
            double[] arr = new double[] { };
            Assert.Throws<ArgumentException>(() => new Polynomial(arr));
        }

        /// <summary>
        /// A test for constructor with polynomial. polynomial is null.
        /// </summary>
        [Test]
        public void Constructor_PolynomialIsNull_ThrowArgumentNullException()
        {
            Polynomial p = null;
            Assert.Throws<ArgumentNullException>(() => new Polynomial(p));
        }

        /// <summary>
        /// A test for constructor with array.
        /// </summary>
        [Test]
        public void Constructor_Array_True()
        {
            double[] arr = { 1, 2, 3, 0 };
            Polynomial p = new Polynomial(arr);
            Assert.True(p != null);
        }

        /// <summary>
        /// A test for constructor with polynomial.
        /// </summary>
        [Test]
        public void Constructor_Polynomial_True()
        {
            double[] arr = { 1, 2, 3, 0 };
            Polynomial p1 = new Polynomial(arr);
            Polynomial p2 = new Polynomial(p1);
            Assert.True(p2 != null);
        }

        /// <summary>
        /// A test for Calculate().
        /// </summary>
        [Test,TestCaseSource(nameof(TestCasesForCalculate))]
        public void Calculate_ValidData_ValidResult(double x, double[] arr, double expected)
        {
            Polynomial p = new Polynomial(arr);
            double actual = p.Calculate(x);
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// A test for + with valid data.
        /// </summary>
        [Test,TestCaseSource(nameof(TestCasesForSum))]
        public void SumOperator_2Polynomial_ValidPolyndromial(Polynomial firstPolynomial, Polynomial secondPolynomial, Polynomial expected)
        {
            Polynomial actual = firstPolynomial + secondPolynomial;
            Assert.True(actual.Equals(expected));        
        }

        /// <summary>
        /// A test for + with not valid data.
        /// </summary>
        [Test,TestCaseSource(nameof(TestCasesForSumException))]
        public void SumOperator_NullInput_ThrowArgumentNullException(Polynomial firstPolynomial, Polynomial secondPolynomial)
        {
            Assert.Throws<ArgumentNullException>(() => { Polynomial p = firstPolynomial + secondPolynomial; } );
        }

        /// <summary>
        /// A test for Equals.
        /// </summary>
        [Test,TestCaseSource(nameof(TestCasesForEquals))]
        public void Equals_ValidPolynomialObject_True(Polynomial firstPolynomial, Polynomial secondPolynomial, bool expected)
        {
            bool actual = firstPolynomial.Equals(secondPolynomial);
            Assert.AreEqual(actual,expected);
        }

        /// <summary>
        /// A test for Equals with 2 referenses to 1 object.
        /// </summary>
        [Test]
        public void Equals_SameReference_True()
        {
            double[] arr1 = { 1, 2, 3, 0 };
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = p1;
            Assert.True(p1.Equals(p2));
        }

        /// <summary>
        /// A test for - with valid data.
        /// </summary>
        [Test,TestCaseSource(nameof(TestCasesForMinus))]
        public void OperatorMinus_2Polynomials_ValidPolynomial(Polynomial firstPolynomial, Polynomial secondPolynomial, Polynomial expected)
        {
            Polynomial actual = firstPolynomial - secondPolynomial;
            Assert.True(actual.Equals(expected));
        }

        [Test]
        public void OperatorMultiply_2Polynomials_ValidPolynomial()
        {
            double[] arr1 = { 0, 1, 2 };
            double[] arr2 = { 0, 0, 0, 3, 4 };
            double[] arr3 = { 0, 0, 0, 0, 3, 10, 8};
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr2);
            Polynomial expected = new Polynomial(arr3);
            Polynomial actual = p1 * p2;
            Assert.True(actual.Equals(expected));
        }

        static double[] arr = { 1, -2, 3, 0 };
        static double[] arrayWith0 = { 0 };

        static double[] arr1 = { 1, 2, 3, 0 };
        static double[] arr2 = { 1, 0, 3, 2 };
        static double[] arr3 = { 2, 2, 6, 2 };

        static double[] arrFirstMinus = { 1, 0, 3, 2, 7 };
        static double[] arrSecondMinus = { 2, -2, 6, 2 };
        static double[] arrExpectedMinus = { -1, 2, -3, 0, 7 };

        /// <summary>
        /// TestCases for Calculate() method.
        /// </summary>
        public static IEnumerable TestCasesForCalculate
        {
            get
            {
                yield return new TestCaseData(1, arr, 2);
                yield return new TestCaseData(-3, arr, 34);
                yield return new TestCaseData(-3, arrayWith0, 0);
            }
        }

        /// <summary>
        /// TestCases for +.
        /// </summary>
        public static IEnumerable TestCasesForSum
        {
            get
            {
                yield return new TestCaseData(new Polynomial(arr1), new Polynomial(arr2), new Polynomial(arr3));
                yield return new TestCaseData(new Polynomial(arr1), new Polynomial(arrayWith0), new Polynomial(arr1));
            }
        }

        /// <summary>
        /// TestCases for + exceptions.
        /// </summary>
        public static IEnumerable TestCasesForSumException
        {
            get
            {
                yield return new TestCaseData(null, new Polynomial(arr2));
                yield return new TestCaseData(new Polynomial(arr1), null);
                yield return new TestCaseData(null, null);
            }
        }

        /// <summary>
        /// A test for Equals().
        /// </summary>
        public static IEnumerable TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new Polynomial(arr1), null, false);
                yield return new TestCaseData(new Polynomial(arr1), new Polynomial(arr1),true);
                yield return new TestCaseData(new Polynomial(arr1), new Polynomial(arr2), false);
            }
        }

        /// <summary>
        /// TestCases for -.
        /// </summary>
        public static IEnumerable TestCasesForMinus
        {
            get
            {
                yield return new TestCaseData(new Polynomial(arrFirstMinus), new Polynomial(arrSecondMinus), new Polynomial(arrExpectedMinus));
                yield return new TestCaseData(new Polynomial(arr1), new Polynomial(arrayWith0), new Polynomial(arr1));
            }
        }
    }
}
