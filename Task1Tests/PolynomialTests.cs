using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Task1;

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
            Assert.True(p!=null);
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
        [Test]
        public void Calculate_ValidData_ValidResult()
        {
            double x = 1;
            double[] arr = { 1, 2, 3, 0 };
            Polynomial p = new Polynomial(arr);
            double actual = p.Calculate(x);
            double expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void SumOperator_2Polynomial_ValidPolyndromial()
        {
            double[] arr1 = { 1, 2, 3, 0 };
            double[] arr2 = { 1, 0, 3, 2 };
            double[] arr3 = { 2, 2, 6, 2 };
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr2);
            Polynomial expected = new Polynomial(arr3);
            Polynomial actual = p1 + p2;
            Assert.True(actual.Equals(expected));        
        }

        [Test]
        public void Equal_ValidPolynomialObject_True()
        {
            double[] arr1 = { 1, 2, 3, 0 };
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr1);
            Assert.True(p1.Equals(p2));
        }

        [Test]
        public void Equal_SameReference_True()
        {
            double[] arr1 = { 1, 2, 3, 0 };
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = p1;
            Assert.True(p1.Equals(p2));
        }

        [Test]
        public void OperatorMinus_2Polynomials_ValidPolynomial()
        {
            double[] arr1 = { 1, 0, 3, 2, 7 };
            double[] arr2 = { 2, -2, 6, 2 };
            double[] arr3 = { -1, 2, -3, 0, 7 };
            Polynomial p1 = new Polynomial(arr1);
            Polynomial p2 = new Polynomial(arr2);
            Polynomial expected = new Polynomial(arr3);
            Polynomial actual = p1 - p2;
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
    }
}
