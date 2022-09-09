using System;
using Clicker.Game.Businesses.Improvements;

namespace Clicker.Game.Businesses
{
    public interface IBusinessView
    {
        IImprovementView[] Improvements { get; }

        event Action OnClickLevelUp;
        
        void SetName(string value);
        void SetIncomeProgress(float value);
        void SetIncome(int value);
        void SetLevel(int value);
        void SetUpgradeCost(int value);
        void SetUpgradeAccess(bool value);
    }
}