using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Engine.Models;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class InputProcessorTests
    {
        private readonly IInputProcessor sut;
        private readonly IWriter writer = Substitute.For<IWriter>();
        private readonly IReader reader = Substitute.For<IReader>();
        private readonly IGuard guard = Substitute.For<IGuard>();

        public InputProcessorTests()
        {
            this.sut = new InputProcessor(reader, writer, guard);
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
            Assert.IsType<InputData>(result);
        }

        [Fact]
        public void ReadInput_Should_Return_InputData_Class_With_Four_Props()
        {
            // Arrange
            //this.reader.ReadLine().ToLower().Trim().Returns(input);

            // Act
            var result = this.sut.ReadInput();

            // Assert
            Assert.True(result.Count() == 4);
        }

        [Theory]
        [InlineData("family", "1", "1", "nonDigits")]
        [InlineData("family", "1", "1", "")]
        [InlineData("family", "1", "1", " ")]
        [InlineData("family", "1", "1", "-1")]
        public void IsValidInput_Should_Return_False_If_Input_Contains_Null_Empty_WhiteSpace_NonDigits_Negative_Zero_Parameters(
            string spaceshipType,
            string yearOfPurchase,
            string yearForTaxCalculation,
            string lightMilesTraveled)
        {
            // Arrange
            var inputData = new InputData()
            {
                SpaceshipType = spaceshipType,
                PurchaseDate = yearOfPurchase,
                YearOfTaxCalculation = yearForTaxCalculation,
                LightMilesTraveled = lightMilesTraveled
            };

            // Act
            var result = this.sut.IsValidateInput(inputData);

            // Assert
            Assert.False(result);
        }
    }
}
