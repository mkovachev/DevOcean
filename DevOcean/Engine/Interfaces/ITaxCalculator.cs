using System.Collections.Generic;

namespace DevOcean.Engine.Interfaces
{
    public interface ITaxCalculator
    {
        public string CalculateTax(IList<string> taxData);
    }
}