using Xunit;

namespace Encoder.Tests
{
    public class StringScannerTests
    {
        [Fact]
        public void HasData_ReturnsTrue_WhenIndexLessThanLength()
        {
            var testSubject = new StringScanner("test data");
            Assert.True(testSubject.HasData);
        }

        [Fact]
        public void HasData_ReturnsFalse_WhenIndexEqualToLength()
        {
            var testSubject = new StringScanner(string.Empty);
            Assert.False(testSubject.HasData);
        }

        [Fact]
        public void NextCharacter_DoesNotAlterIndex()
        {
            var testSubject = new StringScanner("A");
            Assert.Equal('A', testSubject.NextCharacter);
            Assert.True(testSubject.HasData);
        }

        [Fact]
        public void ReadCharacter_AdvancesIndex()
        {
            var testSubject = new StringScanner("A");
            Assert.Equal('A', testSubject.ReadCharacter());
            Assert.False(testSubject.HasData);
        }

        [Fact]
        public void ReadNumber_ConsumesAllDigits()
        {
            var testSubject = new StringScanner("1234");
            var expected = new[] {'1', '2', '3', '4'};
            Assert.Equal(expected, testSubject.ReadNumber());
            Assert.False(testSubject.HasData);
        }

        [Fact]
        public void ReadNumber_DoesNotConsumeNonDigits()
        {
            var testSubject = new StringScanner("ABCD");
            var expected = new char[0];
            Assert.Equal(expected, testSubject.ReadNumber());
            Assert.Equal('A', testSubject.ReadCharacter());
        }

        [Fact]
        public void ReadNumber_DoesNotConsumeNonDigitsAtEnd()
        {
            var testSubject = new StringScanner("1234ABCD");
            var expected = new[] {'1', '2', '3', '4'};
            Assert.Equal(expected, testSubject.ReadNumber());
            Assert.Equal('A', testSubject.ReadCharacter());
        }
    }
}