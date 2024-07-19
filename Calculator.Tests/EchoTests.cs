using JenkinsDemo.Data.Models;

namespace UnitTests
{
    public class EchoTests : IDisposable
    {
        public EchoModel testModel;

        public EchoTests()
        {
            testModel = new EchoModel();
        }
        public void Dispose() { }

        [Theory]
        [InlineData("test", "TEST")]
        [InlineData("Hello World", "HELLO WORLD")]
        [InlineData("thisIsPascalCase", "THISISPASCALCASE")]
        [InlineData("UPPERCASE", "UPPERCASE")]
        [InlineData("My name is Jeroen, and I'm a software tester!", "MY NAME IS JEROEN, AND I'M A SOFTWARE TESTER!")]
        public void TestConvertToUpperCase(string statementContent, string expectedEchoedStatement)
        {
            // Arrange
            testModel.StatementContent = statementContent;
            // Act
            testModel.EchoUppercase();
            // Assert
            Assert.Equal(testModel.EchoedStatement, expectedEchoedStatement);
        }

        [Theory]
        [InlineData("test", "test")]
        [InlineData("Hello World", "hello world")]
        [InlineData("thisIsPascalCase", "thisispascalcase")]
        [InlineData("UPPERCASE", "uppercase")]
        [InlineData("My name is Jeroen, and I'm a software tester!", "my name is jeroen, and i'm a software tester!")]
        public void TestConvertToLowerCase(string statementContent, string expectedEchoedStatement)
        {
            // Arrange
            testModel.StatementContent = statementContent;
            // Act
            testModel.EchoLowercase();
            // Assert
            Assert.Equal(testModel.EchoedStatement, expectedEchoedStatement);
        }

        [Theory]
        [InlineData("test", "test")]
        [InlineData("Hello World", "HelloWorld")]
        [InlineData("thisIsPascalCase", "thisIsPascalCase")]
        [InlineData("UPPERCASE", "UPPERCASE")]
        [InlineData("My name is Jeroen, and I'm a software tester!", "MynameisJeroen,andI'masoftwaretester!")]
        public void TestConvertToTrimmed(string statementContent, string expectedEchoedStatement)
        {
            // Arrange
            testModel.StatementContent = statementContent;
            // Act
            testModel.EchoNoSpaces();
            // Assert
            Assert.Equal(testModel.EchoedStatement, expectedEchoedStatement);
        }

        [Theory]
        [InlineData("test", "t e s t")]
        [InlineData("Hello World", "H e l l o   W o r l d")]
        [InlineData("thisIsPascalCase", "t h i s I s P a s c a l C a s e")]
        [InlineData("UPPERCASE", "U P P E R C A S E")]
        [InlineData("My name is Jeroen, and I'm a software tester!", "M y   n a m e   i s   J e r o e n ,   a n d   I ' m   a   s o f t w a r e   t e s t e r !")]
        public void TestConvertToSplitCharacters(string statementContent, string expectedEchoedStatement)
        {
            // Arrange
            testModel.StatementContent = statementContent;
            // Act
            testModel.EchoSplitCharacters();
            // Assert
            Assert.Equal(testModel.EchoedStatement, expectedEchoedStatement);
        }

        [Theory]
        [InlineData("test", "t e s t")]
        [InlineData("Hello World", "H e l l o   W o r l d")]
        [InlineData("thisIsPascalCase", "t h i s I s P a s c a l C a s e")]
        [InlineData("UPPERCASE", "U P P E R C A S E")]
        [InlineData("My name is Jeroen, and I'm a software tester!", "M y   n a m e   i s   J e r o e n ,   a n d   I ' m   a   s o f t w a r e   t e s t e r !")]
        public void TestConvertToReverse(string statementContent, string expectedEchoedStatement)
        {
            // Arrange
            testModel.StatementContent = statementContent;
            // Act
            testModel.EchoSplitCharacters();
            // Assert
            Assert.Equal(testModel.EchoedStatement, expectedEchoedStatement);
        }

    }
}
