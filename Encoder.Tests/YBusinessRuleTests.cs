using Xunit;
using Moq;
using System.Text;

namespace Encoder.Tests
{
    public class YBusinessRuleTests
    {
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly StringBuilder _output;
        private readonly YBusinessRule _testSubject;

        public YBusinessRuleTests()
        {
            _mockScanner = new Mock<IStringScanner>();
            _output = new StringBuilder();
            _testSubject = new YBusinessRule();
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
        public void WhenNextCharacterIsNotY_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('f');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsLowerCaseY_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('y');
            _mockScanner.Setup(s => s.ReadCharacter()).Returns('y');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal(" ", _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsUpperCaseY_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('Y');
            _mockScanner.Setup(s => s.ReadCharacter()).Returns('Y');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal(" ", _output.ToString());
            _mockScanner.VerifyAll();
        }
    }
}