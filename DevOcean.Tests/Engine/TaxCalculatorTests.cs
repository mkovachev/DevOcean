using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using DevOcean.Engine.Models;
using DevOcean.Infrastructure.Interfaces;
using NSubstitute;
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
            string lightMilesTraveled,
            int expected)
        {
            //Arange
            this.inputHelper.CapitalizeFirstLetter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputHelper.GetDigitsAfterThousandSeparator(lightMilesTraveled)
                .Returns(int.Parse(lightMilesTraveled).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0]);

            var inputData = new InputData()
            {
                SpaceshipType = spaceshipType,
                PurchaseDate = yearOfPurchase,
                YearOfTaxCalculation = yearForTaxCalculation,
                LightMilesTraveled = lightMilesTraveled
            };

            //Act
            var result = this.sut.CalculateTax(inputData);

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
           string lightMilesTraveled)
        {
            //Arange
            this.inputHelper.CapitalizeFirstLetter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputHelper.GetDigitsAfterThousandSeparator(lightMilesTraveled)
                .Returns(int.Parse(lightMilesTraveled).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0]);

            var inputData = new InputData()
            {
                SpaceshipType = spaceshipType,
                PurchaseDate = yearOfPurchase,
                YearOfTaxCalculation = yearForTaxCalculation,
                LightMilesTraveled = lightMilesTraveled
            };

            //Act
            var result = this.sut.CalculateTax(inputData);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<string>(result);
        }
    }
}
