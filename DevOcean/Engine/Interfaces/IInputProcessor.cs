using System.Collections.Generic;

namespace DevOcean.Engine.Interfaces
{
    public interface IInputProcessor
    {
        public List<string> ReadInput();

        public bool IsValidateInput(List<string> input);
    }
}
