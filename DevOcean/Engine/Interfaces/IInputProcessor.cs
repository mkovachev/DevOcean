using DevOcean.Engine.Models;

namespace DevOcean.Engine.Interfaces
{
    public interface IInputProcessor
    {
        public InputData ReadInput();

        public bool IsValidateInput(InputData input);
    }
}
