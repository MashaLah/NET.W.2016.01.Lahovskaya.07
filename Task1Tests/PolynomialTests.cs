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
            double x = 1;
            double[] arr = { 1, 2, 3, 0 };
            Polynomial p = new Polynomial(x, arr);
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
            Polynomial p = new Polynomial(x, arr);
            double actual = p.Calculate();
            double expected = 6;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void CalculateSum_ValidPolynomial_DoubleArray()
        {

        }
    }
}
