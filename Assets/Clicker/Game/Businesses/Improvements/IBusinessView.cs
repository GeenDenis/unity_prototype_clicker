using System;

namespace Clicker.Game.Businesses.Improvements
{
    public interface IImprovementView
    {
        event Action OnClickBuy;
        
        void SetName(string value);
        void SetPrice(int value);
        void SetIncomeMultiplier(float value);
        void SetBuyAccess(bool value);
        void SetPurchasedState(bool value);
    }
}