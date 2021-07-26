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

        //[Theory]
        //[InlineData("family", "2300", "2307", "2344", 2715)]
        //[InlineData("cargo", "2332", "2369", "344789", 326768)]
        //public void Start_Should_Returns_CalculatedTax_Correctly(
        //   string spaceshipType,
        //   string yearOfPurchase,
        //   string yearForTaxCalculation,
        //   string milesTravele,
        //    int expected)
        //{
        //    // Arange
        //    var taxData = new List<string>()
        //    {
        //        spaceshipType,
        //        yearOfPurchase,
        //        yearForTaxCalculation,
        //        milesTravele
        //    };

        //    this.inputProcessor.ReadInput().Returns(taxData);
        //    this.inputProcessor.IsValidateInput(taxData);
        //    var result = this.taxCalculator.CalculateTax(taxData);

        //    // Act
        //    this.sut.Start();

        //    // Assert
        //    Assert.Equal(expected, int.Parse(result));
        //}

        //[Theory]
        //[InlineData("family", "2300", "2307", "2344")]
        //public void Start_Should_Returns_CalculatedTax_OfType_String(
        //    string spaceshipType,
        //    string yearOfPurchase,
        //    string yearForTaxCalculation,
        //    string milesTravele)
        //{
        //    // Arange
        //    var taxData = new List<string>()
        //    {
        //        spaceshipType,
        //        yearOfPurchase,
        //        yearForTaxCalculation,
        //        milesTravele
        //    };

        //    this.inputProcessor.ReadInput().Returns(taxData);
        //    this.inputProcessor.IsValidateInput(taxData);
        //    var result = this.taxCalculator.CalculateTax(taxData);

        //    // Act
        //    this.sut.Start();

        //    // Assert
        //    Assert.IsType<string>(result);
        //}

        [Theory]
        [InlineData(null, "", " ", "2344")]
        public void Start_Should_Returns_IsValidInput_False_If_Input_Contains_Null_WhiteSpace_NonDigits_Parameters(
             string spaceshipType,
             string yearOfPurchase,
             string yearForTaxCalculation,
             string milesTravele)
        {
            // Arange
            var taxData = new List<string>()
            {
                spaceshipType,
                yearOfPurchase,
                yearForTaxCalculation,
                milesTravele
            };

            this.inputProcessor.ReadInput().Returns(taxData);
            var result = this.inputProcessor.IsValidateInput(null);

            // Act
            this.sut.Start();

            // Assert
            Assert.False(result);
        }
    }
}
