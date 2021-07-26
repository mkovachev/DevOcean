namespace DevOcean.Infrastructure.Interfaces
{
    public interface IInputHelper
    {
        public string CapitalizeFirstLetter(string input);

        public string GetDigitsAfterThousandSeparator(string input);
    }
}
