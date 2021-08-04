using DevOcean.Engine.Models;

namespace DevOcean.Engine.Interfaces
{
    public interface ITaxCalculator
    {
        public string CalculateTax(InputData taxData);
    }
}