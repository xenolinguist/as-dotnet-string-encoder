using Xunit;
using Moq;
using System.Text;

namespace Encoder.Tests
{
    public class EncoderProcessorTests
    {
        private readonly Mock<IStringScannerFactory> _mockFactory;
        private readonly Mock<IStringScanner> _mockScanner;
        private readonly Mock<IBusinessRule> _mockRule1;
        private readonly Mock<IBusinessRule> _mockRule2;
        private readonly EncoderProcessor _testSubject;

        public EncoderProcessorTests()
        {
            _mockFactory = new Mock<IStringScannerFactory>();
            _mockScanner = new Mock<IStringScanner>();
            _mockFactory.Setup(f => f.Create(It.IsAny<string>())).Returns(_mockScanner.Object);
            _mockRule1 = new Mock<IBusinessRule>();
            _mockRule2 = new Mock<IBusinessRule>();
            _testSubject = new EncoderProcessor(_mockFactory.Object, _mockRule1.Object, _mockRule2.Object);
        }

        [Fact]
        public void Encode_WhenInputIsEmpty_NoCallsAreMade()
        {
            _mockScanner.Setup(s => s.HasData).Returns(false);

            _testSubject.Encode("dummy string");

            _mockRule1.VerifyNoOtherCalls();
            _mockRule2.VerifyNoOtherCalls();
        }

        [Fact]
        public void Encode_WhenARuleApplies_FurtherRulesAreNotCalled()
        {
            _mockScanner.SetupSequence(s => s.HasData).Returns(true).Returns(false);
            _mockRule1
                .Setup(s => s.TryApply(_mockScanner.Object, It.IsAny<StringBuilder>()))
                .Returns(true);

            _testSubject.Encode("dummy string");

            _mockRule1.VerifyAll();
            _mockRule2.VerifyNoOtherCalls();
        }
    }
}