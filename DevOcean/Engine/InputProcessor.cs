using DevOcean.Engine.Interfaces;
using DevOcean.Engine.Models;
using DevOcean.Infrastructure.Interfaces;
using System;

namespace DevOcean.Engine
{
    public class InputProcessor : IInputProcessor
    {
        private readonly IWriter writer;
        private readonly IReader reader;
        private readonly IGuard guard;

        public InputProcessor(IReader reader, IWriter writer, IGuard guard)
        {
            this.reader = reader;
            this.writer = writer;
            this.guard = guard;
        }

        public InputData ReadInput()
        {
            var inputData = new InputData();

            try
            {
                this.writer.Write("Please type in a spaceship type: ");
                var spaceshipType = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in a purchase date: ");
                var purchaseDate = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in an year of tax calculation: ");
                var yearOfTaxCalculation = this.reader.ReadLine().ToLower().Trim();

                this.writer.Write("Please type in a light miles travaled: ");
                var lightMilesTraveled = this.reader.ReadLine().ToLower().Trim();

                inputData.SpaceshipType = spaceshipType;
                inputData.PurchaseDate = purchaseDate;
                inputData.YearOfTaxCalculation = yearOfTaxCalculation;
                inputData.LightMilesTraveled = lightMilesTraveled;
            }
            catch (Exception ex)
            {
                this.writer.WriteLine($"{ex.Message}");
            }

            return inputData;
        }

        public bool IsValidateInput(InputData input)
        {
            var isValidSpaceshipType = this.guard.AgainstInvalidSpaceshipType(input.SpaceshipType);
            var isValidPurchaseDate = ValidateInput(input.PurchaseDate);
            var isValidYearOfTaxCalculation = ValidateInput(input.YearOfTaxCalculation);
            var isValidLightMilesTraveled = ValidateInput(input.LightMilesTraveled);

            return isValidSpaceshipType && isValidPurchaseDate && isValidYearOfTaxCalculation && isValidLightMilesTraveled;
        }

        private bool ValidateInput(string value)
        {
            return this.guard.AgainstNullOrEmpty(value)
                && this.guard.AgainstNullOrWhiteSpace(value)
                && this.guard.AgainstNonDigits(value)
                && this.guard.AgainstNegativeOrZero(value);
        }
    }
}
