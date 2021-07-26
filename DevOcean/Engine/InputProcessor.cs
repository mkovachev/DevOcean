using DevOcean.Data.Enums;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace DevOcean.Engine
{
    public class InputProcessor : IInputProcessor
    {
        private const int InputParamsCount = 4;

        private readonly IWriter writer;
        private readonly IReader reader;

        public InputProcessor(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public List<string> ReadInput()
        {
            var taxData = new List<string>();
            try
            {
                this.writer.Write("Please type in a spaceship type: ");
                var spaceshipType = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in a purchase date: ");
                var purchaseDate = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in an year of tax calculation: ");
                var yearOfTaxCalculation = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in a light miles travaled: ");
                var lightMilesTravaled = this.reader.ReadLine().ToLower().Trim();

                taxData.Add(spaceshipType);
                taxData.Add(purchaseDate);
                taxData.Add(yearOfTaxCalculation);
                taxData.Add(lightMilesTravaled);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine($"{ex.Message}");
            }

            return taxData;
        }

        public bool IsValidateInput(List<string> input)
            => input.Count == InputParamsCount
                && !input.Any(i => string.IsNullOrWhiteSpace(i))
                && !input.Any(i => string.IsNullOrEmpty(i))
                && input.Skip(1).All(i => !i.Any(x => !char.IsDigit(x)))
                && (SpaceshipType)Enum.Parse(typeof(SpaceshipType), this.CapitalizeFirstLetter(input[0])) != SpaceshipType.Unknown;

        public string CapitalizeFirstLetter(string input) => char.ToUpper(input[0]) + input.Substring(1);

        public string GetDigitsAfterThousandSeparator(string input)
            => int.Parse(input).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0];

    }
}
