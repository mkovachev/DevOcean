using DevOcean.Data.Enums;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
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

        public string CalculateTax(IList<string> taxData)
        {
            decimal result;

            var spaceshipType = Enum.Parse(typeof(SpaceshipType), this.inputProcessorHelper.CapitalizeFirstLetter(taxData[0]));
            var yearOfPurchase = int.Parse(taxData[1]);
            var yearForTaxCalculation = int.Parse(taxData[2]);
            var milesTraveled = this.inputProcessorHelper.GetDigitsAfterThousandSeparator(taxData[3]);

            switch (spaceshipType)
            {
                case SpaceshipType.Cargo:
                    result = InitialTaxCargo + (int.Parse(milesTraveled) * TaxPer1000LightMilesCargo) - ((yearForTaxCalculation - yearOfPurchase) * TaxAmortizationPerYearCargo); break;
                case SpaceshipType.Family:
                    result = InitialTaxFamily + (int.Parse(milesTraveled) * TaxPer1000LightMilesFamily) - ((yearForTaxCalculation - yearOfPurchase) * TaxAmortizationPerYearFamily); break;
                default: return null;
            }

            return result.ToString(CultureInfo.InvariantCulture);
        }
    }
}
