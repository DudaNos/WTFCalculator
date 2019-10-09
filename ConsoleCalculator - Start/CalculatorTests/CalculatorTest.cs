using System;
using ConsoleCalculator;
using Xunit;

namespace CalculatorTests
{
    public class UnitTest1
    {
        private readonly Calculator _calculator;

        public UnitTest1()
        {
            _calculator = new Calculator();
        }

        [Fact]
        public void Calc_1Plus1_Returns2()
        {
            // Arrange

            // Act
            var result = _calculator.Calc("1+1");

            // Assert
            Assert.Equal(2.0, result);
        }

        [Fact]
        public void Calc_1Minus2_ReturnsMinus1()
        {
            // Arrange

            // Act
            var result = _calculator.Calc("1-2");

            // Assert
            Assert.Equal(-1.0, result);
        }

        [Fact]
        public void Calc_2Divided0_ReturnsException()
        {
            // Assert
            Assert.Throws<DivideByZeroException>(() => _calculator.Calc("2/0"));
        }

        [Fact]
        public void Calc_5MultiplyMinus1_ReturnsMInus5()
        {
            var result = _calculator.Calc("5*-1");

            // Assert
            Assert.Equal(-5.0, result);
        }

        [Fact]
        public void Calc_1Divide3_Returns0Comma33333()
        {
            var result = _calculator.Calc("1/3");

            // Assert
            Assert.Equal(0.33333, result);
        }

        [Fact]
        public void Calc_5Times2Plus44MDivide2_Returns32()
        {
            var result = _calculator.Calc("5*2+44/2");

            // Assert
            Assert.Equal(32.0, result);
        }

        [Fact]
        public void Calc_OnlyNumber_ReturnsSameNumber()
        {
            var result = _calculator.Calc("5");

            // Assert
            Assert.Equal(5.0, result);
        }

        [Fact]
        public void Calc_DoubleInput_ReturnsDouble()
        {
            var result = _calculator.Calc("0.33+0.22");

            // Assert
            Assert.Equal(0.55, result);
        }

        [Fact]
        public void Calc_PlusVorzeichen_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _calculator.Calc("+5*-1"));
        }

        [Fact]
        public void Calc_EmptyString_ThrowsArgumentException()
        {
            // Assert
            Assert.Throws<ArgumentException>(() => _calculator.Calc(""));
        }

        [Fact]
        public void Calc_Spaces_IgnoresSpaces()
        {
            var result = _calculator.Calc("5 + 5");

            // Assert
            Assert.Equal(10.0, result);
        }
    }
}
