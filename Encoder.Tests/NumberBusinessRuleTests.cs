using Xunit;
using System.Text;
using Moq;

namespace Encoder.Tests
{
    public class NumberBusinessRuleTests
    {
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly StringBuilder _output;
        private readonly NumberBusinessRule _testSubject;

        public NumberBusinessRuleTests()
        {
            _mockScanner = new Mock<IStringScanner>();
            _output = new StringBuilder();
            _testSubject = new NumberBusinessRule();
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
        public void WhenNextCharacterIsNotDigit_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('f');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsDigit_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('7');
            _mockScanner.Setup(s => s.ReadNumber()).Returns(new[] {'7', '8', '9'});

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal("987", _output.ToString());
            _mockScanner.VerifyAll();
        }
    }
}