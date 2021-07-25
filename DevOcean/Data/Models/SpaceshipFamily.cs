using DevOcean.Data.Enums;

namespace DevOcean.Data.Models
{
    public class SpaceshipFamily : Spaceship
    {
        public override SpaceshipType Type => SpaceshipType.Family;
    }
}
