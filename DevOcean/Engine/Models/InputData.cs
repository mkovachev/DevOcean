using DevOcean.Infrastructure;

namespace DevOcean.Engine.Models
{
    public class InputData : Countable<InputData>
    {
        public string SpaceshipType { get; set; }

        public string PurchaseDate { get; set; }

        public string YearOfTaxCalculation { get; set; }

        public string LightMilesTraveled { get; set; }
    }
}
