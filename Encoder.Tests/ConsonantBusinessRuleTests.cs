using Xunit;
using Moq;
using System.Text;

namespace Encoder.Tests
{
    public class ConsonantBusinessRuleTests
    {
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly StringBuilder _output;
        private readonly ConsonantBusinessRule _testSubject;

        public ConsonantBusinessRuleTests()
        {
            _mockScanner = new Mock<IStringScanner>();
            _output = new StringBuilder();
            _testSubject = new ConsonantBusinessRule();
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
        public void WhenNextCharacterIsNotLetter_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns(';');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsLowerCaseLetter_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('x');
            _mockScanner.Setup(s => s.ReadCharacter()).Returns('x');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal("w", _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsUpperCaseLetter_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('X');
            _mockScanner.Setup(s => s.ReadCharacter()).Returns('X');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal("w", _output.ToString());
            _mockScanner.VerifyAll();
        }
    }
}