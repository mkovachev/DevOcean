﻿using DevOcean.Engine;
using DevOcean.Engine.Interfaces;
using NSubstitute;
using System.Collections.Generic;
using System.Globalization;
using Xunit;

namespace DevOcean.Tests.Engine
{
    public class TaxCalculatorTests
    {
        private readonly ITaxCalculator sut;
        private readonly IInputProcessorHelper inputProcessorHelper = Substitute.For<IInputProcessorHelper>();

        public TaxCalculatorTests()
        {
            this.sut = new TaxCalculator(inputProcessorHelper);
        }

        //[Theory]
        //[InlineData("family", null, "2307", "2344")]
        //[InlineData("family", "2300", null, "2344")]
        //public void CalculateTax_Should_Returns_Null_When_Input_Paramaters_Are_Invalid(
        //   string spaceshipType,
        //   string yearOfPurchase,
        //   string yearForTaxCalculation,
        //   string milesTraveled)
        //{
        //    //Arange
        //    this.inputProcessorHelper.CapitalizeFirstletter(spaceshipType)
        //        .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
        //    this.inputProcessorHelper.GetDigitsAfterThousandSeparator(milesTraveled)
        //        .Returns(int.Parse(milesTraveled).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0]);

        //    var taxData = new List<string>()
        //    {
        //        spaceshipType,
        //        yearOfPurchase,
        //        yearForTaxCalculation,
        //        milesTraveled
        //    };

        //    //Act
        //    var result = this.sut.CalculateTax(taxData);

        //    //Assert
        //    Assert.Null(result);
        //}

        //[Theory]
        //[InlineData(null, "2300", "2307", "2344")]
        //[InlineData("family", "2300", "2307", null)]
        //public void CalculateTax_Returns_Null_When_TaxData_Has_Null_Parameters(
        //   string spaceshipType,
        //   string yearOfPurchase,
        //   string yearForTaxCalculation,
        //   string milesTraveled)
        //{
        //    //Arange
        //    this.inputProcessorHelper.CapitalizeFirstletter(spaceshipType).Returns(x => null);

        //    this.inputProcessorHelper.GetDigitsAfterThousandSeparator(milesTraveled).Returns(x => null);

        //    var taxData = new List<string>()
        //    {
        //        spaceshipType,
        //        yearOfPurchase,
        //        yearForTaxCalculation,
        //        milesTraveled
        //    };

        //    //Act
        //    var result = this.sut.CalculateTax(taxData);

        //    //Assert
        //    Assert.Null(result);
        //}

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
            this.inputProcessorHelper.CapitalizeFirstletter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputProcessorHelper.GetDigitsAfterThousandSeparator(milesTraveled)
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
            this.inputProcessorHelper.CapitalizeFirstletter(spaceshipType)
                .Returns(char.ToUpper(spaceshipType[0]) + spaceshipType.Substring(1));
            this.inputProcessorHelper.GetDigitsAfterThousandSeparator(milesTraveled)
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