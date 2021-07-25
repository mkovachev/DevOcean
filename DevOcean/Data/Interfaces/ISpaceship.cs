using DevOcean.Data.Enums;

namespace DevOcean.Data.Interfaces
{
    public interface ISpaceship
    {
        string PurchaseDate { get; }

        SpaceshipType Type { get; }
    }
}
