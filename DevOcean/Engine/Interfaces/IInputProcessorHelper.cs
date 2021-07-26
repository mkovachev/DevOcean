namespace DevOcean.Engine.Interfaces
{
    public interface IInputProcessorHelper
    {
        public string CapitalizeFirstLetter(string input);

        public string GetDigitsAfterThousandSeparator(string input);
    }
}