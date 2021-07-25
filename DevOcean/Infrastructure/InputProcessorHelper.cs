﻿using DevOcean.Infrastructure.Interfaces;
using System.Globalization;

namespace DevOcean.Infrastructure
{
    public class InputProcessorHelper : IInputProcessorHelper
    {
        public string CapitalizeFirstletter(string input) => char.ToUpper(input[0]) + input.Substring(1);

        public string GetDigitsAfterThousandSeparator(string input)
            => int.Parse(input).ToString("n", CultureInfo.GetCultureInfo("en-US")).Split(",")[0];
    }
}
