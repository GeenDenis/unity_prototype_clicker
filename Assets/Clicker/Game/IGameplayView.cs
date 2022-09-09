using Clicker.Game.Businesses;

namespace Clicker.Game
{
    public interface IGameplayView
    {
        IBusinessView CreateBusinessView(IBusinessInfo data);
        void ClearView();
        void SetBalance(int value);
    }
}