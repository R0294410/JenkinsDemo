using JenkinsDemo.Data.Models;

namespace Calculator.Tests
{
    public class CalculatorTests : IDisposable
    {
        CalculatorModel testModel;
        public CalculatorTests()
        {
            testModel = new CalculatorModel();
        }
        public void Dispose() { }

        [Theory]
        [InlineData("4+4", "9")]
        [InlineData("12+17", "29")]
        [InlineData("113+0", "113")]
        [InlineData("18+583", "601")]
        [InlineData("0+0", "0")]
        public void TestSimpleAdditionIsCorrect(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }

        [Theory]
        [InlineData("10-5", "5")]
        [InlineData("12-18", "-6")]
        [InlineData("117-28", "89")]
        [InlineData("0-18", "-18")]
        [InlineData("1879-0", "1879")]
        public void TestSimpleSubtractionIsCorrect(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }

        [Theory]
        [InlineData("10*5", "50")]
        [InlineData("4*4", "16")]
        [InlineData("0*18", "0")]
        [InlineData("425*8", "3400")]
        [InlineData("12*12", "144")]
        public void TestSimpleMultiplicationIsCorrect(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }

        [Theory]
        [InlineData("144/12", "12")]
        [InlineData("27/3", "9")]
        [InlineData("0/12", "0")]
        [InlineData("420/20", "21")]
        [InlineData("785/5", "157")]
        public void TestSimpleDivisionIsCorrect(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }

        [Theory]
        [InlineData("18-6*12", "-54")]
        [InlineData("17*2+6", "40")]
        [InlineData("18-2*6+8/2", "10")]
        [InlineData("1/3*6", "2")]
        [InlineData("38-9/3", "35")]
        public void TestExtendedCalculations(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }

        [Theory]
        [InlineData("14+0.2", "14,2")]
        [InlineData("1/3", "0,33")]
        [InlineData("1/4", "0,25")]
        [InlineData("17*0.3333", "5,67")]
        [InlineData("187/23", "8,13")]
        public void TestCalculationsWithDecimalResult(string insertedCalculation, string expectedResult)
        {
            // Arrange
            testModel.DisplayedCalculation = insertedCalculation;
            // Act
            testModel.CalculateResult();
            // Assert
            Assert.Equal(testModel.CalculationResult, expectedResult);
        }
    }
}