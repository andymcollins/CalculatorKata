using System;
using NUnit.Framework;



namespace tests
{
    [TestFixture]
    public class CalculatorTests
    {
        private CalculatorKata.Calculator _calculator;

        [SetUp]
        public void InitFixture() => _calculator = new CalculatorKata.Calculator();

        [Test]
        public void GetResultWhenAddingWithEmptyString()
        {
            Assert.That(_calculator.Add(string.Empty), Is.EqualTo(0));
        }

        [TestCase("1", 1, TestName = "Test One Number"), 
         TestCase("100,2", 102, TestName = "Test with Two Numbers"),
         TestCase("100,10,1,2,3", 116, TestName = "Test with Multiple Numbers"), 
         TestCase("1\n2", 3, TestName = "Test With NewLine Delimiter"),
         TestCase("100\n10,1", 111, TestName = "Test with Mixed Delimiters"),
         TestCase("//;\n1;2", 3, TestName = "Test with Custom Delimiter"),
         TestCase("1001,1", 1, TestName = "Test with Number Greater than 1000"),
         TestCase("//[***]\n1***2***3", 6, TestName = "Test with Custom Delimiter any Length"),
         TestCase("//[*][%]\n1*2%3", 6, TestName = "Test with Multiple Custom Delimiter any Length")
        ]
        public void GetResultFromTestCase(string number, int expectedResult)
        {
            Assert.That(_calculator.Add(number), Is.EqualTo(expectedResult));
        }


        [Test]
        public void GetExceptionWhenUsingNegativeNumber()
        {
            var calculator = new CalculatorKata.Calculator();

            var ex = Assert.Throws<Exception>(() => calculator.Add("-1"));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed! you entered: -1 "));
        }

        [Test]
        public void GetExceptionWhenUsingMultipleNegativeNumbers()
        {
            var calculator = new CalculatorKata.Calculator();

            var ex = Assert.Throws<Exception>(() => calculator.Add("-1,-2"));

            Assert.That(ex.Message, Is.EqualTo("negatives not allowed! you entered: -1 -2 "));
        }
    }
}
