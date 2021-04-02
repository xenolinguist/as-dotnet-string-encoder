using Xunit;
using Moq;
using System.Text;

namespace Encoder.Tests
{
    public class VowelBusinessRuleTests
    {
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly StringBuilder _output;
        private readonly VowelBusinessRule _testSubject;

        public VowelBusinessRuleTests()
        {
            _mockScanner = new Mock<IStringScanner>();
            _output = new StringBuilder();
            _testSubject = new VowelBusinessRule();
        }

        [Fact]
        public void WhenScannerHasNoData_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(false);

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsNotVowel_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('f');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Theory]
        [InlineData('a', "1")]
        [InlineData('A', "1")]
        [InlineData('e', "2")]
        [InlineData('E', "2")]
        [InlineData('i', "3")]
        [InlineData('I', "3")]
        [InlineData('o', "4")]
        [InlineData('O', "4")]
        [InlineData('u', "5")]
        [InlineData('U', "5")]
        public void WhenNextCharacterIsVowel_ReturnTrue(char input, string expected)
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns(input);
            _mockScanner.Setup(s => s.ReadCharacter()).Returns(input);

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal(expected, _output.ToString());
            _mockScanner.VerifyAll();
        }
    }
}
