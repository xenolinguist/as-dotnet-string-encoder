using System.Text;
using Xunit;

namespace Encoder.Tests
{
    public class DefaultBusinessRuleTests
    {
        [Fact]
        public void TryApply_CopiesCharacterFromScannerToOutput_AndReturnsFalse()
        {
            var testSubject = new DefaultBusinessRule();
            var scanner = new StringScanner("ABC");
            var output = new StringBuilder();

            var result = testSubject.TryApply(scanner, output);

            Assert.True(result);
            Assert.Equal("A", output.ToString());
            Assert.Equal('B', scanner.NextCharacter);
        }
    }
}