namespace DevOcean.Engine.Interfaces
{
    public interface IInputProcessorHelper
    {
        public string CapitalizeFirstletter(string input);

        public string GetDigitsAfterThousandSeparator(string input);
    }
}