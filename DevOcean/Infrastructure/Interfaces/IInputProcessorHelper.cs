namespace DevOcean.Infrastructure.Interfaces
{
    public interface IInputProcessorHelper
    {
        public string CapitalizeFirstletter(string input);

        public string GetDigitsAfterThousandSeparator(string input);
    }
}