using Xunit;
using System.Text;
using Moq;

namespace Encoder.Tests
{
    public class SpaceBusinessRuleTests
    {
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly StringBuilder _output;
        private readonly SpaceBusinessRule _testSubject;

        public SpaceBusinessRuleTests()
        {
            _mockScanner = new Mock<IStringScanner>();
            _output = new StringBuilder();
            _testSubject = new SpaceBusinessRule();
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
        public void WhenNextCharacterIsNotSpace_ReturnFalse()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns('f');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.False(result);
            Assert.Equal(string.Empty, _output.ToString());
            _mockScanner.VerifyAll();
        }

        [Fact]
        public void WhenNextCharacterIsSpace_ReturnTrue()
        {
            _mockScanner.Setup(s => s.HasData).Returns(true);
            _mockScanner.Setup(s => s.NextCharacter).Returns(' ');
            _mockScanner.Setup(s => s.ReadCharacter()).Returns(' ');

            var result = _testSubject.TryApply(_mockScanner.Object, _output);

            Assert.True(result);
            Assert.Equal("y", _output.ToString());
            _mockScanner.VerifyAll();
        }
    }
}