using DevOcean.Engine;
using Xunit;

namespace DevOcean.Tests.Infrastructure
{
    public class InputHelperTests
    {
        private readonly InputHelper sut;

        public InputHelperTests()
        {
            this.sut = new InputHelper();
        }

        [Fact]
        public void CapitalizeFirstLetter_Should_Return_String_With_Capitalized_First_Letter()
        {
            // Arrange
            var input = "family";

            // Act
            var result = this.sut.CapitalizeFirstLetter(input);

            // Assert
            Assert.Equal("Family", result);
        }

        [Theory]
        [InlineData("1000")]
        public void GetDigitsAfterThousandSeparator_Should_Return_Only_Digits_After_Thousand_Separator(string input)
        {
            // Act
            var result = this.sut.GetDigitsAfterThousandSeparator(input);

            // Assert
            Assert.Equal("1", result);
        }
    }
}
