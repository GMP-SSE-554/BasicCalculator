using BasicCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator testCalc;
        const string testString = "test";
        const double EPSILON = 0.001;

        [TestInitialize]
        public void TestBeforeEach()
        {
            testCalc = new Calculator();
        }

        [TestMethod]
        public void TestCalculatorExists()
        {
            Assert.IsNotNull(testCalc);
        }

        [TestMethod]
        public void TestCalcStringInitialEmpty()
        {
            Assert.AreEqual(string.Empty, testCalc.CalcString);
        }

        [TestMethod]
        public void TestSetCalcString()
        {
            testCalc.CalcString = testString;
            Assert.AreEqual(testString, testCalc.CalcString);
        }

        [TestMethod]
        public void TestSimpleAdd()
        {
            testCalc.CalcString = "3+4";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3.0 + 4.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestSimpleSubtract()
        {
            testCalc.CalcString = "4-2";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((4.0 - 2.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestSimpleMultiply()
        {
            testCalc.CalcString = "3*7";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3.0 * 7.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestSimpleDivide()
        {
            testCalc.CalcString = "5/2";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((5.0 / 2.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestSimpleDecimal()
        {
            testCalc.CalcString = "3.5+4";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3.5 + 4.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestSingleParenthesis()
        {
            testCalc.CalcString = "(3+4)";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3.0 + 4.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestDoubleParenthesis()
        {
            testCalc.CalcString = "((3+4))";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3.0 + 4.0), testNum, EPSILON);
        }

        [TestMethod]
        public void TestOrderOfOps()
        {
            testCalc.CalcString = "3*(4-1+3*2-(5/2))+1";
            testCalc.PerformCalculation();
            double testNum = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 * (4 - 1 + 3 * 2 - (5 / 2)) + 1), testNum, EPSILON);
        }
    }
}
