using System;
using Xunit;
using StringCalculator;

namespace StringCalculatorTests
{
    public class StringCalculatorTests
    {
        [Fact]
        public void EmptyStringReturnsZero()
        {
            int res = StringCalculator.StringCalculator.CalculateString("");
        }

        [Theory]
        [InlineData("25", 25)]
        [InlineData("0", 0)]
        public void SingleNumberReturnsTheValue(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25,1", 26)]
        public void TwoNumbersSeparatedWithCommaReturnTheirSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25\n1", 26)]
        [InlineData("0\n10", 10)]
        public void TwoNumbersSeparatedWithNewlineReturnTheirSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25\n1,1", 27)]
        [InlineData("10,0\n10", 20)]
        [InlineData("5,5,5", 15)]
        [InlineData("1\n1\n1", 3)]
        public void ThreeNumbersSeparatedWithNewlineOrCommaReturnTheirSum(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("25\n-1,1")]
        [InlineData("-1")]
        public void NegativeNymbersThrowException(string s)
        {
            _ = Assert.Throws<ArgumentException>(() => StringCalculator.StringCalculator.CalculateString(s));
        }

        [Theory]
        [InlineData("25\n1,1,1001", 27)]
        [InlineData("10,0\n10,1000", 1020)]
        [InlineData("100004,5,5,5", 15)]
        [InlineData("1\n1\n1,999", 1002)]
        public void NumbersBiggerThan1000AreIgnpored(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//#\n25\n1,1,1001", 27)]
        [InlineData("//$\n10,0\n10,1000", 1020)]
        [InlineData("100004,5,5,5", 15)]
        [InlineData("1\n1\n1,999", 1002)]
        public void AtTheBeginningWeCanDefineAdditionalSeparator(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("//[#:@]\n25#1:1@1001", 27)]
        [InlineData("//$\n10,0\n10,1000", 1020)]
        public void AtTheBeginningWeCanDefineMultipleAdditionalSeparators(string s, int expected)
        {
            int res = StringCalculator.StringCalculator.CalculateString(s);
            Assert.Equal(expected, res);
        }
    }
}
