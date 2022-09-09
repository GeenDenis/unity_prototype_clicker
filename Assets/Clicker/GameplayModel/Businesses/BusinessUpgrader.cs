using Clicker.GameplayModel.Balance;
using Clicker.GameplayModel.Upgrades;

namespace Clicker.GameplayModel.Businesses
{
    public class BusinessUpgrader : IUpgrader
    {
        private readonly ISpendableBalance _moneyBalance;

        public BusinessUpgrader(ISpendableBalance moneyBalance)
        {
            _moneyBalance = moneyBalance;
        }

        public void Upgrade(IUpgradable obj)
        {
            if (_moneyBalance.TrySpend(obj.UpgradeCost))
            {
                obj.Upgrade();
            }
        }
    }
}