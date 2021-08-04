namespace DevOcean.Infrastructure.Interfaces
{
    public interface IGuard
    {
        bool AgainstInvalidSpaceshipType(string value);
        bool AgainstNegativeOrZero(string value);
        bool AgainstNonDigits(string value);
        bool AgainstNullOrEmpty(string value);
        bool AgainstNullOrWhiteSpace(string value);
    }
}