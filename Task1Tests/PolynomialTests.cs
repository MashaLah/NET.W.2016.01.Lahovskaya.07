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
        [Test]
        public void Constructor_Test()
        {
            //double x = 1;
            double[] arr = { 1, 2, 3, 0 };
            Polynomial p = new Polynomial(arr);
            double[] pArr = new double[4];
            for (int i = 0; i < 4; i++)
            {
                pArr[i] = p[i];
            }
            Console.WriteLine(pArr.ToString());
        }

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
            for (int i = 0; i < actual.Degree; i++)
            {
                Assert.AreEqual(expected[i], actual[i]);
            }          
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
    }
}
