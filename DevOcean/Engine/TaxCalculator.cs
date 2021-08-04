using DevOcean.Data.Enums;
using DevOcean.Engine.Interfaces;
using DevOcean.Engine.Models;
using DevOcean.Infrastructure.Interfaces;
using System;
using System.Globalization;

namespace DevOcean.Engine
{
    public class TaxCalculator : ITaxCalculator
    {
        private const decimal InitialTaxCargo = 10000;
        private const decimal TaxPer1000LightMilesCargo = 1000;
        private const decimal TaxAmortizationPerYearCargo = 736;

        private const decimal InitialTaxFamily = 5000;
        private const decimal TaxPer1000LightMilesFamily = 100;
        private const decimal TaxAmortizationPerYearFamily = 355;

        private readonly IInputHelper inputProcessorHelper;

        public TaxCalculator(IInputHelper inputProcessorHelper)
        {
            this.inputProcessorHelper = inputProcessorHelper;
        }

        public string CalculateTax(InputData input)
        {
            decimal result;

            var spaceshipType = Enum.Parse(typeof(SpaceshipType), this.inputProcessorHelper.CapitalizeFirstLetter(input.SpaceshipType));
            var yearOfPurchase = int.Parse(input.PurchaseDate);
            var yearForTaxCalculation = int.Parse(input.YearOfTaxCalculation);
            var lightMilesTraveled = this.inputProcessorHelper.GetDigitsAfterThousandSeparator(input.LightMilesTraveled);

            switch (spaceshipType)
            {
                case SpaceshipType.Cargo:
                    result = InitialTaxCargo + (int.Parse(lightMilesTraveled) * TaxPer1000LightMilesCargo) - ((yearForTaxCalculation - yearOfPurchase) * TaxAmortizationPerYearCargo); break;
                case SpaceshipType.Family:
                    result = InitialTaxFamily + (int.Parse(lightMilesTraveled) * TaxPer1000LightMilesFamily) - ((yearForTaxCalculation - yearOfPurchase) * TaxAmortizationPerYearFamily); break;
                default: return null;
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
