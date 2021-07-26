using DevOcean.Engine.Interfaces;
using DevOcean.Infrastructure.Interfaces;
using System;

namespace DevOcean.Engine
{
    public class SpaceEngine : IEngine
    {
        private readonly IWriter writer;
        private readonly IInputProcessor inputProcessor;
        private readonly ITaxCalculator taxCalculator;

        public SpaceEngine(IWriter writer, IInputProcessor inputProcessor, ITaxCalculator taxCalculator)
        {
            this.writer = writer;
            this.inputProcessor = inputProcessor;
            this.taxCalculator = taxCalculator;
        }

        public void Start()
        {
            var calculatedTax = string.Empty;

            while (true)
            {
                try
                {
                    var taxData = this.inputProcessor.ReadInput();

                    var isValidInput = this.inputProcessor.IsValidateInput(taxData);

                    if (isValidInput)
                    {
                        calculatedTax = this.taxCalculator.CalculateTax(taxData);
                    }
                    else
                    {
                        this.writer.WriteLine("Please provide valid input!");
                        this.writer.WriteLine("--------------------------------------");
                        continue;
                    }

                }
                catch (Exception ex)
                {
                    this.writer.WriteLine($"{ex}");
                }

                this.writer.WriteLine("--------------------------------------");
                this.writer.WriteLine($"Total tax amount to pay: {calculatedTax}");
                this.writer.WriteLine("--------------------------------------");
            }

        }
    }
}
