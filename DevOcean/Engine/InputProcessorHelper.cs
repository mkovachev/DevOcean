using DevOcean.Engine.Interfaces;
using System.Globalization;

namespace DevOcean.Engine
{
    public class InputProcessorHelper : IInputProcessorHelper
    {
        public string CapitalizeFirstLetter(string input) => char.ToUpper(input[0]) + input.Substring(1);

        public string GetDigitsAfterThousandSeparator(string input)
            => int.Parse(input).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(".")[0];
    }
}
