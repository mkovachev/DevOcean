using DevOcean.Data.Enums;
using DevOcean.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace DevOcean.Infrastructure
{
    public class Guard : IGuard
    {
        private readonly IInputHelper inputHelper;

        public Guard(IInputHelper inputHelper)
        {
            this.inputHelper = inputHelper;
        }

        public bool AgainstInvalidSpaceshipType(string value)
            => Enum.TryParse(this.inputHelper.CapitalizeFirstLetter(value), out SpaceshipType type);

        public bool AgainstNullOrEmpty(string value) => !string.IsNullOrEmpty(value);

        public bool AgainstNullOrWhiteSpace(string value) => !string.IsNullOrWhiteSpace(value);

        public bool AgainstNonDigits(string value) => !value.Any(x => !char.IsDigit(x));

        public bool AgainstNegativeOrZero(string value) => int.Parse(value) > 0;
    }
}
