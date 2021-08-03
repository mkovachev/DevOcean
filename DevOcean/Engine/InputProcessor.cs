using DevOcean.Data.Enums;
using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DevOcean.Engine
{
    public class InputProcessor : IInputProcessor
    {
        private const int InputParamsCount = 4;

        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IInputHelper inputHelper;

        public InputProcessor(IReader reader, IWriter writer, IInputHelper inputHelper)
        {
            this.reader = reader;
            this.writer = writer;
            this.inputHelper = inputHelper;
        }

        public List<string> ReadInput()
        {
            var taxData = new List<string>(); // change with class
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
                           && Enum.TryParse(this.inputHelper.CapitalizeFirstLetter(input[0]), out SpaceshipType type)
                           && type != SpaceshipType.Unknown;

    }
}
