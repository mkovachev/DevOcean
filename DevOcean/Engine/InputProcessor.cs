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

                this.writer.Write("Please type in a light miles traveled: ");
                var lightMilesTraveled = this.reader.ReadLine().ToLower().Trim();

                taxData.Add(spaceshipType);
                taxData.Add(purchaseDate);
                taxData.Add(yearOfTaxCalculation);
                taxData.Add(lightMilesTraveled);
            }
            catch (Exception ex)
            {
                this.writer.WriteLine($"{ex.Message}");
            }

            return taxData;
        }

        public bool IsValidateInput(List<string> input)
            => input.Count == InputParamsCount
                && !input.Any(string.IsNullOrWhiteSpace)
                && !input.Any(string.IsNullOrEmpty)
                && input.All(i => i.Any(x => !char.IsDigit(x)));
    }
}
