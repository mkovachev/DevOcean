using DevOcean.Data.Enums;

namespace DevOcean.Data.Models
{
    public class SpaceshipCargo : Spaceship
    {
        public override SpaceshipType Type => SpaceshipType.Cargo;
    }
}
