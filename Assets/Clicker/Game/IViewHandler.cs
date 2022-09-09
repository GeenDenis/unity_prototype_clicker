using Clicker.Core.Update;

namespace Clicker.Game
{
    public interface IViewHandler : IUpdatable
    {
        void SetActiveInput(bool active);
    }
}