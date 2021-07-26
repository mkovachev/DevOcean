using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class InputProcessorTests
    {
        private readonly IInputProcessor sut;
        private readonly IWriter writer = Substitute.For<IWriter>();
        private readonly IReader reader = Substitute.For<IReader>();
        private readonly IInputHelper inputHelper = Substitute.For<IInputHelper>();

        public InputProcessorTests()
        {
            this.sut = new InputProcessor(reader, writer, inputHelper);
        }

        [Theory]
        [InlineData("input")]
        public void ReadInput_Should_Return_List_OfType_Strings(string input)
        {
            // Arrange
            this.reader.ReadLine().ToLower().Trim().Returns(input);

            // Act
            var result = this.sut.ReadInput();

            // Assert
            Assert.IsType<List<string>>(result);
        }

        [Theory]
        [InlineData("input")]
        public void ReadInput_Should_Return_List_With_Four_Elements(string input)
        {
            // Arrange
            this.reader.ReadLine().ToLower().Trim().Returns(input);

            // Act
            var result = this.sut.ReadInput();

            // Assert
            Assert.True(result.Count == 4);
        }

        [Theory]
        [InlineData("family", "1", "1", "nonDigits")]
        [InlineData("family", "1", "1", "")]
        [InlineData("family", "1", "1", " ")]
        [InlineData("family", "1", "1", null)]
        public void IsValidInput_Should_Return_IsValidInput_False_If_Input_Contains_Null_WhiteSpace_NonDigits_Parameters(
            string spaceshipType,
            string yearOfPurchase,
            string yearForTaxCalculation,
            string milesTraveled)
        {
            // Arrange
            var taxData = new List<string>()
            {
                spaceshipType,
                yearOfPurchase,
                yearForTaxCalculation,
                milesTraveled
            };

            // Act
            var result = this.sut.IsValidateInput(taxData);

            // Assert
            Assert.False(result);
        }
    }
}
