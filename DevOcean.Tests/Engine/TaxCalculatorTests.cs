using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class TaxCalculatorTests
    {
        private readonly ITaxCalculator sut;
        private readonly IInputHelper inputHelper = Substitute.For<IInputHelper>();

        public TaxCalculatorTests()
        {
            this.sut = new TaxCalculator(inputHelper);
        }

        [Theory]
        [InlineData("family", "2300", "2307", "2344", 2715)]
        [InlineData("cargo", "2332", "2369", "344789", 326768)]
        public void CalculateTax_Should_Return_Valid_CalculatedTax(
            string spaceshipType,
            string yearOfPurchase,
            string yearForTaxCalculation,
            string milesTraveled,
            int expected)
        {
            //Arange
            this.inputHelper.CapitalizeFirstLetter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputHelper.GetDigitsAfterThousandSeparator(milesTraveled)
                .Returns(int.Parse(milesTraveled).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0]);

            var taxData = new List<string>()
            {
                spaceshipType,
                yearOfPurchase,
                yearForTaxCalculation,
                milesTraveled
            };

            //Act
            var result = this.sut.CalculateTax(taxData);

            //Assert
            Assert.Equal(expected.ToString(), result);
        }

        [Theory]
        [InlineData("family", "2300", "2307", "2344")]
        [InlineData("cargo", "2332", "2369", "344789")]
        public void CalculateTax_Should_Return_Valid_CalculatedTax_OfType_String(
           string spaceshipType,
           string yearOfPurchase,
           string yearForTaxCalculation,
           string milesTraveled)
        {
            //Arange
            this.inputHelper.CapitalizeFirstLetter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputHelper.GetDigitsAfterThousandSeparator(milesTraveled)
                .Returns(int.Parse(milesTraveled).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0]);

            var taxData = new List<string>()
            {
                spaceshipType,
                yearOfPurchase,
                yearForTaxCalculation,
                milesTraveled
            };

            //Act
            var result = this.sut.CalculateTax(taxData);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
