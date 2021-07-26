using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class SpaceEngineTests
    {
        private readonly SpaceEngine sut;
        private readonly IWriter writer = Substitute.For<IWriter>();
        private readonly IInputProcessor inputProcessor = Substitute.For<IInputProcessor>();
        private readonly ITaxCalculator taxCalculator = Substitute.For<ITaxCalculator>();
        public SpaceEngineTests()
        {
            this.sut = new SpaceEngine(writer, inputProcessor, taxCalculator);
        }

        // [Theory]
        // [InlineData("null", "", " ", null)]
        // public void Start_Should_Return_IsValidInput_False_If_Input_Contains_Null_WhiteSpace_NonDigits_Parameters(
        //      string spaceshipType,
        //      string yearOfPurchase,
        //      string yearForTaxCalculation,
        //      string milesTraveled)
        // {
        //     // Arrange
        //     var taxData = new List<string>()
        //     {
        //         spaceshipType,
        //         yearOfPurchase,
        //         yearForTaxCalculation,
        //         milesTraveled
        //     };
        //
        //     this.inputProcessor.ReadInput().Returns(taxData);
        //     var result = this.inputProcessor.IsValidateInput(null);
        //
        //     // Act
        //     this.sut.Start();
        //
        //     // Assert
        //     Assert.False(result);
        // }
    }
}
