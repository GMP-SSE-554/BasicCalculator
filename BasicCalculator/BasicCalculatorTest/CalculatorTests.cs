using BasicCalculator;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BasicCalculatorTest
{
    [TestClass]
    public class CalculatorTests
    {
        Calculator testCalc;
        const string TEST_STRING = "test";
        const string ERROR_STRING = "Err";
        const double EPSILON = 0.001;

        [TestInitialize]
        public void BeforeEachTest()
        {
            testCalc = new Calculator();
        }
        
        [TestMethod]
        public void CalculatorExistsTest()
        {
            Assert.IsNotNull(testCalc);
        }
        
        [TestMethod]
        public void CalcStringInitialEmptyTest()
        {
            Assert.AreEqual(string.Empty, testCalc.CalcString);
        }

        [TestMethod]
        public void CalcStringLimitTest()
        {
            testCalc.CalcString = "This string has more than 20 characters.";
            Assert.AreEqual(20, testCalc.CalcString.Length);
        }

        [TestMethod]
        public void AddOpTest()
        {
            testCalc.CalcString = TEST_STRING;
            testCalc.AddOp("A");
            testCalc.AddOp("dd");
            Assert.AreEqual($"{TEST_STRING}Add", testCalc.CalcString);
        }

        [TestMethod]
        public void ClearCalcStringLastCharTest()
        {
            testCalc.CalcString = "test";
            testCalc.RemoveLast();
            Assert.AreEqual("tes", testCalc.CalcString);
        }

        [TestMethod]
        public void ClearCalcStringLastCharEmptyTest()
        {
            testCalc.RemoveLast();
            Assert.AreEqual(string.Empty, testCalc.CalcString);
        }

        [TestMethod]
        public void ClearCalcStringTest()
        {
            testCalc.CalcString = TEST_STRING;
            testCalc.ClearAll();
            Assert.AreEqual(string.Empty, testCalc.CalcString);
        }

        [TestMethod]
        public void MakeCalcStringErrorTest()
        {
            testCalc.CalcString = ERROR_STRING;
            testCalc.AddOp("4");
            testCalc.AddOp("*");
            testCalc.AddOp("4");
            Assert.AreEqual("4*4", testCalc.CalcString);
        }
        
        [TestMethod]
        public void MultiplyTwoPositiveDecimalTest()
        {
            testCalc.CalcString = ".3*1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 * 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyNegativeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-0.3*.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-0.3 * .6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveAndNegativeDecimalTest()
        {
            testCalc.CalcString = ".3*-0.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 * -0.6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyTwoNegativeDecimalTest()
        {
            testCalc.CalcString = "-1.3*.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-1.3 * .2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveWholeAndDecimalTest()
        {
            testCalc.CalcString = "3*0.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 * 0.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyNegativeWholeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-3*1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 * 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveWholeAndNegativeDecimalTest()
        {
            testCalc.CalcString = "3*-.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 * -.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveDecimalAndNegativeWholeTest()
        {
            testCalc.CalcString = ".3*-4";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 * -4), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyNegativeDecimalAndPositiveWholeTest()
        {
            testCalc.CalcString = "-2.3*2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-2.3 * 2), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveDecimalAndWholeTest()
        {
            testCalc.CalcString = "0.3*6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((0.3 * 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyTwoNegativeWholeTest()
        {
            testCalc.CalcString = "-3*-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 * -6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyPositiveAndNegativeWholeTest()
        {
            testCalc.CalcString = "3*-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 * -6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyNegativeAndPositiveWholeTest()
        {
            testCalc.CalcString = "-3*6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 * 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void MultiplyTwoPositiveWholeTest()
        {
            testCalc.CalcString = "3*6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 * 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideTwoPositiveDecimalTest()
        {
            testCalc.CalcString = ".3/1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 / 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideNegativeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-0.3/.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-0.3 / .6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveAndNegativeDecimalTest()
        {
            testCalc.CalcString = ".3/-0.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 / -0.6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideTwoNegativeDecimalTest()
        {
            testCalc.CalcString = "-1.3/.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-1.3 / .2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveWholeAndDecimalTest()
        {
            testCalc.CalcString = "3/0.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 / 0.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideNegativeWholeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-3/1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 / 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveWholeAndNegativeDecimalTest()
        {
            testCalc.CalcString = "3/-.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 / -.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveDecimalAndNegativeWholeTest()
        {
            testCalc.CalcString = ".3/-4";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 / -4), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideNegativeDecimalAndPositiveWholeTest()
        {
            testCalc.CalcString = "-2.3/2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-2.3 / 2), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveDecimalAndWholeTest()
        {
            testCalc.CalcString = "0.3/6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((0.3 / 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideTwoNegativeWholeTest()
        {
            testCalc.CalcString = "-3/-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 / (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DividePositiveAndNegativeWholeTest()
        {
            testCalc.CalcString = "3/-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 / (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideNegativeAndPositiveWholeTest()
        {
            testCalc.CalcString = "-3/6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 / (double)6), numCalc, EPSILON);
        }

        [TestMethod]
        public void DivideTwoPositiveWholeTest()
        {
            testCalc.CalcString = "3/6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 / (double)6), numCalc, EPSILON);
        }
        
        [TestMethod]
        public void AddTwoPositiveDecimalTest()
        {
            testCalc.CalcString = ".3+1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 + 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddNegativeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-0.3+.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-0.3 + .6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveAndNegativeDecimalTest()
        {
            testCalc.CalcString = ".3+-0.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 + -0.6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddTwoNegativeDecimalTest()
        {
            testCalc.CalcString = "-1.3+.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-1.3 + .2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveWholeAndDecimalTest()
        {
            testCalc.CalcString = "3+0.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 + 0.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddNegativeWholeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-3+1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 + 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveWholeAndNegativeDecimalTest()
        {
            testCalc.CalcString = "3+-.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 + -.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveDecimalAndNegativeWholeTest()
        {
            testCalc.CalcString = ".3+-4";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 + -4), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddNegativeDecimalAndPositiveWholeTest()
        {
            testCalc.CalcString = "-2.3+2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-2.3 + 2), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveDecimalAndWholeTest()
        {
            testCalc.CalcString = "0.3+6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((0.3 + 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddTwoNegativeWholeTest()
        {
            testCalc.CalcString = "-3+-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 + (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddPositiveAndNegativeWholeTest()
        {
            testCalc.CalcString = "3+-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 + (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddNegativeAndPositiveWholeTest()
        {
            testCalc.CalcString = "-3+6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 + (double)6), numCalc, EPSILON);
        }

        [TestMethod]
        public void AddTwoPositiveWholeTest()
        {
            testCalc.CalcString = "3+6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 + (double)6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractTwoPositiveDecimalTest()
        {
            testCalc.CalcString = ".3-1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 - 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractNegativeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-0.3-.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-0.3 - .6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveAndNegativeDecimalTest()
        {
            testCalc.CalcString = ".3--0.6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 - -0.6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractTwoNegativeDecimalTest()
        {
            testCalc.CalcString = "-1.3-.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-1.3 - .2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveWholeAndDecimalTest()
        {
            testCalc.CalcString = "3-0.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 - 0.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractNegativeWholeAndPositiveDecimalTest()
        {
            testCalc.CalcString = "-3-1.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-3 - 1.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveWholeAndNegativeDecimalTest()
        {
            testCalc.CalcString = "3--.2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((3 - -.2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveDecimalAndNegativeWholeTest()
        {
            testCalc.CalcString = ".3--4";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((.3 - -4), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractNegativeDecimalAndPositiveWholeTest()
        {
            testCalc.CalcString = "-2.3-2";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((-2.3 - 2), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveDecimalAndWholeTest()
        {
            testCalc.CalcString = "0.3-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual((0.3 - 6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractTwoNegativeWholeTest()
        {
            testCalc.CalcString = "-3--6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 - (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractPositiveAndNegativeWholeTest()
        {
            testCalc.CalcString = "3--6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 - (double)-6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractNegativeAndPositiveWholeTest()
        {
            testCalc.CalcString = "-3-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)-3 - (double)6), numCalc, EPSILON);
        }

        [TestMethod]
        public void SubtractTwoPositiveWholeTest()
        {
            testCalc.CalcString = "3-6";
            testCalc.PerformCalculations();
            var numCalc = double.Parse(testCalc.CalcString);
            Assert.AreEqual(((double)3 - (double)6), numCalc, EPSILON);
        }

        [TestMethod]
        public void FloatingOperatorTest()
        {
            testCalc.CalcString = "*4";
            testCalc.PerformCalculations();
            Assert.AreEqual(ERROR_STRING, testCalc.CalcString);
        }

        [TestMethod]
        public void ConsecutiveOperatorTest()
        {
            testCalc.CalcString = "5*/3";
            testCalc.PerformCalculations();
            Assert.AreEqual(ERROR_STRING, testCalc.CalcString);
        }

        [TestMethod]
        public void InvalidDecimalTest()
        {
            testCalc.CalcString = "5.0.1*4";
            testCalc.PerformCalculations();
            Assert.AreEqual(ERROR_STRING, testCalc.CalcString);
        }
    }
}
